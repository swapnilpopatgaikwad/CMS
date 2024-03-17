using CMS.Tables.Helper;
using SQLiteNetExtensions.Attributes;

namespace CMS.Tables
{
    public class Treatment : BaseTable
    {
        public int PatientId { get; set; }
        public string Remarks { get; set; }
        public string Complaint { get; set; }
        public string Examination { get; set; }
        public Double TotalFees { get; set; }
        public Double PaidFees { get; set; }
        public int ReportId { get; set; }
        public string ReferredDoctorName { get; set; }
        public string ReferredHospitalName { get; set; }
        public DateTime FolowUpDate { get; set; }
        public string Advice { get; set; }
        public string PrescriptionImageIds { get; set; }
        public string TreatmentImageIds { get; set; }

        public string LabCity { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double BloodPressure { get; set; }
        public double NumberOfPulse { get; set; }
        public double SPO2 { get; set; }
        public double Temperature { get; set; }

        public Treatment() { }
        public Treatment(TreatmentWithPatient treatment)
        {
            PatientId = treatment.Id;
            Remarks = treatment.Remarks;
            Complaint = treatment.Complaint;
            Examination = treatment.Examination;
            TotalFees = treatment.TotalFees;
            PaidFees = treatment.PaidFees;
            Advice = treatment.Advice;
            FolowUpDate = treatment.FolowUpDate;
            ReferredDoctorName = treatment.ReferredDoctorName;
            ReferredHospitalName = treatment.ReferredHospitalName;
            PrescriptionImageIds = treatment.PrescriptionImageIds;
            TreatmentImageIds = treatment.TreatmentImageIds;

            LabCity = treatment.LabCity;
            Height = treatment.Height;
            Weight = treatment.Weight;
            BloodPressure = treatment.BloodPressure;
            NumberOfPulse = treatment.NumberOfPulse;
            SPO2 = treatment.SPO2;
            Temperature = treatment.Temperature;
        }
    }
}
