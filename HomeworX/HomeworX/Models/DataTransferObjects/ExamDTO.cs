using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeworX.Models
{
    public partial class Exam 
    {
        //public Guid ExamUID { get; set; }

        //public bool Remind { get; set; }

        //public DateTime RemindTime { get; set; }

        //public string Mailadress { get; set; }

        //public string AppointmentDescription { get; set; }

        //public string AppointmentDetail { get; set; }

        //public DateTime AppointmentDate { get; set; }

        //public Guid SubjectUID { get; set; }

        public IEnumerable<Guid> Topics { get; set; } 
    }
}