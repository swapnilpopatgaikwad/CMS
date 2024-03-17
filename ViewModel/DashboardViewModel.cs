using CMS.Constants;
using CMS.Interfaces;
using CMS.Popups;
using CMS.Services;
using CMS.Tables;
using CMS.View;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;

namespace CMS.ViewModel
{
    public partial class DashboardViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string loggedInUserName;

        [ObservableProperty]
        public int totalPatient;

        [ObservableProperty]
        public int totalNewPatient;

        [ObservableProperty]
        public double totalPaidAmount;

        [ObservableProperty]
        public double totalUnPaidAmount;


        private UserService _userService;
        public DashboardViewModel(IDataBaseService dataBaseService, UserService userService) : base(dataBaseService)
        {
            _userService = userService;
        }

        [RelayCommand]
        public async Task Appearing()
        {
            try
            {
                LoggedInUserName = await GetLoggedInUserName();
                TotalPatient = await GetTotalPatient();
                TotalNewPatient = await GetTotalNewPatient();
                //TODO: bind totalUnPaidAmount , totalPaidAmount

            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while loading Dashboard.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
            finally
            {

            }
        }

        private async Task<int> GetTotalPatient()
        {
            return await _dataBaseService.CountAsync<Patient>().ConfigureAwait(false);
        }

        private async Task<int> GetTotalNewPatient()
        {
            var toDayDate = DateTime.Now.ToString("yyyy-MM-dd");
            var query = $"SELECT COUNT(*) FROM {nameof(Patient)} WHERE DATE(CreatedDate) = '{toDayDate}'";
            return await _dataBaseService.CountAsync<Patient>(query).ConfigureAwait(false);
        }

        private async Task<string> GetLoggedInUserName()
        {
            var loginUserId = await _userService.GetCurrentLoginUserId().ConfigureAwait(false);
            if (loginUserId > 0)
            {
                var user = await _dataBaseService.FindAsync<Login>(loginUserId).ConfigureAwait(false);
                if (!string.IsNullOrEmpty(user.FirstName) || (!string.IsNullOrEmpty(user.LastName)))
                {
                    return user?.FirstName + " " + user?.LastName;
                }

                return user.Username;
            }
            return string.Empty;
        }

        [RelayCommand]
        public async Task UserProfile()
        {
            await Shell.Current.GoToAsync(nameof(UserProfile));
        }

        [RelayCommand]
        public async Task AddTreatment()
        {
            var sheet = new AddTreatementPage();
            await sheet.ShowAsync();
        }

        [RelayCommand]
        public async Task AddPatient()
        {
            await MopupService.Instance.PushAsync(new AddPatientsPopup(new AddPatientViewModel(_dataBaseService)));
        }
    }
}
