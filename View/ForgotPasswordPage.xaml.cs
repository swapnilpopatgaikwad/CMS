using CMS.Services;
using CMS.ViewModel;

namespace CMS.View;

public partial class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage()
    {
        InitializeComponent();
        BindingContext = HandlerService.GetService<ForgotPasswordViewModel>();
    }
}