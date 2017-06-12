using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeworX.Models
{
    public partial class Appointment
    {
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Description) || Description.Length < 3 || Description.Length > 10)
            {
                return false;
            }

            if (TopicToAppointment == null)
            {
                return false;
            }

            return true;
        }
    }
}