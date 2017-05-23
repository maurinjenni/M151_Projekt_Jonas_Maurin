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
        public ExamController()
        {
            _uow = new UnitOfWork(new HomeworXEntities());    
        }

        private UnitOfWork _uow;

        [Route("Exam/index")]
        public ActionResult Index()
        {
            var exams = _uow.ExamRepository.Get();

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
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Exam exam)
        {
            _uow.ExamRepository.Insert(exam);
            _uow.Commit();

            return View("Details", exam);
        }

        [Route("Exam/edit/{uid}")]
        public ActionResult Edit(Guid uid)
        {
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

        public ActionResult Delete(Guid uid)
        {
            _uow.ExamRepository.Delete(uid);
            _uow.Commit();

            return Index();
        }
    }
}