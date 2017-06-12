using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeworX.Models.Metadata
{
    public class ExamMetadata
    {
        [EmailAddress()]
        [Display(Name = "Mail Adresse")]
        public string Mailadress { get; set; }

        [Display(Name = "Errinerung")]
        public bool Remind { get; set; }

        [Display(Name = "Errinerungsdatum")]
        public Nullable<System.DateTime> Time { get; set; }

        [Display(Name = "Themen")]
        [Required]
        public IEnumerable<Guid> Topics { get; set; }
    }
}