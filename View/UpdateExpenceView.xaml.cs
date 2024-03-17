using CMS.ViewModel;

namespace CMS.View;

public partial class UpdateExpenceView : ContentPage
{
	public UpdateExpenceView(ExpenseViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}