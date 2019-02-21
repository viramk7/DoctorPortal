using DoctorPortal.Web.Common;
using DoctorPortal.Web.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.Models
{
    public class FAQQuestionsViewModel
    {
        [Required(ErrorMessage = "Please provide the name")]
        [MaxLength(50, ErrorMessage = "Name must only include 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide the email")]
        [MaxLength(50, ErrorMessage = "Email must only include 50 characters")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide the Subject")]
        [MaxLength(250, ErrorMessage = "Subject must only include 250 characters")]
        public string Subject { get; set; }

        public string QuestionText { get; set; }

        public Nullable<int> DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public FAQQuestions GetFAQQuestionsEntity()
        {
            return new FAQQuestions
            {
                HospitalId = WebHelper.HospitalId,
                Name = Name,
                Email = Email,
                Subject = Subject,
                DepartmentId = DepartmentId,
                QuestionText = QuestionText
            };
        }
    }
}