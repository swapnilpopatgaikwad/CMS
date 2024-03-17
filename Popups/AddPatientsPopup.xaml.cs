using CMS.ViewModel;
using Mopups.Pages;

namespace CMS.Popups;

public partial class AddPatientsPopup : PopupPage
{
    public AddPatientsPopup(AddPatientViewModel addPatientViewModel)
    {
        InitializeComponent();

        PatientNameEntry.Text = string.Empty;
        PatientContactEntry.Text = string.Empty;

        //BindingContext = addPatientViewModel;
    }
}