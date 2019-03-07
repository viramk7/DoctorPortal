using System;
using System.ComponentModel.DataAnnotations;
using DoctorPortal.Web.Common;
using DoctorPortal.Web.Database;

namespace DoctorPortal.Web.Models
{
    public class MakeAppointmentViewModel
    {
        public MakeAppointmentViewModel()
        {

        }

        public MakeAppointmentViewModel(Appointment appointment)
        {
            Id = appointment.Id;
            HospitalId = appointment.HospitalId;
            Name = appointment.Name;
            Email = appointment.Email;
            Message = appointment.Message;
            Subject = appointment.Subject;
            PhoneNo = appointment.PhoneNo;
            Date = appointment.Date;
            ApprovedDate = appointment.ApprovedDate;
            IsApproved = appointment.IsApproved;
        }

        public int Id { get; set; }
        public int HospitalId { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public Nullable<bool> IsApproved { get; set; }

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

    public class ApproveAppointment
    {
        public ApproveAppointment(int id)
        {
            Id = id;
        }

        public ApproveAppointment(int id, DateTime approvalDate)
        {
            Id = id;
            ApproveDate = approvalDate;
        }

        public int Id { get; set; }
        public DateTime ApproveDate { get; set; }
    }
}