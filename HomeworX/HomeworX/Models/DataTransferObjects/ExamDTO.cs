using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeworX.Models
{
    public partial class Exam 
    {
        public IEnumerable<Guid> Topics { get; set; }


        public bool IsValid()
        {
            if (!string.IsNullOrEmpty(Mailadress) && Time == null)
            {
                return false;
            }

            if(Topics == null || !Topics.Any())
            {
                return false;
            }

            return true;
        }
    }
}