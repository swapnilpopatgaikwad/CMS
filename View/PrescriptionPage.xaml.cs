using CMS.ViewModel;

namespace CMS.View;

public partial class PrescriptionPage : ContentPage
{
	public PrescriptionPage(PrescriptionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}