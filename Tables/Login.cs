using CMS.Enums;

namespace CMS.Tables
{
    public class Login: BaseTable
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? MobileNumber { get; set; }
        public Gender? Gender { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? HospitalName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public int? Experience { get; set; }
        public string? ProfessionalBio { get; set; }
        public string? Specialties { get; set; }
        public string? StateMedicalCouncil { get; set; }
        public string? Languages { get; set; }
        public double? ConsultancyFees { get; set; }
        public string? IMRRegistrationNo { get; set; }

        public string? ProfileImage { get; set; }
        public string? HospitalImage { get; set; }

    }
}
