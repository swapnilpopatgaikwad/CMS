using CMS.Services;
using CMS.ViewModel;

namespace CMS.View.Menu;

public partial class MedicinePage : ContentPage
{
	public MedicinePage()
	{
		InitializeComponent();
		BindingContext = HandlerService.GetService<MedicineViewModel>();
	}
}