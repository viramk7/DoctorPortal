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
    
    public partial class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public string ImageName { get; set; }
        public int SpecialityId { get; set; }
        public Nullable<bool> IsOnHomePage { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Speciality Speciality { get; set; }
    }
}
