using CMS.Interfaces;
using CMS.Model;
using CMS.Services;
using CMS.Tables;
using CMS.Tables.Helper;
using CMS.View;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CMS.ViewModel
{
    public partial class TreatmentTabViewModel(IDataBaseService dataBaseService, IFileSaver fileSaver) : BaseViewModel(dataBaseService)
    {
        [ObservableProperty]
        public ObservableCollection<TreatementModel> treatmentList = [];

        [ObservableProperty]
        public int totalTreatments;

        [ObservableProperty]
        public bool isPageloading;

        public IFileSaver FileSaver { get; set; } = fileSaver;

        [ObservableProperty]
        public string searchText;
        partial void OnSearchTextChanging(string value)
        {
        }

        [RelayCommand]
        public async Task TextChanged()
        {
            try
            {
                IsPageloading = true;

                if (!string.IsNullOrEmpty(SearchText) && (!string.IsNullOrWhiteSpace(SearchText)))
                {
                    var _patients = await FetchTreatmentWithPatientData(25, 1, SearchText);
                    TreatmentList = new ObservableCollection<TreatementModel>(_patients);
                }
                else
                {
                    var _patients = await FetchTreatmentWithPatientData(25, 1);
                    TreatmentList = new ObservableCollection<TreatementModel>(_patients);
                }
            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while Searching Treatment.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
            finally
            {
                IsPageloading = false;
            }
        }

        [RelayCommand]
        public async Task Appearing()
        {
            try
            {
                IsPageloading = true;

                TotalTreatments = await FindTotalTreatmentsAsync();

                TreatmentList = new ObservableCollection<TreatementModel>(await FetchTreatmentWithPatientData(25, 1));

            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while loading Treatment.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
            finally
            {
                IsPageloading = false;
            }

        }

        private async Task<int> FindTotalTreatmentsAsync()
        {
            return await _dataBaseService.CountAsync<Treatment>().ConfigureAwait(false);
        }

        private async Task<IEnumerable<TreatementModel>> FetchTreatmentWithPatientData(int pageSize, int pageNumber, string searchText="")
        {
            var query = $"SELECT t.*, p.PatientName as PatientName FROM {nameof(Treatment)} t JOIN {nameof(Patient)} p ON t.PatientId = p.Id" +
                (string.IsNullOrEmpty(searchText) ? "" : $" where p.PatientName LIKE '%{searchText}%' ") +
                $" ORDER BY p.PatientName limit {pageNumber * pageSize} offset {pageNumber - 1}";

            var treatments = await _dataBaseService.QueryAsync<TreatmentWithPatient>(query).ConfigureAwait(false);
            if (treatments.Count > 0)
            {
                return treatments.Select(x => new TreatementModel(x));
            }
            return [];
        }

        [RelayCommand]
        public async Task AddTreatment()
        {
            var keyValues = new ShellNavigationQueryParameters(new Dictionary<string, object>())
            {
                { "IsAddTreatment", true }
            };
            await Shell.Current.GoToAsync(nameof(AddEditTreatementPage), keyValues);
        }

        [RelayCommand]
        public async Task EditTreatement(TreatementModel treatementModel)
        {
            try
            {
                if (treatementModel != null)
                {
                    var keyValues = new ShellNavigationQueryParameters(new Dictionary<string, object>())
                    {
                        { "TreatementModel", treatementModel }
                    };
                    await Shell.Current.GoToAsync(nameof(AddEditTreatementPage), keyValues);
                }
                else
                {
                    await Toast.Make("An error occurred while opening Treatement.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                }

            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while opening Treatement.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }
        
        [RelayCommand]
        public async Task DownloadTreatement(TreatementModel treatementModel)
        {
            try
            {
                if (treatementModel != null)
                {
                    var status = await PdfBuilderService.BuildPdfAsync(treatementModel).ConfigureAwait(false);
                }
                else
                {
                    await Toast.Make("An error occurred while downloading Treatement.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                }

            }
            catch (Exception)
            {
                await Toast.Make("An error occurred while downloading Treatement.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }
    }
}

