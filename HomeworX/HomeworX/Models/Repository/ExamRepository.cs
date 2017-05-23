using HomeworX.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeworX.Models;

namespace HomeworX.Models.Repository
{
    public class ExamRepository : GenericRepository<Exam> , IExamRepository
    {
        public ExamRepository(HomeworXEntities context) : base(context)
        {
            
        }
    }
}