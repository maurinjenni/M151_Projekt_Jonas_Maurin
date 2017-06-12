using System.ComponentModel.DataAnnotations;
namespace HomeworX.Models.Metadata
{
    public class AppointmentMetadata
    {
        [Display(Name = "Bezeichnung")]
        [StringLength(100)]
        [MinLength(3)]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Beschreibung")]
        public string Detail { get; set; }

        [Display(Name = "Datum")]
        [Required]
        public System.DateTime Date { get; set; }

        [Display(Name = "Fach")]
        [Required]
        public System.Guid SubjectUID { get; set; }
    }
}