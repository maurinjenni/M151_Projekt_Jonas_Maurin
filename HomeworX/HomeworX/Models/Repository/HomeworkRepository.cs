using HomeworX.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeworX.Models.Repository
{
    public class HomeworkRepository : GenericRepository<Homework> , IHomeworkRepository
    {
        public HomeworkRepository(HomeworXEntities context) : base(context)
        {

        }
    }
}