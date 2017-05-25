using System.ComponentModel.DataAnnotations;
namespace HomeworX.Models.Metadata
{
    public class AppointmentMetadata
    {
        [Display(Name = "Bezeichnung")]
        public string Description { get; set; }

        [Display(Name = "Beschreibung")]
        public string Detail { get; set; }

        [Display(Name = "Datum")]
        public System.DateTime Date { get; set; }

        [Display(Name = "Fach")]
        public System.Guid SubjectUID { get; set; }
    }
}