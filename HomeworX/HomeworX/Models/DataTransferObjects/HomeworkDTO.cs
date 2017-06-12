using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeworX.Models
{
    public partial class Homework
    {
        public IEnumerable<Guid> Topics { get; set; }

        public bool IsValid()
        {
            if (Importance != null && (Importance < 0 || Importance > 255))
            {
                return false;
            }

            return true;
        }
    }
}