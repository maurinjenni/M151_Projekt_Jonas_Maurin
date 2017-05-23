using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeworX.Models.IRepository;
using HomeworX.Models;
using HomeworX.Models.Repository;

namespace HomeworX.Models.RepositoryContract
{
    public class UnitOfWork
    {
        private HomeworXEntities _context;

        public UnitOfWork(HomeworXEntities context)
        {
            _context = context;

            ExamRepository = new ExamRepository(_context);
        }

        public IExamRepository ExamRepository { get; set; }


        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}