using System.Collections.Generic;

namespace HomeworX.Models
{
    public partial class Subject
    {
        public List<KeyValuePair<string, string>> IsValid()
        {
            if (string.IsNullOrEmpty(Code) || Code.Length < 2 || Code.Length > 10 || string.IsNullOrEmpty(Description) || Description.Length < 3 || Description.Length > 100)
            {
                List<KeyValuePair<string, string>> validationErrors = new List<KeyValuePair<string, string>>();

                if (string.IsNullOrEmpty(Code))
                {
                    validationErrors.Add(new KeyValuePair<string, string>("model.Code",
                        "Das Feld Code muss einen Wert haben"));
                }

                else if (Code.Length < 2)
                {
                    validationErrors.Add(new KeyValuePair<string, string>("model.Code",
                        "Das Feld Code muss mindestens 2 Zeichen haben"));
                }

                else if (Code.Length > 10)
                {
                    validationErrors.Add(new KeyValuePair<string, string>("model.Code",
                        "Das Feld Code darf maximal 10 Zeichen haben"));
                }

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

                return validationErrors;
            }

            return null;
        }
    }
}