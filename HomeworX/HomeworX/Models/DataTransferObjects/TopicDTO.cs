using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeworX.Models
{
    public partial class Topic
    {
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Description) || Description.Length < 3 || Description.Length > 100)
            {
                return false;
            }

            return true;
        }
    }
}