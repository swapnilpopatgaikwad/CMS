using CMS.Constants;
using CMS.Enums;
using CMS.Interfaces;
using CMS.Services;
using CMS.Tables;
using CMS.View;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CMS.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        public LoginViewModel(IDataBaseService dataBaseService) : base(dataBaseService)
        {
        }

        [RelayCommand]
        public async Task LoginUser()
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await Toast.Make("Email and Password must required.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                return;
            }

            var user = await LoginAsync(email.Trim(), password.Trim());
            if (user != null)
            {
                await SecureStorage.SetAsync(ConstantRecord.LoginUserId, user.Id.ToString());
                await SecureStorage.SetAsync(ConstantRecord.LoginStatus, Enum.GetName<LoginEnum>(LoginEnum.LoggedIn));
                await Toast.Make("Logged in successfully.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                await Toast.Make("User are not found.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                return;
            }
        }

        public async Task<Login> LoginAsync(string _email, string _password)
        {
            var users = await _dataBaseService.QueryAsync<Login>($"select * from {nameof(Login)} where Email = '{_email}' and Password = '{_password}' ").ConfigureAwait(false);
            if (users.Count > 0)
            {
                var user = users.FirstOrDefault();
                return user;
            }
            return null;
        }

        [RelayCommand]
        public void CreateAccount()
        {
            Application.Current.MainPage = new CreateAccountPage(HandlerService.GetService<CreateAccountViewModel>());
        }

        [RelayCommand]
        public void ForgotPassword()
        {
            Application.Current.MainPage = new ForgotPasswordPage();
        }
    }
}
