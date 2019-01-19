using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DoctorPortal.Web.Common;
using DoctorPortal.Web.Database;

namespace DoctorPortal.Web.Areas.Admin.Models.ViewModels
{
    public class HospitalInfoViewModel
    {
        public HospitalInfoViewModel()
        {
            WorkingHoursList = GetWorkingHoursList();
        }

        public int HospitalId { get; set; }

        [Display(Name = @"Hospital Name")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string HospitalName { get; set; }

        [Display(Name = @"Address Line 1")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(20, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string AddressLine1 { get; set; }

        [Display(Name = @"Address Line 2")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string AddressLine2 { get; set; }

        [Display(Name = @"Email")]
        [EmailAddress]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "StringLengthValidation")]
        public string Email { get; set; }

        [Display(Name = @"Working Hours From")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        public string WorkingHoursFrom { get; set; }

        [Display(Name = @"Working Hours From")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        public string WorkingHoursTo { get; set; }

        [Display(Name = @"Emergency Contact No")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        public string EmergencyContact { get; set; }

        [Display(Name = @"Hospital Contact No")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "RequiredField")]
        public string ContactNo { get; set; }

        public bool IsMonWorking { get; set; }
        public bool IsTueWorking { get; set; }
        public bool IsWedWorking { get; set; }
        public bool IsThurWorking { get; set; }
        public bool IsFriWorking { get; set; }
        public bool IsSatWorking { get; set; }
        public bool IsSunWorking { get; set; }

        public IList<KendoDropdownModel> WorkingHoursList { get; set; }

        public void SetWorkingDaysFromEntity(ICollection<HospitalWorkingDay> hospitalWorkingDays)
        {
            IsMonWorking = hospitalWorkingDays.FirstOrDefault(w => w.Day == 1) != null;
            IsTueWorking = hospitalWorkingDays.FirstOrDefault(w => w.Day == 2) != null;
            IsWedWorking = hospitalWorkingDays.FirstOrDefault(w => w.Day == 3) != null;
            IsThurWorking = hospitalWorkingDays.FirstOrDefault(w => w.Day == 4) != null; ;
            IsFriWorking = hospitalWorkingDays.FirstOrDefault(w => w.Day == 5) != null;
            IsSatWorking = hospitalWorkingDays.FirstOrDefault(w => w.Day == 6) != null;
            IsSunWorking = hospitalWorkingDays.FirstOrDefault(w => w.Day == 7) != null;
        }

        public ICollection<HospitalWorkingDay> GetHospitalWorkingDaysFromProperties()
        {
            var hospitalWorkingDays = new List<HospitalWorkingDay>();

            if (IsMonWorking)
                hospitalWorkingDays.Add(new HospitalWorkingDay { Day = 1, HospitalId = HospitalId });

            if (IsTueWorking)
                hospitalWorkingDays.Add(new HospitalWorkingDay { Day = 2, HospitalId = HospitalId });

            if (IsWedWorking)
                hospitalWorkingDays.Add(new HospitalWorkingDay { Day = 3, HospitalId = HospitalId });

            if (IsThurWorking)
                hospitalWorkingDays.Add(new HospitalWorkingDay { Day = 4, HospitalId = HospitalId });

            if (IsFriWorking)
                hospitalWorkingDays.Add(new HospitalWorkingDay { Day = 5, HospitalId = HospitalId });

            if (IsSatWorking)
                hospitalWorkingDays.Add(new HospitalWorkingDay { Day = 6, HospitalId = HospitalId });

            if (IsSunWorking)
                hospitalWorkingDays.Add(new HospitalWorkingDay { Day = 7, HospitalId = HospitalId });

            return hospitalWorkingDays;
        }

        private static IList<KendoDropdownModel> GetWorkingHoursList()
        {
            return Utility.GetWorkingHoursList().Select(s => new KendoDropdownModel(s, s)).ToList();
        }

    }
}