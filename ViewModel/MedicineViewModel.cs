using CMS.Interfaces;
using CMS.Model;
using CMS.Services;
using CMS.View;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CMS.ViewModel
{
    public partial class MedicineViewModel : BaseViewModel
    {
        [ObservableProperty]
        public int totalMedicines;

        [ObservableProperty]
        public ObservableCollection<MedicineModel> medicines = new ObservableCollection<MedicineModel>();

        public MedicineService MedicineService { get; set; }

        public bool IsReloadRequried { get; set; }
        public MedicineViewModel(IDataBaseService dataBaseService, MedicineService medicineService) : base(dataBaseService)
        {
            MedicineService = medicineService;
            IsReloadRequried = true;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.Count > 0)
            {
                if (query.TryGetValue("IsReloadRequried", out object obj))
                {
                    if (obj is bool isReloadRequried && isReloadRequried)
                    {
                        IsReloadRequried = isReloadRequried;
                    }
                }
            }
        }

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
                if (!string.IsNullOrEmpty(searchText) && (!string.IsNullOrWhiteSpace(searchText)))
                {
                    var medicineModels = await MedicineService.GetAllMedicinesOrByNameAsync(searchText);
                    Medicines = new ObservableCollection<MedicineModel>(medicineModels);
                }
                else
                {
                    var medicineModels = await MedicineService.GetAllMedicinesOrByNameAsync();
                    Medicines = new ObservableCollection<MedicineModel>(medicineModels);
                }
            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while searching Medicine.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
            finally
            {
            }
        }


        [RelayCommand]
        public async Task Appearing()
        {
            try
            {
                TotalMedicines = await MedicineService.FindTotalMedicinesAsync();

                if (IsReloadRequried )
                {
                    var medicineModels = await MedicineService.GetAllMedicinesOrByNameAsync();
                    Medicines = new ObservableCollection<MedicineModel>(medicineModels);
                }
            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while loading Medicine.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
            finally
            {
                IsReloadRequried = false;
            }
        }

        [RelayCommand]
        public async Task AddMedicine()
        {
            try
            {
                IsReloadRequried = true;
                var keyValues = new ShellNavigationQueryParameters(new Dictionary<string, object>());
                keyValues.Add("IsAddMedicine", true);
                await Shell.Current.GoToAsync(nameof(AddUpdateMedicinePage), keyValues);
            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while adding Medicine.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
            finally
            {
            }
        }

        [RelayCommand]
        public async Task EditMedicine(MedicineModel medicineModel)
        {
            try
            {
                if (medicineModel != null)
                {
                    var keyValues = new ShellNavigationQueryParameters(new Dictionary<string, object>());
                    keyValues.Add("MedicineModel", medicineModel);
                    await Shell.Current.GoToAsync(nameof(AddUpdateMedicinePage), keyValues);
                }
                else
                {
                    await Toast.Make("An error occurred while opening Medicine.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                }

            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while opening Medicine.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }

        [RelayCommand]
        public async Task DeleteMedicine(MedicineModel medicineModel)
        {
            try
            {
                if (medicineModel != null)
                {
                    if (await MedicineService.DeleteMedicineAsync(medicineModel.MedicineId))
                    {
                        TotalMedicines = await MedicineService.FindTotalMedicinesAsync();
                        await Toast.Make("Medicine deleted successfully.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                        Medicines.Remove(medicineModel);
                    }
                    else
                    {
                        await Toast.Make("An error occurred while deleting Medicine.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                    }
                }
                else
                {
                    await Toast.Make("An error occurred while deleting Medicine.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                }

            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while deleting Medicine.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }
    }
}
