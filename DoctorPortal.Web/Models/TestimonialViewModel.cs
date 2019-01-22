using System.ComponentModel.DataAnnotations;
using DoctorPortal.Web.Database;

namespace DoctorPortal.Web.Models
{
    public class TestimonialViewModel
    {
        public TestimonialViewModel()
        {

        }

        public TestimonialViewModel(Testimonial testimonial)
        {
            Id = testimonial.Id;
            HospitalId = testimonial.HospitalId;
            Name = testimonial.ClientName;
            Location = testimonial.Location;
            ClientImagePath = testimonial.ClientImagePath;
            Message = testimonial.Message;
        }

        public int Id { get; set; }
        public int HospitalId { get; set; }

        [Display(Name = @"Name")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string Name { get; set; }

        [Display(Name = @"Location")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string Location { get; set; }

        [Display(Name = @"Image path")]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(250, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string ClientImagePath { get; set; }

        [Display(Name = @"Message")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(250, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string Message { get; set; }

        public Testimonial GeTestimonialEntity()
        {
            return new Testimonial
            {
                Id = Id,
                HospitalId = HospitalId,
                ClientName = Name,
                Location = Location,
                ClientImagePath = ClientImagePath ?? Name,
                Message = Message
            };
        }
    }
}