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
    
    public partial class Testimonial
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string ClientName { get; set; }
        public string Location { get; set; }
        public string Message { get; set; }
        public string ClientImagePath { get; set; }
    
        public virtual HospitalMaster HospitalMaster { get; set; }
    }
}