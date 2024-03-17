using CMS.Interfaces;
using CMS.Services;
using CMS.Tables;
using CMS.View;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CMS.ViewModel
{
    public partial class ForgotPasswordViewModel : BaseViewModel
    {

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string confirmPassword;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        bool isCancelVisible;

        public ForgotPasswordViewModel(IDataBaseService dataBaseService) : base(dataBaseService)
        {
        }

        [RelayCommand]
        public async Task Appearing()
        {
            try
            {
                if (Application.Current.MainPage.GetType() == typeof(ForgotPasswordPage))
                {
                    IsCancelVisible = true;
                    Title = "Forgot Password";
                }
                else
                {
                    IsCancelVisible = false;
                    Title = "Change Password";
                }

            }
            catch (Exception ex)
            {
            }
        }

        [RelayCommand]
        public async Task SavePassword()
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
                {
                    await Toast.Make("Email and Password must required.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                    return;
                }

                var status = await ForgotPasswordAsync(confirmPassword.Trim(), password.Trim(), email.Trim());
                if (status)
                {
                    await Toast.Make("Password changed successfully.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();

                    if (IsCancelVisible)
                    {
                        Application.Current.MainPage = new LoginPage(HandlerService.GetService<LoginViewModel>());
                        return;
                    }
                    else
                    {
                        await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
                    }
                }
            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while Saving Prescription.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }

        public async Task<bool> ForgotPasswordAsync(string confirmPassword, string password, string email)
        {
            try
            {
                var exsitingUsers = await _dataBaseService.QueryAsync<Login>($"select * from {nameof(Login)} where Email = '{email}' ").ConfigureAwait(false);

                if (exsitingUsers.Count == 0)
                {
                    await Toast.Make("This email account is not found.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                    return false;
                }
                var user = exsitingUsers.FirstOrDefault();

                user.Password = password;

                var state = await _dataBaseService.UpdateItemAsync<Login>(user).ConfigureAwait(false);

                return true;
            }
            catch (Exception ex)
            {
            }

            await Toast.Make("An error occurred while creating an account.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();

            return false;
        }

        [RelayCommand]
        public async Task Cancel()
        {
            Application.Current.MainPage = new LoginPage(HandlerService.GetService<LoginViewModel>());
            await Task.FromResult(true);
        }
    }
}
