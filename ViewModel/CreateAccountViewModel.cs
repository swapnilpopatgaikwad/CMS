using CMS.Interfaces;
using CMS.Services;
using CMS.Tables;
using CMS.View;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CMS.ViewModel
{
    public partial class CreateAccountViewModel: BaseViewModel
    {
        [ObservableProperty]
        string name;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string email; 

        public CreateAccountViewModel(IDataBaseService dataBaseService) : base(dataBaseService)
        {
        }

        [RelayCommand]
        public async Task Save()
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                await Toast.Make("Name, Email and Password must required.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                return;
            }

            var status = await CreateUserAsync(name.Trim(), password.Trim(), email.Trim());
            if (status)
            {
                await Toast.Make("Account created successfully.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();

                Application.Current.MainPage = new LoginPage(HandlerService.GetService<LoginViewModel>());
                return;
            }
        }

        public async Task<bool> CreateUserAsync(string name, string password, string email)
        {
            try
            {
                var exsitingUsers = await _dataBaseService.QueryAsync<Login>($"select * from {nameof(Login)} where Email = '{email}' ").ConfigureAwait(false);

                if (exsitingUsers.Count>0)
                {
                    await Toast.Make("This email is already associated with an existing account.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                    return false;
                }
                var user = new Login()
                {
                    FirstName = name,
                    Username = name,
                    Email = email,
                    Password = password,
                };
                var state = await _dataBaseService.AddItemAsync<Login>(user).ConfigureAwait(false);

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
