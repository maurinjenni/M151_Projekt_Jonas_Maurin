﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HomeworX.Models;
using HomeworX.Models.RepositoryContract;

namespace HomeworX.Controllers
{
    public class ExamController : Controller
    {
        private UnitOfWork _uow;

        public ExamController()
        {
            _uow = new UnitOfWork(new HomeworXEntities());    
        }

        [Route("Exam/index")]
        public ActionResult Index()
        {
            // Data Load
            var exams = _uow.ExamRepository.Get(null, t => t.OrderBy(r => r.Appointment.Date).ThenBy(r => r.Appointment.Description), "Appointment");

            // Information Load

            // Logic

            // Load View
            return View("Index", exams);
        }

        [Route("Exam/details/{uid}")]
        public ActionResult Details(Guid uid)
        {
            // Data Load
            var exam = _uow.ExamRepository.Get(uid);

            // Information Load
            ViewBag.Topics = GetTopicDropDown();

            // Logic
            exam.Topics = exam.Appointment.TopicToAppointment.Select(tta => tta.TopicUID);

            // Load View
            return View("Details",exam);
        }

        [Route("Exam/create")]
        public ActionResult Create()
        {
            // Data Load

            // Information Load
            ViewBag.Subjects = GetSubjectsDropDown();
            ViewBag.Topics = GetTopicDropDown();

            // Logic

            // Load View
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Exam exam)
        {
            var validationErrors = exam.Appointment.IsValid();
            validationErrors.AddRange(exam.IsValid());


            // Logic
            if (!string.IsNullOrEmpty(exam.Mailadress) || exam.Time != null)
            {
                exam.Remind = true;
            }

            if (!validationErrors.Any())
            {
                exam.Appointment.UID = Guid.NewGuid();
                exam.UID = exam.Appointment.UID;

                exam.Appointment.TopicToAppointment = new List<TopicToAppointment>();

                if (exam.Topics != null)
                {
                    foreach (var topic in exam.Topics)
                    {
                        exam.Appointment.TopicToAppointment.Add(new TopicToAppointment()
                        {
                            UID = Guid.NewGuid(),
                            TopicUID = topic,
                            AppointmentUID = exam.UID
                        });
                    }
                }

                // Repository Call
                _uow.ExamRepository.Insert(exam);
                _uow.Commit();
            }
            else
            {
                foreach (var error in validationErrors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                return Create();
            }

            // Information Load
            ViewBag.Subjects = GetSubjectsDropDown();
            ViewBag.Topics = GetTopicDropDown();

            // Load View
            return View("Details", exam);
        }

        [Route("Exam/edit/{uid}")]
        public ActionResult Edit(Guid uid)
        {
            // Data Load
            var exam = _uow.ExamRepository.Get(uid);

            // Information Load
            ViewBag.Subjects = GetSubjectsDropDown();
            ViewBag.Topics = GetTopicDropDown();

            // Logic
            exam.Topics = exam.Appointment.TopicToAppointment.Select(tta => tta.TopicUID).ToList();

            // Load View
            return View("Edit", exam);
        }

        [HttpPost]
        public ActionResult Edit(Exam exam)
        {
            var validationErrors = exam.Appointment.IsValid();
            validationErrors.AddRange(exam.IsValid());

            if (!string.IsNullOrEmpty(exam.Mailadress) || exam.Time != null)
            {
                exam.Remind = true;
            }

            if (!validationErrors.Any())
            {
                // Logic
                exam.Appointment.TopicToAppointment = new List<TopicToAppointment>();
                exam.Appointment.UID = exam.UID;

                // Repository Call
                _uow.ExamRepository.Update(exam);

                if (exam.Topics != null)
                {
                    _uow.ExamRepository.UpdateTopicToAppointment(exam.Topics.ToList(), exam.Appointment.UID);
                }

                _uow.Commit();
            }
            else
            {
                foreach (var error in validationErrors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                return Edit(exam.UID);
            }

            // Information Load
            ViewBag.Subjects = GetSubjectsDropDown();
            ViewBag.Topics = GetTopicDropDown();

            // Load View
            return View("Details", exam);
        }

        [Route("Exam/delete/{uid}")]
        public ActionResult Delete(Guid uid)
        {
            // Logic
            if(_uow.TopicToAppointmentRepository.Get().Any(tta => tta.AppointmentUID == uid))
            {
                foreach(Guid topicToAppointmentUID in _uow.TopicToAppointmentRepository.Get().Select(tta => tta.UID))
                {
                    _uow.TopicToAppointmentRepository.Delete(topicToAppointmentUID);
                }
            }

            // Repository Call
            _uow.ExamRepository.Delete(uid);
            _uow.Commit();

            // Load View
            return Index();
        }

        private List<SelectListItem> GetSubjectsDropDown()
        {
            List<SelectListItem> dropdownSubjects = new List<SelectListItem>();

            foreach (var subject in _uow.SubjectRepository.Get())
            {
                dropdownSubjects.Add(new SelectListItem()
                {
                    Text = subject.Description,
                    Value = subject.UID.ToString()
                });
            }

            return dropdownSubjects;
        }

        private ICollection<Topic> GetTopicDropDown()
        {
            return _uow.TopicRepository.Get()as ICollection<Topic>;
        }
    }
}