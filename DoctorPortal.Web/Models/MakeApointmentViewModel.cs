using System;
using System.ComponentModel.DataAnnotations;
using DoctorPortal.Web.Common;
using DoctorPortal.Web.Database;

namespace DoctorPortal.Web.Models
{
    public class MakeAppointmentViewModel
    {
        [Required(ErrorMessage = "Please provide the name")]
        [MaxLength(50,ErrorMessage = "Name must only include 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide the email")]
        [MaxLength(50, ErrorMessage = "Email must only include 50 characters")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Please provide the message")]
        [MaxLength(250, ErrorMessage = "Message must only include 250 characters")]
        public string Message { get; set; }

        [MaxLength(150, ErrorMessage = "Subject must only include 250 characters")]
        public string Subject { get; set; }

        [MaxLength(15, ErrorMessage = "Phone no. must only include 15 characters")]
        public string PhoneNo { get; set; }

        public DateTime? Date { get; set; }

        // Returns the entity to save in the database
        public Appointment GetAppointmentEntity()
        {
            return new Appointment
            {
                HospitalId = WebHelper.HospitalId,
                Name = Name,
                Email = Email,
                Message = Message,
                Subject = Subject,
                PhoneNo = PhoneNo,
                Date = Date
            };
        }
    
    }
}