//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeworX.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exam : IEntityUID
    {
        public System.Guid UID { get; set; }
        public bool Remind { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public string Mailadress { get; set; }
    
        public virtual Appointment Appointment { get; set; }
    }
}
