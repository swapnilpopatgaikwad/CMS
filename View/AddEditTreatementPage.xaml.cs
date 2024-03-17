using CMS.ViewModel;

namespace CMS.View;

public partial class AddEditTreatementPage : ContentPage
{
	public AddEditTreatementPage(AddTreatementViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}