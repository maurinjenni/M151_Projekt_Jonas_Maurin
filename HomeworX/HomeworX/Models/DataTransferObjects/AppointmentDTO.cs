﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeworX.Models
{
    public partial class Appointment
    { 
        public List<KeyValuePair<string,string>> IsValid()
        {
            if (string.IsNullOrEmpty(Description) || Description.Length < 3 || Description.Length > 100)
            {
                List<KeyValuePair<string, string>> validationErrors = new List<KeyValuePair<string, string>>();

                if (string.IsNullOrEmpty(Description))
                {
                    validationErrors.Add(new KeyValuePair<string, string>("model.Description",
                        "Das Feld Description muss einen Wert haben"));
                }
                else if (Description.Length < 3)
                {
                    validationErrors.Add(new KeyValuePair<string, string>("model.Description",
                        "Das Feld Description muss mindestens 3 Zeichen haben"));
                }
                else if (Description.Length > 100)
                {
                    validationErrors.Add(new KeyValuePair<string, string>("model.Description",
                        "Das Feld Description darf maximal 100 Zeichen haben"));
                }

                if (Date == null || Date == DateTime.MinValue)
                {
                    validationErrors.Add(new KeyValuePair<string, string>("model.Date",
                        "Das Feld Date muss einen Wert haben"));
                }

                if (SubjectUID == null || Guid.Empty == SubjectUID)
                {
                    validationErrors.Add(new KeyValuePair<string, string>("model.SubjectUID",
                        "Das Feld SubjectUID muss einen Wert haben"));
                }

                return validationErrors;
            }

            return null;
        }
    }
}