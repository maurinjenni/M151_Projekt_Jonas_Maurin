using HomeworX.Models;
using HomeworX.Models.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var homeworks = _uow.HomeworkRepository.Get();

            return View("Index", homeworks);
        }

        [Route("Homework/details/{uid}")]
        public ActionResult Details(Guid uid)
        {
            var homework = _uow.HomeworkRepository.Get(uid);

            return View("Details", homework);
        }

        [Route("Homework/create")]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Homework homework)
        {
            _uow.HomeworkRepository.Insert(homework);
            _uow.Commit();

            return View("Details", homework);
        }

        [Route("Homework/edit/{uid}")]
        public ActionResult Edit(Guid uid)
        {
            var homework = _uow.HomeworkRepository.Get(uid);

            return View("Edit", homework);
        }

        [HttpPost]
        public ActionResult Edit(Homework homework)
        {
            _uow.HomeworkRepository.Update(homework);
            _uow.Commit();

            return View("Details", homework);
        }

        [Route("Homework/delete/{uid}")]
        public ActionResult Delete(Guid uid)
        {
            _uow.HomeworkRepository.Delete(uid);
            _uow.Commit();

            return Index();
        }
    }   
}