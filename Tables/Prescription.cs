using CMS.Enums;
using CMS.Model;

namespace CMS.Tables
{
    public class Prescription : BaseTable
    {
        public int TreatmentId { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public MedicineType? MedicineType { get; set; }
        public int Duration { get; set; }
        public DurationType? DurationType { get; set; }
        public int Quantity { get; set; }
        public MealType? MealType { get; set; }
        public string Note { get; set; }
    }
}
