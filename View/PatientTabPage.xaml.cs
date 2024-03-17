using CMS.ViewModel;

namespace CMS.View;

public partial class PatientTabPage : ContentPage
{
	public PatientTabPage(PatientTabViewModel patientTabViewModel)
    {
        InitializeComponent();
        BindingContext = patientTabViewModel;
    }
}