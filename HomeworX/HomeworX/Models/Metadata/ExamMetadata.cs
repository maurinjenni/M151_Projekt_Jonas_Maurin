using System;
using System.ComponentModel.DataAnnotations;

namespace HomeworX.Models.Metadata
{
    public class ExamMetadata
    {
        [EmailAddress()]
        [Required]
        [Display(Name = "Mail Adresse")]
        public string Mailadress { get; set; }

        [Display(Name = "Errinerung")]
        public bool Remind { get; set; }

        [Display(Name = "Errinerungsdatum")]
        public Nullable<System.DateTime> Time { get; set; }
    }
}