using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeworX.Models
{
    public partial class Exam 
    {
        public IEnumerable<Guid> Topics { get; set; }


        public List<KeyValuePair<string, string>> IsValid()
        {
            if ((!string.IsNullOrEmpty(Mailadress) && Time == null) || (Topics == null || !Topics.Any()))
            {
                List<KeyValuePair<string, string>> validationErrors = new List<KeyValuePair<string, string>>();

                if (!string.IsNullOrEmpty(Mailadress) && Time == null)
                {
                    validationErrors.Add(new KeyValuePair<string, string>("model.Time",
                        "Das Feld Time muss einen Wert haben, wenn eine Emailadresse eingegeben wird"));
                }

                if (Topics == null || !Topics.Any())
                {
                    validationErrors.Add(new KeyValuePair<string, string>("model.Topics",
                        "Das Feld Topics muss einen Wert haben"));
                }

                return validationErrors;
            }

            return null;
        }
    }
}