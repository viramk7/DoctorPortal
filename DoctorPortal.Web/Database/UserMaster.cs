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
    
    public partial class UserMaster
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsSystemGeneratedPassword { get; set; }
        public int RoleId { get; set; }
        public bool IsSuperAdmin { get; set; }
        public int HospitalId { get; set; }
    
        public virtual HospitalMaster HospitalMaster { get; set; }
    }
}
