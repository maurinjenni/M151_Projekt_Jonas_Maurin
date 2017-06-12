using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeworX.Models.IRepository;

namespace HomeworX.Models.Repository
{
    public class TopicToAppointmentRepository : GenericRepository<TopicToAppointment>, ITopicToAppointmentRepository
    {
        public TopicToAppointmentRepository(HomeworXEntities context) : base(context)
        {

        }
    }
}