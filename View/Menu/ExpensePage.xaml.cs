using CMS.Services;
using CMS.ViewModel;

namespace CMS.View.Menu;

public partial class ExpensePage : ContentPage
{
	public ExpensePage()
	{
		InitializeComponent();
        BindingContext = HandlerService.GetService<ExpenseViewModel>();
    }
}