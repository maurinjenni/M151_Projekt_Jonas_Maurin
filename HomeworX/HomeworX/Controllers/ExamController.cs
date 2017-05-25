using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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
            var exams = _uow.ExamRepository.Get(null,null, "Appointment");

            return View("Index", exams);
        }

        [Route("Exam/details/{uid}")]
        public ActionResult Details(Guid uid)
        {
            var exam = _uow.ExamRepository.Get(uid);
            
            return View("Details",exam);
        }

        [Route("Exam/create")]
        public ActionResult Create()
        {
            ViewBag.Subjects = GetSubjectsDropDown();
            ViewBag.Topics = GetTopicDropDown();

            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Exam exam)
        {
            exam.UID = Guid.NewGuid();

            _uow.ExamRepository.Insert(exam);
            _uow.Commit();

            return View("Details", exam);
        }

        [Route("Exam/edit/{uid}")]
        public ActionResult Edit(Guid uid)
        {
            ViewBag.Subjects = GetSubjectsDropDown();
            ViewBag.Topics = GetTopicDropDown();

            var exam = _uow.ExamRepository.Get(uid);

            return View("Edit", exam);
        }

        [HttpPost]
        public ActionResult Edit(Exam exam)
        {
            _uow.ExamRepository.Update(exam);
            _uow.Commit();

            return View("Details", exam);
        }

        [Route("Exam/delete/{uid}")]
        public ActionResult Delete(Guid uid)
        {
            _uow.ExamRepository.Delete(uid);
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

        private List<SelectListItem> GetTopicDropDown()
        {
            var topics = _uow.TopicRepository.Get();

            List<SelectListItem> dropdownTopics = new List<SelectListItem>();

            foreach (var topic in topics)
            {
                dropdownTopics.Add(new SelectListItem()
                {
                    Text = topic.Description,
                    Value = topic.UID.ToString()
                });
            }

            return dropdownTopics;
        }
    }
}