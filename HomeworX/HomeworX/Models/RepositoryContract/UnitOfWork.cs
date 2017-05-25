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
            HomeworkRepository = new HomeworkRepository(_context);
            SubjectRepository = new SubjectRepository(_context);
            TopicRepository = new TopicRepository(_context);
        }

        public IExamRepository ExamRepository { get; set; }

        public IHomeworkRepository HomeworkRepository { get; set; }

        public ISubjectRepository SubjectRepository { get; set; }

        public ITopicRepository TopicRepository { get; set; }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}