//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoctorPortal.Web.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Department
    {
        public int DepartmentId { get; set; }
        public int HospitalId { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public string BannerImage { get; set; }
    
        public virtual HospitalMaster HospitalMaster { get; set; }
    }
}
