using HomeworX.Models;
using HomeworX.Models.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HomeworX.Controllers
{
    public class HomeworkController : Controller
    {
        private UnitOfWork _uow;

        public HomeworkController()
        {
            _uow = new UnitOfWork(new HomeworXEntities());
        }

        [Route("Homework/index")]
        public ActionResult Index()
        {
            // Data Load
            var homeworks = _uow.HomeworkRepository.Get(null,t => t.OrderBy(r => r.Appointment.Date).ThenBy(r => r.Appointment.Description),"Appointment");

            // Information Load

            // Logic

            // Load View
            return View("Index", homeworks);
        }

        [Route("Homework/details/{uid}")]
        public ActionResult Details(Guid uid)
        {
            // Data Load
            var homework = _uow.HomeworkRepository.Get(uid);

            // Information Load
            ViewBag.Topics = GetTopicDropDown();

            // Logic
            homework.Topics = homework.Appointment.TopicToAppointment.Select(tta => tta.TopicUID);

            return View("Details", homework);
        }

        [Route("Homework/create")]
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
        public ActionResult Create(Homework homework)
        {
            // Logic

            if (homework.Appointment.IsValid() && homework.IsValid())
            {
                homework.Appointment.UID = Guid.NewGuid();
                homework.UID = homework.Appointment.UID;

                homework.Appointment.TopicToAppointment = new List<TopicToAppointment>();

                if (homework.Topics != null)
                {
                    foreach (var topic in homework.Topics)
                    {
                        homework.Appointment.TopicToAppointment.Add(new TopicToAppointment()
                        {
                            UID = Guid.NewGuid(),
                            TopicUID = topic,
                            AppointmentUID = homework.UID
                        });
                    }
                }

                // Repository Call
                _uow.HomeworkRepository.Insert(homework);
                _uow.Commit();
            }
            else
            {
                return Create();
            }

            // Information Load
            ViewBag.Subjects = GetSubjectsDropDown();
            ViewBag.Topics = GetTopicDropDown();

            // Load View
            return View("Details", homework);
        }

        [Route("Homework/edit/{uid}")]
        public ActionResult Edit(Guid uid)
        {
            // Data Load
            var homework = _uow.HomeworkRepository.Get(uid);

            // Information Load
            ViewBag.Subjects = GetSubjectsDropDown();
            ViewBag.Topics = GetTopicDropDown();

            // Logic
            homework.Topics = homework.Appointment.TopicToAppointment.Select(tta => tta.TopicUID).ToList();

            // Load View
            return View("Edit", homework);
        }

        [HttpPost]
        public ActionResult Edit(Homework homework)
        {
            // Logic
            if (homework.Appointment.IsValid() && homework.IsValid())
            {
                homework.Appointment.TopicToAppointment = new List<TopicToAppointment>();
                homework.Appointment.UID = homework.UID;

                // Repository Call
                _uow.HomeworkRepository.Update(homework);


                if (homework.Topics != null)
                {
                    _uow.ExamRepository.UpdateTopicToAppointment(homework.Topics.ToList(), homework.Appointment.UID);
                }

                _uow.Commit();
            }
            else
            {
                return Edit(homework.UID);
            }

            // Information Load
            ViewBag.Subjects = GetSubjectsDropDown();
            ViewBag.Topics = GetTopicDropDown();

            // Load View
            return View("Details", homework);
        }

        [Route("Homework/delete/{uid}")]
        public ActionResult Delete(Guid uid)
        {
            // Logic

            // Repository Call
            _uow.HomeworkRepository.Delete(uid);
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
            return _uow.TopicRepository.Get() as ICollection<Topic>;
        }
    }   
}