using CMS.ViewModel;
namespace CMS.View;

public partial class UserProfile : ContentPage
{
	public UserProfile(UserProfileViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}