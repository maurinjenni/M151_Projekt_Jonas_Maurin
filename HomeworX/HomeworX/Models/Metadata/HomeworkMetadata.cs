using System.ComponentModel.DataAnnotations;
using System;

namespace HomeworX.Models.Metadata
{
    public class HomeworkMetadata
    {
        [Display(Name = "Wichtigkeit")]
        public Nullable<byte> Importance { get; set; }
    }
}