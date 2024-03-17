using CMS.ViewModel;

namespace CMS.View;

public partial class AddUpdateMedicinePage : ContentPage
{
	public AddUpdateMedicinePage(AddUpdateMedicineViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}