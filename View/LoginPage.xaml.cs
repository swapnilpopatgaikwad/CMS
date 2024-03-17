using CMS.ViewModel;

namespace CMS.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage(LoginViewModel viewModel )
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}