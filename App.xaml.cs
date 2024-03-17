using CMS.Constants;
using CMS.Enums;
using CMS.Services;
using CMS.View;
using CMS.ViewModel;
using static SQLite.SQLite3;

namespace CMS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new LoginPage(HandlerService.GetService<LoginViewModel>());
            CheckLoginStatus();
        }

        private async void CheckLoginStatus()
        {
            await CheckAlredyLoginAsync();
        }

        private async Task CheckAlredyLoginAsync()
        {
            var status = await SecureStorage.GetAsync(ConstantRecord.LoginStatus);
            if (!string.IsNullOrEmpty(status) 
                && status == Enum.GetName<LoginEnum>(LoginEnum.LoggedIn))
            {
                MainPage = new AppShell();
            }
        }
    }
}
