using System.ComponentModel.DataAnnotations;
using System;

namespace HomeworX.Models.Metadata
{
    public class HomeworkMetadata
    {
        [Display(Name = "Wichtigkeit")]
        [Range(0,255)]
        public Nullable<byte> Importance { get; set; }
    }
}