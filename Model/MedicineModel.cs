using CMS.Tables;
using CMS.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CMS.Model
{
    public partial class MedicineModel : BaseViewModel
    {
        [ObservableProperty]
        public int medicineId;

        [ObservableProperty]
        public DateTime createdDate;

        [ObservableProperty]
        public DateTime lastModifyDate;

        [ObservableProperty]
        public string medicineName;

        [ObservableProperty]
        public string medicineDescription;

        public Medicine ToMedicine()
        {
            return new Medicine()
            {
                Id = MedicineId,
                CreatedDate = CreatedDate,
                LastModifyDate = LastModifyDate,
                MedicineName = MedicineName,
                MedicineDescription = MedicineDescription,
            };
        }
    }
}
