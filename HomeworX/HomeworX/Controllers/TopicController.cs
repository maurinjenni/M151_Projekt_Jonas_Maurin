using HomeworX.Models;
using HomeworX.Models.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeworX.Controllers
{
    public class TopicController : Controller
    {
        private UnitOfWork _uow;

        public TopicController()
        {
            _uow = new UnitOfWork(new HomeworXEntities());
        }

        [Route("Topic/index")]
        public ActionResult Index()
        {
            // Data Load
            var topics = _uow.TopicRepository.Get(null,t => t.OrderBy(r => r.Subject.Detail).ThenBy(r => r.Description),string.Empty);

            // Information Load

            // Logic

            // Load View
            return View("Index", topics);
        }

        [Route("Topic/details/{uid}")]
        public ActionResult Details(Guid uid)
        {
            // Data Load
            var topic = _uow.TopicRepository.Get(uid);

            // Information Load
            ViewBag.Subjects = GetSubjectsDropDown();

            // Logic

            // Load View
            return View("Details", topic);
        }

        [Route("Topic/create")]
        public ActionResult Create()
        {
            // Data Load

            // Information Load
            ViewBag.Subjects = GetSubjectsDropDown();

            // Logic

            // Load View
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Topic topic)
        {
            var validationErrors = topic.IsValid();

            // Logic
            if (!validationErrors.Any())
            {
                topic.UID = Guid.NewGuid();

                // Repository Call
                _uow.TopicRepository.Insert(topic);
                _uow.Commit();
            }
            else
            {
                foreach (var error in validationErrors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                return View("Create");
            }

            // Information Load
            ViewBag.Subjects = GetSubjectsDropDown();

            // Load View
            return View("Details", topic);
        }

        [Route("Topic/edit/{uid}")]
        public ActionResult Edit(Guid uid)
        {
            // Data Load
            var topic = _uow.TopicRepository.Get(uid);

            // Information Load
            ViewBag.Subjects = GetSubjectsDropDown();

            // Logic

            // Load View
            return View("Edit", topic);
        }

        [HttpPost]
        public ActionResult Edit(Topic topic)
        {
            var validationErrors = topic.IsValid();
            // Logic
            if (!validationErrors.Any())
            {
                // Repository Call
                _uow.TopicRepository.Update(topic);
                _uow.Commit();
            }
            else
            {
                foreach (var error in validationErrors)
                {
                    ModelState.AddModelError(error.Key, error.Value);
                }

                return Edit(topic.UID);
            }

            // Information Load
            ViewBag.Subjects = GetSubjectsDropDown();

            // Load View
            return View("Details", topic);
        }

        [Route("Topic/delete/{uid}")]
        public ActionResult Delete(Guid uid)
        {
            // Logic
            if (_uow.TopicToAppointmentRepository.Get().Any(tta => tta.TopicUID == uid))
            {
                foreach (Guid topicToAppointmentUID in _uow.TopicToAppointmentRepository.Get().Where(tta => tta.TopicUID == uid).Select(tta => tta.UID))
                {
                    _uow.TopicToAppointmentRepository.Delete(topicToAppointmentUID);
                }
            }

            // Repository Call
            _uow.TopicRepository.Delete(uid);
            _uow.Commit();

            // Load View
            return Index();
        }

        private List<SelectListItem> GetSubjectsDropDown()
        {
            var subjects = _uow.SubjectRepository.Get();

            List<SelectListItem> dropdownSubjects = new List<SelectListItem>();

            foreach (var subject in subjects)
            {
                dropdownSubjects.Add(new SelectListItem()
                {
                    Text = subject.Description,
                    Value = subject.UID.ToString()
                });
            }

            return dropdownSubjects;
        }
    }
}