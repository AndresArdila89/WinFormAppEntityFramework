//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinFormAppEntityFramework.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjectAssignment
    {
        public int EmployeeId { get; set; }
        public string ProjectCode { get; set; }
        public System.DateTime StatingDate { get; set; }
        public System.DateTime EndingDate { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}