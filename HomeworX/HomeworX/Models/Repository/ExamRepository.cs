using HomeworX.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void UpdateTopicToAppointment(List<Guid> topicUIDs, Guid appointmentUID )
        {
            _context.TopicToAppointment.RemoveRange(_context.TopicToAppointment.Where(tta => tta.AppointmentUID == appointmentUID));

            foreach (var topicUID in topicUIDs)
            {
                _context.TopicToAppointment.Add(new TopicToAppointment()
                {
                    UID = Guid.NewGuid(),
                    AppointmentUID = appointmentUID,
                    TopicUID = topicUID
                });
            }
        }

        public void Delete(Guid uid)
        {
            Exam entityToDelete = _dbSet.Find(uid);

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