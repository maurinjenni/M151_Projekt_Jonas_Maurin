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
            var topics = _uow.TopicRepository.Get();

            return View("Index", topics);
        }

        [Route("Topic/details/{uid}")]
        public ActionResult Details(Guid uid)
        {
            var topic = _uow.TopicRepository.Get(uid);

            return View("Details", topic);
        }

        [Route("Topic/create")]
        public ActionResult Create()
        {
            ViewBag.Subjects = GetSubjectsDropDown();

            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Topic topic)
        {
            topic.UID = Guid.NewGuid();

            _uow.TopicRepository.Insert(topic);
            _uow.Commit();

            return View("Details", topic);
        }

        [Route("Topic/edit/{uid}")]
        public ActionResult Edit(Guid uid)
        {
            ViewBag.Subjects = GetSubjectsDropDown();

            var topic = _uow.TopicRepository.Get(uid);

            return View("Edit", topic);
        }

        [HttpPost]
        public ActionResult Edit(Topic topic)
        {
            _uow.TopicRepository.Update(topic);
            _uow.Commit();

            return View("Details", topic);
        }

        [Route("Topic/delete/{uid}")]
        public ActionResult Delete(Guid uid)
        {
            _uow.TopicRepository.Delete(uid);
            _uow.Commit();

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