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
    
    public partial class HospitalWorkingDay
    {
        public int HospitalId { get; set; }
        public byte Day { get; set; }
    
        public virtual HospitalMaster HospitalMaster { get; set; }
    }
}
