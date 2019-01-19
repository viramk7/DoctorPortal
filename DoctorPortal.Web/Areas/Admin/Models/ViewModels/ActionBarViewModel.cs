namespace DoctorPortal.Web.Areas.Admin.Models.ViewModels
{
    public class ActionBarViewModel
    {
        public ActionBarViewModel(string backButtonControllerName = "AdminHome",
                                  string backButtonActionName = "Index",
                                  bool displaySaveButton = true,
                                  bool displaySaveAndContinueButton = false,
                                  bool displayBackButton = true)
        {
            BackButtonControllerName = backButtonControllerName;
            BackButtonActionName = backButtonActionName;

            DisplaySaveButton = displaySaveButton;
            DisplaySaveAndContinueButton = displaySaveAndContinueButton;
            DisplayBackButton = displayBackButton;
        }

        public bool DisplaySaveButton { get; set; }
        public bool DisplaySaveAndContinueButton { get; set; }
        public bool DisplayBackButton { get; set; }

        public string BackButtonControllerName { get; set; }
        public string BackButtonActionName { get; set; }

    }
}