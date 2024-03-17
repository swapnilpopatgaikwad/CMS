using CMS.Services;
using CMS.ViewModel;

namespace CMS.View;

public partial class ExpenceListView : ContentPage
{
	public ExpenceListView()
	{
		InitializeComponent();
		BindingContext = HandlerService.GetService<ExpenseViewModel>();
    }
}