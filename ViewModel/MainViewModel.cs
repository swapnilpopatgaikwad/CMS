using CMS.Constants;
using CMS.Enums;
using CMS.Interfaces;
using CMS.Services;
using CMS.Tables;
using CMS.View;
using CommunityToolkit.Mvvm.Input;

namespace CMS.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {

        private UserService _userService;
        public MainViewModel(IDataBaseService dataBaseService, UserService userService) : base(dataBaseService)
        {
            _userService = userService;
        }

        [RelayCommand]
        public async Task LogOut()
        {
            await SecureStorage.SetAsync(ConstantRecord.LoginUserId, (0).ToString());
            await SecureStorage.SetAsync(ConstantRecord.LoginStatus, Enum.GetName<LoginEnum>(LoginEnum.LogOut));
            Application.Current.MainPage = new LoginPage(HandlerService.GetService<LoginViewModel>());
        }
        
        
        [RelayCommand]
        public async Task DeleteAccount()
        {
            var status = await Application.Current.MainPage.DisplayAlert("Confirmation", "Are you sure you want to delete your account?", "Yes", "No");
            if (status)
            {
                await _dataBaseService.DeleteItemAsync<Login>(await _userService.GetCurrentLoginUserId().ConfigureAwait(false)).ConfigureAwait(false);
                await SecureStorage.SetAsync(ConstantRecord.LoginUserId, (0).ToString());
                await SecureStorage.SetAsync(ConstantRecord.LoginStatus, Enum.GetName<LoginEnum>(LoginEnum.LogOut));
                Application.Current.MainPage = new LoginPage(HandlerService.GetService<LoginViewModel>());
            }
        }
    }
}
