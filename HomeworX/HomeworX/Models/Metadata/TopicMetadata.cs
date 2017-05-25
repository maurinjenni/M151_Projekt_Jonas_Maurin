using System.ComponentModel.DataAnnotations;

namespace HomeworX.Models.Metadata
{
    public class TopicMetadata
    {
        [StringLength(100)]
        [MinLength(3)]
        [Display(Name = "Thema Titel")]
        public string Description { get; set; }

        [Display(Name = "Thema Detailbezeichnung")]
        public string Detail { get; set; }

        [Required]
        [Display(Name = "Fach")]
        public System.Guid SubjectUID { get; set; }
    }
}