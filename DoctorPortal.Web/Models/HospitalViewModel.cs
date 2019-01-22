using System.Collections.Generic;
using System.Linq;
using DoctorPortal.Web.Common;
using DoctorPortal.Web.Database;

namespace DoctorPortal.Web.Models
{
    public class HospitalViewModel
    {
        public HospitalViewModel()
        {
        }

        public HospitalViewModel(HospitalMaster hospital)
        {
            HospitalId = hospital.Id;
            Name = hospital.Name;
            AddressLine1 = hospital.AddressLine1;
            AddressLine2 = hospital.AddressLine2;
            Email = hospital.Email;
            WorkingHours = hospital.WorkingHoursFrom + " - " + hospital.WorkingHoursTo;
            
            ContactList = hospital.HospitalContacts;
            WorkingDaysList = hospital.HospitalWorkingDays;
            Testimonials = hospital.Testimonials.Select(s => new TestimonialViewModel(s)).ToList();
        }

        public int HospitalId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmergencyNo { get; set; }
        public string ContactNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string WorkingHours { get; private set; }
        public string WorkingDays { get; private set; }

        public IList<TestimonialViewModel> Testimonials { get; set; }

        public ICollection<HospitalWorkingDay> WorkingDaysList
        {
            set
            {
                var workingDaysList = value;
                var dayList = workingDaysList.OrderBy(o => o.Day).Select(s => Utility.GetDayFromDayNo(s.Day)).ToList();
                var commaSepDays = WorkingDays = Utility.GetCommaSeparatedStringFromListOfString(dayList);
                WorkingDays = Utility.GetShortWorkingDaysString(commaSepDays);
            }
        }

        public ICollection<HospitalContact> ContactList
        {
            set
            {
                var emergencyContact = string.Empty;
                var contactNos = string.Empty;

                var contacts = value;
                foreach (var contact in contacts)
                {
                    if (contact.IsEmergency)
                        emergencyContact += contact.ContactNo + ", ";
                    else
                        contactNos += contact.ContactNo + ", ";
                }
                
                if(!string.IsNullOrEmpty(emergencyContact))
                    emergencyContact = emergencyContact.TrimEnd(',',' ');

                if(!string.IsNullOrEmpty(contactNos))
                    contactNos = contactNos.TrimEnd(',', ' ');

                EmergencyNo = emergencyContact;
                ContactNo = contactNos;
            }
        }
        
    }
    
}