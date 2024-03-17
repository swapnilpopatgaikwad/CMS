using CMS.Tables;
using CMS.Tables.Helper;
using CMS.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CMS.Model
{
    public partial class TreatementModel : BaseViewModel
    {
        [ObservableProperty]
        public int treatementId;

        [ObservableProperty]
        public int patientId;

        [ObservableProperty]
        public string patientName;

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
        public List<Prescription> prescriptions;

        [ObservableProperty]
        public int reportId;

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

        public TreatementModel()
        {
            Prescriptions = new();
        }

        public TreatementModel(TreatmentWithPatient treatment)
        {
            treatementId = treatment.Id;
            patientId = treatment.PatientId;
            patientName = treatment.PatientName;
            remarks = treatment.Remarks;
            complaint = treatment.Complaint;
            examination = treatment.Examination;
            totalFees = treatment.TotalFees;
            paidFees = treatment.PaidFees;
            advice = treatment.Advice;
            folowUpDate = treatment.FolowUpDate == DateTime.MinValue ? DateTime.Today : treatment.FolowUpDate;
            referredDoctorName = treatment.ReferredDoctorName;
            referredHospitalName = treatment.ReferredHospitalName;
            prescriptionImageIds = treatment.PrescriptionImageIds;
            treatmentImageIds = treatment.TreatmentImageIds;
            reportId = treatment.ReportId;

            labCity = treatment.LabCity;
            height = treatment.Height;
            weight = treatment.Weight;
            bloodPressure = treatment.BloodPressure;
            numberOfPulse = treatment.NumberOfPulse;
            sPO2 = treatment.SPO2;
            temperature = treatment.Temperature;
        }
    }
}
