using CMS.Interfaces;
using CMS.Model;
using CMS.Services;
using CMS.Tables;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using zoft.MauiExtensions.Core.Extensions;

namespace CMS.ViewModel
{
    public  partial class PrescriptionViewModel : BaseViewModel,IQueryAttributable
    {
        [ObservableProperty]
        public PrescriptionModel prescriptionModel;

        [ObservableProperty]
        public bool isEditView;

        [ObservableProperty]
        public Treatment treatment;
        public int PrescriptionId { get; set; }

        [ObservableProperty]
        public int treatmentId;


        [ObservableProperty]
        private ObservableCollection<MedicineModel> filteredList = new ObservableCollection<MedicineModel>();

        [ObservableProperty]
        private MedicineModel selectedItem;
        public MedicineService MedicineService { get; set; }
        public Command<string> TextChangedFilterListCommand => new Command<string>(TextChangedFilterList);
        public PrescriptionViewModel()
        {
            _dataBaseService = HandlerService.GetService<IDataBaseService>();
            MedicineService = HandlerService.GetService<MedicineService>();

            SelectedItem = null;
        }

        public async void TextChangedFilterList(string filter)
        {
            SelectedItem = null;
            FilteredList.Clear();
            if (!string.IsNullOrEmpty(filter))
            {
                var medicineModels = await MedicineService.GetAllMedicinesOrByNameAsync(filter);
                FilteredList.AddRange(medicineModels);
            }
        }

        partial void OnSelectedItemChanged(MedicineModel oldValue, MedicineModel newValue)
        {
            if (newValue != null)
            {
                PrescriptionModel.MedicineId = newValue.MedicineId;
                PrescriptionModel.MedicineName = newValue.MedicineName;
            }
        }

        [RelayCommand]
        public async Task Appearing()
        {
            try
            {
                if (PrescriptionId == 0)
                {
                    PrescriptionModel = new PrescriptionModel();
                    PrescriptionModel.TreatmentId = TreatmentId;
                    SelectedItem = null;
                }
                else
                {
                    PrescriptionModel = await GetPrescriptionModelAsync(TreatmentId, PrescriptionId).ConfigureAwait(false);
                    if (PrescriptionModel != null && PrescriptionModel.MedicineId > 0)
                    {
                        SelectedItem = await MedicineService.GetMedicineByIdAsync(PrescriptionModel.MedicineId);
                    }
                }

            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while loading Prescription.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
            finally
            {

            }
        }

        public async Task<PrescriptionModel> GetPrescriptionModelAsync(int treatmentId, int prescriptionId)
        {
            var query = $"Select * from {nameof(Prescription)} where Id = {prescriptionId} and TreatmentId = {treatmentId}";
            var models = await _dataBaseService.QueryAsync<Prescription>(query).ConfigureAwait(false);
            return new PrescriptionModel(models.FirstOrDefault());
        }

        [RelayCommand]
        public async Task SavePrescription()
        {
            try
            {
                if (string.IsNullOrEmpty(PrescriptionModel.MedicineName) || PrescriptionModel.MedicineName.Length <= 0)
                {
                    PrescriptionModel.IsMedicineNameRequried = true;
                    await Toast.Make("Medicine Name is required.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                    return;
                }
                else
                {
                    PrescriptionModel.IsMedicineNameRequried = false;
                }
                var prescription = PrescriptionModel.ToPrescription();
                var status = await SavePrescriptionAsync(prescription);
                if (status)
                {
                    await Toast.Make("Prescription saved successfully.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();

                    var keyValues = new ShellNavigationQueryParameters(new Dictionary<string, object>());
                    keyValues.Add("Prescription", prescription);
                    await Shell.Current.GoToAsync("..", keyValues);
                }
            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while Saving Prescription.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }

        public async Task<bool> SavePrescriptionAsync(Prescription prescription)
        {
            try
            {
                if (prescription.Id > 0)
                {
                    var state = await _dataBaseService.UpdateItemAsync<Prescription>(prescription).ConfigureAwait(false);
                }
                else
                {
                    var state = await _dataBaseService.AddItemAsync<Prescription>(prescription).ConfigureAwait(false);
                }

                return true;
            }
            catch (Exception ex)
            {
            }

            await Toast.Make("An error occurred while Saving Prescription.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();

            return false;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.Count > 0)
            {
                if (query.TryGetValue("Treatment", out object obj))
                {
                    if (obj is Treatment _treatment)
                    {
                        Treatment = _treatment;
                        TreatmentId = _treatment.Id;
                    }
                }
                
                if (query.TryGetValue("PrescriptionId", out object obj1))
                {
                    if (obj1 is int _prescriptionId)
                    {
                        PrescriptionId = _prescriptionId;
                    }
                }
            }
        }

        partial void OnTreatmentChanged(Treatment value)
        {
            TreatmentId = value.Id;
        }

        [RelayCommand]
        public async void Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
