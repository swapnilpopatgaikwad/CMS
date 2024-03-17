using CMS.ViewModel;

namespace CMS.View;

public partial class TreatmentTabPage : ContentPage
{
	public TreatmentTabPage(TreatmentTabViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}