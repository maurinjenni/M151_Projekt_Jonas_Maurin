using HomeworX.Models;
using HomeworX.Models.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var subjects = _uow.SubjectRepository.Get();

            return View("Index", subjects);
        }

        [Route("Subject/details/{uid}")]
        public ActionResult Details(Guid uid)
        {
            var subject = _uow.SubjectRepository.Get(uid);

            return View("Details", subject);
        }

        [Route("Subject/create")]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Subject subject)
        {
            subject.UID = Guid.NewGuid();

            _uow.SubjectRepository.Insert(subject);
            _uow.Commit();

            return View("Details", subject);
        }
        
        [Route("Subject/edit/{uid}")]
        public ActionResult Edit(Guid uid)
        {
            var subject = _uow.SubjectRepository.Get(uid);

            return View("Edit", subject);
        }

        [HttpPost]
        public ActionResult Edit(Subject subject)
        {
            _uow.SubjectRepository.Update(subject);
            _uow.Commit();

            return View("Details", subject);
        }

        [Route("Subject/delete/{uid}")]
        public ActionResult Delete(Guid uid)
        {
            _uow.TopicRepository.Delete(uid);
            _uow.Commit();

            return Index();
        }

    }
}