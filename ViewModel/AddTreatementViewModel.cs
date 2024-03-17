using CMS.Interfaces;
using CMS.Model;
using CMS.Services;
using CMS.Tables;
using CMS.View;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Collections.ObjectModel;
using The49.Maui.BottomSheet;

namespace CMS.ViewModel
{
    public partial class AddTreatementViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        public bool isAddTreatment;

        [ObservableProperty]
        public int treatementId;

        [ObservableProperty]
        public int patientId;

        [ObservableProperty]
        public string remarks;

        [ObservableProperty]
        public string complaint;

        [ObservableProperty]
        public string examination;

        [ObservableProperty]
        public Double totalFees;

        [ObservableProperty]
        public Double paidFees;

        [ObservableProperty]
        public int prescriptionId;

        [ObservableProperty]
        public string referredDoctorName;

        [ObservableProperty]
        public string referredHospitalName;

        [ObservableProperty]
        public DateTime folowUpDate;

        [ObservableProperty]
        public string advice;

        [ObservableProperty]
        public string prescriptionImageIds;

        [ObservableProperty]
        public string treatmentImageIds;

        [ObservableProperty]
        public string labCity;

        [ObservableProperty]
        public double height;

        [ObservableProperty]
        public double weight;

        [ObservableProperty]
        public double bloodPressure;

        [ObservableProperty]
        public double numberOfPulse;

        [ObservableProperty]
        public double sPO2;

        [ObservableProperty]
        public double temperature;


        //Validations

        [ObservableProperty]
        public bool isTotalFeesRequried;

        [ObservableProperty]
        public bool isPaidFeesRequried;

        [ObservableProperty]
        public bool isValidPatient;

        [ObservableProperty]
        public bool isPatientRequried;

        [ObservableProperty]
        public bool isPageloading;

        [ObservableProperty]
        public ObservableCollection<PrescriptionModel> prescriptions = new ObservableCollection<PrescriptionModel>();

        public bool HasAnyPrescription => (Prescriptions ??= new ObservableCollection<PrescriptionModel>()).Count > 0;

        public BottomSheet bottomSheet;


        [ObservableProperty]
        public ObservableCollection<Patient> searchPatients = new ObservableCollection<Patient>();

        [ObservableProperty]
        public string patientName;

        [ObservableProperty]
        public Patient selectedPatient;


        public Command<string> TextChangedFilterListCommand => new Command<string>(TextChanged);
        public AddTreatementViewModel()
        {
            _dataBaseService = HandlerService.GetService<IDataBaseService>();
            SelectedPatient = null;
        }

        public AddTreatementViewModel(IDataBaseService dataBaseService) : base(dataBaseService) { }

        partial void OnSelectedPatientChanged(Patient oldValue, Patient newValue)
        {
            if (newValue != null)
            {
                IsPatientRequried = false;
                PatientName = newValue.PatientName;
            }

            if (newValue == null)
            {
                IsPatientRequried = true;
                PatientName = string.Empty;
            }
        }

        [RelayCommand]
        public async Task Appearing()
        {
            try
            {
                IsPageloading = true;

                if (!string.IsNullOrEmpty(PatientName) || PatientId > 0)
                {
                    SelectedPatient = await FindPatientByIdAsync(PatientId);
                }

                if (TreatementId > 0)
                {
                    Prescriptions = new ObservableCollection<PrescriptionModel>(await FindPrescriptionsByTreatementIdAsync(TreatementId));
                }
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

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.Count > 0)
            {
                if (query.TryGetValue("IsAddTreatment", out object obj))
                {
                    if (obj is bool _isAddTreatment)
                    {
                        if (_isAddTreatment)
                        {
                            Prescriptions ??= new ObservableCollection<PrescriptionModel>();
                        }
                    }
                }

                if (query.TryGetValue("Prescription", out object obj1))
                {
                    if (obj1 is Prescription _prescription)
                    {
                        Prescriptions ??= new();
                        var prescriptionModel = Prescriptions.FirstOrDefault(x => x.PrescriptionId == _prescription.Id);
                        if (prescriptionModel == null)
                        {
                            Prescriptions.Add(new PrescriptionModel(_prescription));
                            OnPropertyChanged(nameof(HasAnyPrescription));
                        }
                        else
                        {
                            prescriptionModel.Dosage = _prescription.Dosage;
                            prescriptionModel.MealType = _prescription.MealType;
                            prescriptionModel.DurationType = _prescription.DurationType.HasValue ? Enum.GetName(typeof(Enums.DurationType), _prescription.DurationType) : null;
                            prescriptionModel.MedicineName = _prescription.MedicineName;
                        }
                    }
                }

                if (query.TryGetValue("TreatementModel", out object obj2))
                {
                    if (obj2 is TreatementModel _treatementModel)
                    {
                        TreatementId = _treatementModel.TreatementId;
                        PatientId = _treatementModel.PatientId;
                        PatientName = _treatementModel.PatientName;
                        Remarks = _treatementModel.Remarks;
                        Complaint = _treatementModel.Complaint;
                        Examination = _treatementModel.Examination;
                        TotalFees = _treatementModel.TotalFees;
                        PaidFees = _treatementModel.PaidFees;
                        ReferredDoctorName = _treatementModel.ReferredDoctorName;
                        ReferredHospitalName = _treatementModel.ReferredHospitalName;
                        FolowUpDate = _treatementModel.FolowUpDate;
                        Advice = _treatementModel.Advice;
                        PrescriptionImageIds = _treatementModel.PrescriptionImageIds;
                        TreatmentImageIds = _treatementModel.TreatmentImageIds;
                        LabCity= _treatementModel.LabCity;
                        Height= _treatementModel.Height;
                        Weight= _treatementModel.Weight;
                        BloodPressure= _treatementModel.BloodPressure;
                        NumberOfPulse= _treatementModel.NumberOfPulse;
                        SPO2= _treatementModel.SPO2;
                        Temperature= _treatementModel.Temperature;
                    }
                }
            }
        }

        partial void OnPrescriptionsChanged(ObservableCollection<PrescriptionModel> value)
        {
            OnPropertyChanged(nameof(HasAnyPrescription));
        }

        partial void OnTotalFeesChanging(Double value)
        {
            if (value > 0)
            {
                IsTotalFeesRequried = false;
            }
            else
            {
                IsTotalFeesRequried = true;
            }
        }

        partial void OnPaidFeesChanging(Double value)
        {
            if (value > 0)
            {
                IsPaidFeesRequried = false;
            }
            else
            {
                IsPaidFeesRequried = true;
            }
        }

        [RelayCommand]
        public async Task AddPatient()
        {
            await Shell.Current.GoToAsync(nameof(AddEditPatientPage));
        }

        public async void TextChanged(string filter)
        {
            try
            {
                if (!string.IsNullOrEmpty(filter) && (!string.IsNullOrWhiteSpace(filter)))
                {
                    var _patients = await FindPatientAsync(filter);
                    SearchPatients = new ObservableCollection<Patient>(_patients);

                    if (SearchPatients.Count == 0)
                    {
                        SelectedPatient = null;
                        PatientName = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private async Task<List<Patient>> FindPatientAsync(string patientName)
        {
            var query = $"select * from {nameof(Patient)} where PatientName LIKE '%{patientName}%' ";
            var _patients = await _dataBaseService.QueryAsync<Patient>(query).ConfigureAwait(false);
            return _patients;
        }

        private async Task<List<PrescriptionModel>> FindPrescriptionsByTreatementIdAsync(int treatementId)
        {
            var query = $"select * from {nameof(Prescription)} where TreatmentId = {treatementId}";
            var _prescriptions = await _dataBaseService.QueryAsync<Prescription>(query).ConfigureAwait(false);
            if (_prescriptions != null && _prescriptions.Count > 0)
                return _prescriptions.Select(x => new PrescriptionModel(x)).ToList();

            return new();
        }

        private async Task<Patient> FindPatientByIdAsync(int patientId)
        {
            var _patient = await _dataBaseService.FindAsync<Patient>(patientId).ConfigureAwait(false);
            return _patient;
        }

        [RelayCommand]
        public async Task SaveTreatment()
        {
            try
            {
                if (SelectedPatient != null)
                {
                    if (TotalFees <= 0)
                    {
                        IsTotalFeesRequried = true;
                        await Toast.Make("Total Fees is required.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                        return;
                    }
                    else
                    {
                        IsTotalFeesRequried = false;
                    }

                    if (PaidFees <= 0)
                    {
                        IsPaidFeesRequried = true;
                        await Toast.Make("Paid Fees is required.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                        return;
                    }
                    else
                    {
                        IsPaidFeesRequried = false;
                    }

                    var treatment = new Treatment()
                    {
                        Id = TreatementId,
                        PatientId = SelectedPatient.Id,
                        Remarks = Remarks,
                        Complaint = Complaint,
                        Examination = Examination,
                        TotalFees = TotalFees,
                        PaidFees = PaidFees,
                        Advice = Advice,
                        FolowUpDate = DateTime.Now,
                        ReferredDoctorName = ReferredDoctorName,
                        ReferredHospitalName = ReferredHospitalName,
                        PrescriptionImageIds = PrescriptionImageIds,
                        TreatmentImageIds = TreatmentImageIds,
                        LabCity = LabCity,
                        Height = Height,
                        Weight = Weight,
                        BloodPressure = BloodPressure,
                        NumberOfPulse = NumberOfPulse,
                        SPO2 = SPO2,
                        Temperature = Temperature,
                    };


                    var status = await SaveTreatmentAsync(treatment);
                    if (status)
                    {
                        await Toast.Make("Treatment saved successfully.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();

                        if (bottomSheet != null)
                        {
                            await bottomSheet.DismissAsync();
                        }
                        else
                        {
                            await Shell.Current.GoToAsync("..");
                        }
                    }
                }
                else
                {
                    IsPatientRequried = true;
                    await Toast.Make("Please select patient.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                    return;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<bool> SaveTreatmentAsync(Treatment treatment)
        {
            try
            {
                if (treatment.Id > 0)
                {
                    var state = await _dataBaseService.UpdateItemAsync<Treatment>(treatment).ConfigureAwait(false);
                }
                else
                {
                    var state = await _dataBaseService.AddItemAsync<Treatment>(treatment).ConfigureAwait(false);
                }

                return true;
            }
            catch (Exception ex)
            {
            }

            await Toast.Make("An error occurred while Saving Treatment.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();

            return false;
        }

        [RelayCommand]
        public async void Cancel()
        {
            try
            {
                if (bottomSheet != null)
                {
                    await bottomSheet.DismissAsync();
                }
                else
                {
                    await Shell.Current.GoToAsync("..");
                }
            }
            catch (Exception ex)
            {

            }
        }

        [RelayCommand]
        public async Task EditPrescription(PrescriptionModel prescriptionModel)
        {
            try
            {
                if (prescriptionModel != null && TreatementId > 0)
                {
                    var treatment = new Treatment()
                    {
                        Id = TreatementId,
                        PatientId = SelectedPatient.Id,
                        Remarks = Remarks,
                        Complaint = Complaint,
                        Examination = Examination,
                        TotalFees = TotalFees,
                        PaidFees = PaidFees,
                        Advice = Advice,
                        FolowUpDate = DateTime.Now,
                        ReferredDoctorName = ReferredDoctorName,
                        ReferredHospitalName = ReferredHospitalName,
                        PrescriptionImageIds = PrescriptionImageIds,
                        TreatmentImageIds = TreatmentImageIds,
                        LabCity = LabCity,
                        Height = Height,
                        Weight = Weight,
                        BloodPressure = BloodPressure,
                        NumberOfPulse = NumberOfPulse,
                        SPO2 = SPO2,
                        Temperature = Temperature,
                    };

                    if (treatment.Id > 0)
                    {
                        TreatementId = treatment.Id;

                        var keyValues = new ShellNavigationQueryParameters(new Dictionary<string, object>());
                        keyValues.Add("Treatment", treatment);
                        keyValues.Add("PrescriptionId", prescriptionModel.PrescriptionId);
                        await Shell.Current.GoToAsync(nameof(PrescriptionPage), keyValues);
                    }
                    else
                    {
                        await Toast.Make("An error occurred while Saving Treatment.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                    }
                }
                else
                {
                    await Toast.Make("An error occurred while Opening Prescription.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                }
            }
            catch (Exception ex)
            {

            }
        }

        [RelayCommand]
        public async Task AddMedicine()
        {
            try
            {
                if (SelectedPatient != null)
                {

                    var treatment = new Treatment()
                    {
                        Id = TreatementId,
                        PatientId = SelectedPatient.Id,
                        Remarks = Remarks,
                        Complaint = Complaint,
                        Examination = Examination,
                        TotalFees = TotalFees,
                        PaidFees = PaidFees,
                        Advice = Advice,
                        FolowUpDate = DateTime.Now,
                        ReferredDoctorName = ReferredDoctorName,
                        ReferredHospitalName = ReferredHospitalName,
                        PrescriptionImageIds = PrescriptionImageIds,
                        TreatmentImageIds = TreatmentImageIds,
                        LabCity = LabCity,
                        Height = Height,
                        Weight = Weight,
                        BloodPressure = BloodPressure,
                        NumberOfPulse = NumberOfPulse,
                        SPO2 = SPO2,
                        Temperature = Temperature,
                    };

                    if (treatment.Id == 0)
                    {
                        var status = await SaveTreatmentAsync(treatment);
                        if (status && treatment.Id > 0)
                        {
                            TreatementId = treatment.Id;

                            var keyValues = new ShellNavigationQueryParameters(new Dictionary<string, object>())
                            {
                                { "Treatment", treatment }
                            };
                            await Shell.Current.GoToAsync(nameof(PrescriptionPage), keyValues);
                        }
                        else
                        {
                            await Toast.Make("An error occurred while Saving Treatment.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                        }
                    }
                    else
                    {
                        TreatementId = treatment.Id;

                        var keyValues = new ShellNavigationQueryParameters(new Dictionary<string, object>())
                        {
                            { "Treatment", treatment }
                        };
                        await Shell.Current.GoToAsync(nameof(PrescriptionPage), keyValues);
                    }
                }
                else
                {
                    IsPatientRequried = true;
                    await Toast.Make("Please select patient.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                    return;
                }

            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while Adding Medicine.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }
    }
}
