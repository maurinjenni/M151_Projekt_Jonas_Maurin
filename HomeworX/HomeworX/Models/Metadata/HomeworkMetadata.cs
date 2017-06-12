using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace HomeworX.Models.Metadata
{
    public class HomeworkMetadata
    {
        [Display(Name = "Wichtigkeit")]
        [Range(0,255)]
        public Nullable<byte> Importance { get; set; }

        [Display(Name = "Themen")]
        [Required]
        public IEnumerable<Guid> Topics { get; set; }
    }
}