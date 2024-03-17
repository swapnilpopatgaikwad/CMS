using CMS.Model;

namespace CMS.Tables
{
    public class Medicine : BaseTable 
    {
        public string MedicineName { get; set; }
        public string MedicineDescription { get; set; }

        public MedicineModel ToMedicineModel()
        {
            return new MedicineModel()
            {
                MedicineId = Id,
                CreatedDate = CreatedDate,
                LastModifyDate = LastModifyDate,
                MedicineName = MedicineName,
                MedicineDescription = MedicineDescription,
            };
        }
    }
}
