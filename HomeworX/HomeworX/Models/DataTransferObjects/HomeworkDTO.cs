using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeworX.Models
{
    public partial class Homework
    {
        public IEnumerable<Guid> Topics { get; set; }

        public List<KeyValuePair<string, string>> IsValid()
        {
            if ((Importance != null && (Importance < 0 || Importance > 255)) || (Topics == null || !Topics.Any()))
            {
                List<KeyValuePair<string, string>> validationErrors = new List<KeyValuePair<string, string>>();

                if (Importance != null)
                {
                    validationErrors.Add(new KeyValuePair<string, string>("model.Importance",
                        "Das Feld Importance muss einen Wert haben"));
                }

                else if (Importance < 0)
                {
                    validationErrors.Add(new KeyValuePair<string, string>("model.Importance",
                        "Das Feld Importance darf nicht negativ sein"));
                }


                else if (Importance > 255)
                {
                    validationErrors.Add(new KeyValuePair<string, string>("model.Importance",
                        "Das Feld Importance darf nicht grösser 255 sein"));
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