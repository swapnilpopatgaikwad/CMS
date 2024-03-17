using CMS.Interfaces;
using CMS.Model;
using CMS.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CMS.ViewModel
{
    public partial class AddUpdateMedicineViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        public MedicineModel medicineModel = new MedicineModel();
        public MedicineService MedicineService { get; set; }
        public AddUpdateMedicineViewModel(IDataBaseService dataBaseService, MedicineService medicineService) : base(dataBaseService)
        {
            MedicineService = medicineService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.Count > 0)
            {
                if (query.TryGetValue("IsAddMedicine", out object obj))
                {
                    if (obj is bool _isAddMedicine && _isAddMedicine)
                    {
                        MedicineModel = new MedicineModel();
                    }
                }

                if (query.TryGetValue("MedicineModel", out object obj1))
                {
                    if (obj1 is MedicineModel medicine)
                    {
                        MedicineModel = medicine;
                    }
                }
            }
        }


        [RelayCommand]
        public async Task SaveMedicine()
        {
            try
            {
                if (MedicineModel != null)
                {
                    if (string.IsNullOrEmpty(MedicineModel.MedicineName))
                    {
                        await Toast.Make("Medicine name is required.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                        return;
                    }

                    if (await MedicineService.AddOrUpdateMedicineAsync(MedicineModel.ToMedicine()))
                    {
                        var keyValues = new ShellNavigationQueryParameters(new Dictionary<string, object>());
                        keyValues.Add("IsReloadRequried", true);

                        await Toast.Make("Medicine saved successfully.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();

                        await Shell.Current.GoToAsync("..", keyValues);
                    }
                    else
                    {
                        await Toast.Make("An error occurred while saving Medicine.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                    }
                }
                else
                {
                    await Toast.Make("An error occurred while saving Medicine.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                }

            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while saving Medicine.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }
    }
}
