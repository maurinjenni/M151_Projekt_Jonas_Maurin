using System.ComponentModel.DataAnnotations;

namespace HomeworX.Models.Metadata
{
    public class ExamMetadata
    {
        [EmailAddress()]
        [Required]
        [Display(Name = "Mail Adresse")]
        public string Mailadress { get; set; }
    }
}