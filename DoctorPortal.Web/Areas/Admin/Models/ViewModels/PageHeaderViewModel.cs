namespace DoctorPortal.Web.Areas.Admin.Models.ViewModels
{
    public class PageHeaderViewModel
    {
        public PageHeaderViewModel()
        {
                
        }

        public PageHeaderViewModel(string pageName, string controllerName, string actionName)
        {
            PageName = pageName;
            ControllerName = controllerName;
            ActionName = actionName;
        }

        public string PageName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}