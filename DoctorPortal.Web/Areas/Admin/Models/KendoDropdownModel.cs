namespace DoctorPortal.Web.Areas.Admin.Models
{
    public class KendoDropdownModel
    {
        public KendoDropdownModel(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public string Text { get; set; }
        public string Value { get; set; }
    }
}