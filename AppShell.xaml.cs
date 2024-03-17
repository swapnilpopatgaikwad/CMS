using CMS.Services;
using CMS.ViewModel;

namespace CMS
{
    public partial class AppShell : Shell
    {
        bool isBackPressed = false;
        public AppShell()
        {
            InitializeComponent();

            var viewModel = HandlerService.GetService<MainViewModel>();
            BindingContext = viewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            if (!isBackPressed)
            {
                isBackPressed = true;
                MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    bool exitConfirmed = await DisplayAlert("Exit", "Do you really want to exit?", "Yes", "No");
                    if (exitConfirmed)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        isBackPressed = false;
                    }
                });
                return true; // Prevent default back button behavior
            }
            else
            {
                return base.OnBackButtonPressed();
            }
        }
    }
}
