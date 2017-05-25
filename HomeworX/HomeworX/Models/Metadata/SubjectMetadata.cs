using System.ComponentModel.DataAnnotations;

namespace HomeworX.Models.Metadata
{
    public class SubjectMetadata
    {
        [StringLength(10)]
        [MinLength(2)]
        [Required]
        [Display(Name = "Fach Code")]
        public string Code { get; set; }

        [StringLength(100)]
        [MinLength(3)]
        [Required]
        [Display(Name = "Fach Titel")]
        public string Description { get; set; }

        [Display(Name = "Fach Detailbezeichnung")]
        public string Detail { get; set; }
    }
}