using CMS.Enums;
using CMS.Tables;
using CMS.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CMS.Model
{
    public partial class PrescriptionModel : BaseViewModel
    {
        [ObservableProperty]
        public int prescriptionId;

        [ObservableProperty]
        public int treatmentId;

        [ObservableProperty]
        public int medicineId;

        [ObservableProperty]
        public string medicineName;

        [ObservableProperty]
        public string dosage;

        [ObservableProperty]
        public string? medicineType;

        [ObservableProperty]
        public int duration;

        [ObservableProperty]
        public string? durationType;

        [ObservableProperty]
        public int quantity;

        [ObservableProperty]
        public MealType? mealType;

        [ObservableProperty]
        public string note;


        [ObservableProperty]
        public List<string> durationTypes;

        [ObservableProperty]
        public List<string> medicineTypes;

        [ObservableProperty]
        public bool isMedicineNameRequried;

        [ObservableProperty]
        public bool? isAfterMealSelected;

        public PrescriptionModel()
        {
            DurationTypes = Enum.GetValues(typeof(DurationType)).Cast<DurationType>().Select(x => Enum.GetName(typeof(DurationType), x)).ToList();
            MedicineTypes = Enum.GetValues(typeof(MedicineType)).Cast<MedicineType>().Select(x => Enum.GetName(typeof(MedicineType), x)).ToList();
        }

        public PrescriptionModel(Prescription prescription) : base()
        {
            DurationTypes = Enum.GetValues(typeof(DurationType)).Cast<DurationType>().Select(x=> Enum.GetName(typeof(DurationType), x)).ToList();
            MedicineTypes = Enum.GetValues(typeof(MedicineType)).Cast<MedicineType>().Select(x => Enum.GetName(typeof(MedicineType), x)).ToList();

            TreatmentId = prescription.TreatmentId;
            PrescriptionId = prescription.Id;
            MedicineName = prescription.MedicineName;
            Dosage = prescription.Dosage;
            MedicineType = prescription.MedicineType.HasValue?Enum.GetName(typeof(Enums.MedicineType), prescription.MedicineType) :null;
            Duration = prescription.Duration;
            DurationType = prescription.DurationType.HasValue ? Enum.GetName(typeof(Enums.DurationType), prescription.DurationType) : null;
            Quantity = prescription.Quantity;
            MealType = prescription.MealType;
            Note = prescription.Note;

            if (MealType != null)
            {
                isAfterMealSelected = MealType == Enums.MealType.After ? true : false;
            }
        }

        public Prescription ToPrescription()
        {
            return new Prescription()
            {

                TreatmentId = this.TreatmentId,
                Id = this.PrescriptionId,
                MedicineId=this.MedicineId,
                MedicineName = this.MedicineName,
                Dosage = this.Dosage,
                MedicineType = string.IsNullOrEmpty(this.MedicineType) ? null : (MedicineType)Enum.Parse(typeof(Enums.MedicineType), this.MedicineType),
                Duration = this.Duration,
                DurationType = string.IsNullOrEmpty(this.DurationType) ? null : (DurationType)Enum.Parse(typeof(Enums.DurationType), this.DurationType),
                Quantity = this.Quantity,
                MealType = this.MealType,
                Note = this.Note,
            };
        }

        partial void OnIsAfterMealSelectedChanged(bool? oldValue, bool? newValue)
        {
            if (newValue != null)
            {
                MealType = newValue.Value ? Enums.MealType.After : Enums.MealType.Before;
            }
        }

        partial void OnMedicineNameChanged(string oldValue, string newValue)
        {
            if (newValue.Length > 0)
            {
                IsMedicineNameRequried = false;
            }
            else
            {
                IsMedicineNameRequried = true;
            }
        }

        [RelayCommand]
        public async Task MealSelected(string mealSelected)
        {
            if (bool.TryParse(mealSelected, out bool result))
            {
                IsAfterMealSelected = result;
            }
        }
    }
}
