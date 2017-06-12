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
    }
}