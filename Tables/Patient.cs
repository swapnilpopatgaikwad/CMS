namespace CMS.Tables
{
    public class Patient : BaseTable
    {
        public string PatientName { get; set; }
        public string PatientContact { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public bool IsCovidVaccinated { get; set; }
        public bool IsDiabeatic { get; set; }
        public string Allergies { get; set; }
        public string Note { get; set; }
    }
}
