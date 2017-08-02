//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobPortal.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Job
    {
        public int JobId { get; set; }
        public string Position { get; set; }
        public int Required_Experience { get; set; }
        public string Package { get; set; }
        public string Job_Description { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public int LocId { get; set; }
        public int CompId { get; set; }
        public int SkillsId { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Location Location { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
