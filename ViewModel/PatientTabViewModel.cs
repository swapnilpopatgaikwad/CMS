using CMS.Interfaces;
using CMS.Tables;
using CMS.View;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CMS.ViewModel
{
    public partial class PatientTabViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string searchText;

        [ObservableProperty]
        public bool isPageloading;

        [ObservableProperty]
        public ObservableCollection<Patient> patients;

        [ObservableProperty]
        public int totalPatients;

        [ObservableProperty]
        private bool isRefreshing;

        [ObservableProperty]
        public Patient selectedPatient;

        public PatientTabViewModel(IDataBaseService dataBaseService) : base(dataBaseService)
        {
            _dataBaseService = dataBaseService;

            isRefreshing = false;
        }

        private async Task<int> FindTotalPatientsAsync()
        {
            return await _dataBaseService.CountAsync<Patient>().ConfigureAwait(false);
        }

        [RelayCommand]
        private async Task Appearing()
        {
            try
            {
                TotalPatients = await FindTotalPatientsAsync();

                Patients = new ObservableCollection<Patient>(await FetchPatientData(25, 1));
            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while loading Patient.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }

        [RelayCommand]
        private void Disappearing()
        {
            Patients.Clear();
        }

        [RelayCommand]
        private void Refresh()
        {
            IsRefreshing = false;
        }

        [RelayCommand]
        public async Task TextChanged()
        {
            try
            {
                IsPageloading = true;

                if (!string.IsNullOrEmpty(SearchText) && (!string.IsNullOrWhiteSpace(SearchText)))
                {
                    var _patients = await FetchPatientData(25, 1, SearchText);
                    Patients = new ObservableCollection<Patient>(_patients);
                }
                else
                {
                    var _patients = await FetchPatientData(25, 1);
                    Patients = new ObservableCollection<Patient>(_patients);
                }
            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while Searching Patient.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
            finally
            {
                IsPageloading = false;
            }
        }

        private async Task<IEnumerable<Patient>> FetchPatientData(int pageSize, int pageNumber, string searchText = "")
        {
            var query = $"SELECT * FROM {nameof(Patient)} " + (string.IsNullOrEmpty(SearchText) ? "" : $" where PatientName LIKE '%{searchText}%' ") +
                $" ORDER BY PatientName limit {pageNumber * pageSize} offset {pageNumber - 1}";

            var patients = await _dataBaseService.QueryAsync<Patient>(query).ConfigureAwait(false);
            
            return patients;
        }

        [RelayCommand]
        public async Task AddPatient()
        {
            await Shell.Current.GoToAsync(nameof(AddEditPatientPage));
        }

        [RelayCommand]
        public async Task EditPatient(Patient patient)
        {
            try
            {
                if (patient != null)
                {
                    var keyValues = new ShellNavigationQueryParameters(new Dictionary<string, object>())
                    {
                        { "patient", patient }
                    };
                    await Shell.Current.GoToAsync(nameof(AddEditPatientPage), keyValues);
                }
                else
                {
                    await Toast.Make("An error occurred while opening Patient.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                }

            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while opening Treatement.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }
    }
}
