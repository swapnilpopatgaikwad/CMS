using CMS.Enums;
using CMS.Tables;
using CMS.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CMS.Model
{
    public partial class UserModel : BaseViewModel
    {
        [ObservableProperty]
        public int loginId;

        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public string password;

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string firstName;

        [ObservableProperty]
        public string lastName;

        [ObservableProperty]
        public DateTime? lastLogin;

        [ObservableProperty]
        public string? mobileNumber;

        [ObservableProperty]
        public Gender? gender;

        [ObservableProperty]
        public DateOnly? birthDate;

        [ObservableProperty]
        public string? hospitalName;

        [ObservableProperty]
        public string? address;

        [ObservableProperty]
        public string? country;

        [ObservableProperty]
        public string? state;

        [ObservableProperty]
        public string? city;

        [ObservableProperty]
        public int? experience;

        [ObservableProperty]
        public string? professionalBio;

        [ObservableProperty]
        public string? specialties;

        [ObservableProperty]
        public string? stateMedicalCouncil;

        [ObservableProperty]
        public string? languages;

        [ObservableProperty]
        public double? consultancyFees;

        [ObservableProperty]
        public string? iMRRegistrationNo;


        [ObservableProperty]
        public string? profileImage;

        [ObservableProperty]
        public string? hospitalImage;

        public Login ToLogin()
        {
            return new Login()
            {
                Id = LoginId,
                Username = Username,
                Password = Password,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                LastLogin = LastLogin,
                MobileNumber = MobileNumber,
                Gender = Gender,
                BirthDate = BirthDate,
                HospitalName = HospitalName,
                Address = Address,
                Country = Country,
                State = State,
                City = City,
                Experience = Experience,
                ProfessionalBio = ProfessionalBio,
                Specialties = Specialties,
                StateMedicalCouncil = StateMedicalCouncil,
                Languages = Languages,
                ConsultancyFees = ConsultancyFees,
                IMRRegistrationNo = IMRRegistrationNo,

                ProfileImage = ProfileImage,
                HospitalImage = HospitalImage,

            };
        }

        public UserModel()
        {
        }
        public UserModel(Login login)
        {
            LoginId = login.Id;
            Username = login.Username;
            Password = login.Password;
            Email = login.Email;
            FirstName = login.FirstName;
            LastName = login.LastName;
            LastLogin = login.LastLogin;
            MobileNumber = login.MobileNumber;
            Gender = login.Gender;
            BirthDate = login.BirthDate;
            HospitalName = login.HospitalName;
            Address = login.Address;
            Country = login.Country;
            State = login.State;
            City = login.City;
            Experience = login.Experience;
            ProfessionalBio = login.ProfessionalBio;
            Specialties = login.Specialties;
            StateMedicalCouncil = login.StateMedicalCouncil;
            Languages = login.Languages;
            ConsultancyFees = login.ConsultancyFees;
            IMRRegistrationNo = login.IMRRegistrationNo;

            ProfileImage = login.ProfileImage;
            HospitalImage = login.HospitalImage;
        }
    }
}
