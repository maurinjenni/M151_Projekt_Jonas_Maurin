using HomeworX.Models;
using HomeworX.Models.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace HomeworX.Controllers
{
    public class SubjectController : Controller
    {
        private UnitOfWork _uow;

        public SubjectController()
        {
            _uow = new UnitOfWork(new HomeworXEntities());
        }

        [Route("Subject/index")]
        public ActionResult Index()
        {
            // Data Load
            var subjects = _uow.SubjectRepository.Get(null, t => t.OrderBy(r => r.Description), string.Empty);

            // Information Load

            // Logic

            // Load View
            return View("Index", subjects);
        }

        [Route("Subject/details/{uid}")]
        public ActionResult Details(Guid uid)
        {
            // Data Load
            var subject = _uow.SubjectRepository.Get(uid);

            // Information Load

            // Logic

            // Load View
            return View("Details", subject);
        }

        [Route("Subject/create")]
        public ActionResult Create()
        {
            // Data Load

            // Information Load

            // Logic

            // Load View
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Subject subject)
        {
            // Logic
            if (subject.IsValid())
            {
                subject.UID = Guid.NewGuid();

                // Repository Call
                _uow.SubjectRepository.Insert(subject);
                _uow.Commit();
            }
            else
            {
                return View("Create");
            }

            // Information Load

            // Load View
            return Details(subject.UID);
        }
        
        [Route("Subject/edit/{uid}")]
        public ActionResult Edit(Guid uid)
        {
            // Data Load
            var subject = _uow.SubjectRepository.Get(uid);

            // Information Load

            // Logic

            // Load View
            return View("Edit", subject);
        }

        [HttpPost]
        public ActionResult Edit(Subject subject)
        {
            // Logic
            if (subject.IsValid())
            {
                // Repository Call
                _uow.SubjectRepository.Update(subject);
                _uow.Commit();
            }
            else
            {
                return View("Edit", subject);
            }

            // Information Load

            // Load View
            return Details(subject.UID);
        }

        [Route("Subject/delete/{uid}")]
        public ActionResult Delete(Guid uid)
        {
            // Logic
            if (_uow.TopicRepository.Get().Any(t => t.SubjectUID == uid))
            {
                foreach (Guid topicUID in _uow.TopicRepository.Get().Where(t => t.SubjectUID == uid).Select(t => t.UID))
                {
                    if (_uow.TopicToAppointmentRepository.Get().Any(tta => tta.TopicUID == topicUID))
                    {
                        foreach (Guid topicToAppointmentUID in _uow.TopicToAppointmentRepository.Get().Where(tta => tta.TopicUID == topicUID).Select(tta => tta.UID))
                        {
                            _uow.TopicToAppointmentRepository.Delete(topicToAppointmentUID);
                        }
                    }

                    _uow.TopicRepository.Delete(topicUID);    
                }
            }

            if (_uow.ExamRepository.Get().Any(e => e.Appointment.SubjectUID == uid))
            {
                foreach (Guid appointmentUID  in _uow.ExamRepository.Get().Where(e => e.Appointment.SubjectUID == uid).Select(e => e.Appointment.UID))
                {
                    if (_uow.TopicToAppointmentRepository.Get().Any(tta => tta.AppointmentUID == appointmentUID))
                    {
                        foreach (Guid topicToAppointmentUID in _uow.TopicToAppointmentRepository.Get().Where(tta => tta.TopicUID == appointmentUID).Select(tta => tta.UID))
                        {
                            _uow.TopicToAppointmentRepository.Delete(topicToAppointmentUID);
                        }
                    }

                    _uow.ExamRepository.Delete(appointmentUID);
                }
            }

            if(_uow.HomeworkRepository.Get().Any(h => h.Appointment.SubjectUID == uid))
            {
                foreach (Guid homeworkUID in _uow.HomeworkRepository.Get().Where(h => h.Appointment.SubjectUID == uid).Select(h => h.UID))
                {
                    _uow.HomeworkRepository.Delete(homeworkUID);
                }
            }

            // Repository Call
            _uow.SubjectRepository.Delete(uid);
            _uow.Commit();

            // Load View
            return Index();
        }
    }
}