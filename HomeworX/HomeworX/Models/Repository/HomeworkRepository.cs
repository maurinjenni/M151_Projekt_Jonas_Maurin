using HomeworX.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeworX.Models.Repository
{
    public class HomeworkRepository : GenericRepository<Homework> , IHomeworkRepository
    {
        public HomeworkRepository(HomeworXEntities context) : base(context)
        {
           
        }

        public void Delete(Guid uid)
        {
            Homework entityToDelete = _dbSet.Find(uid);

            if (entityToDelete != null)
            {
                if (_context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    _dbSet.Attach(entityToDelete);
                }
                _dbSet.Remove(entityToDelete);
            }
            else
            {
                throw new Exception("No Entity found to UID : " + uid);
            }

            Appointment entityToDelete2 = _context.Appointment.FirstOrDefault(a => a.UID == uid);

            if (entityToDelete2 != null)
            {
                if (_context.Entry(entityToDelete2).State == EntityState.Detached)
                {
                    _context.Appointment.Attach(entityToDelete2);
                }
                _context.Appointment.Remove(entityToDelete2);
            }
            else
            {
                throw new Exception("No Entity found to UID : " + uid);
            }
        }
    }
}