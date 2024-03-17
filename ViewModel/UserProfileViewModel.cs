using CMS.Constants;
using CMS.Enums;
using CMS.Interfaces;
using CMS.Model;
using CMS.Services;
using CMS.Tables;
using CMS.View;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CMS.ViewModel
{
    public partial class UserProfileViewModel : BaseViewModel
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
        public ImageSource? profileImageSource;

        [ObservableProperty]
        public string? hospitalImage;

        [ObservableProperty]
        public ImageSource? hospitalImageSource;

        public UserService UserService { get; set; }
        public CountryService CountryService { get; set; }
        public int UserId { get; set; }
        public UserProfileViewModel(IDataBaseService dataBaseService, UserService userService, CountryService countryService) : base(dataBaseService)
        {
            UserService = userService;
            CountryService = countryService;
        }

        [RelayCommand]
        public async Task Appearing()
        {
            try
            {
                UserId = await UserService.GetCurrentLoginUserId();

                if (UserId > 0)
                {
                    var userDetails = await FindUserDeatilsByIdAsync(UserId);

                    if (userDetails != null)
                    {
                        SetUserDetails(userDetails);
                    }
                }
            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while loading User Details.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
            finally
            {
            }
        }

        public void SetUserDetails(Login login)
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

            if (!string.IsNullOrEmpty(ProfileImage))
            {
                ProfileImageSource = ImageStringToImageSource(ProfileImage);
            }
            
            if (!string.IsNullOrEmpty(HospitalImage))
            {
                HospitalImageSource = ImageStringToImageSource(HospitalImage);
            }
        }

        private async Task<Login> FindUserDeatilsByIdAsync(int loginId)
        {
            var query = $"select * from {nameof(Login)} where Id = {loginId} ";
            var userDeatil = await _dataBaseService.QueryAsync<Login>(query).ConfigureAwait(false);

            if (userDeatil != null && userDeatil.Count>0)
            {
                return userDeatil.FirstOrDefault();
            }
            return null;
        }

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

        [RelayCommand]
        public async Task SaveUserDetails()
        {
            try
            {
                if (string.IsNullOrEmpty(FirstName))
                {
                    await Toast.Make("Name must required.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                    return;
                }
                if (string.IsNullOrEmpty(Email))
                {
                    await Toast.Make("Email must required.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                    return;
                }
                if (string.IsNullOrEmpty(MobileNumber))
                {
                    await Toast.Make("Mobile Number must required.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                    return;
                }

                var userDetails = ToLogin();
                if (userDetails != null)
                {
                    var result = await UpdateUserDetailsAsync(userDetails);
                    if (result)
                    {
                        await Toast.Make("User details saved successfully.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                        return;
                    }

                    await Toast.Make("An error occurred while saving User Details.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                }
            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while saving User Details.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }

        private async Task<bool> UpdateUserDetailsAsync(Login login)
        {
            var result = await _dataBaseService.UpdateItemAsync<Login>(login).ConfigureAwait(false);

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        [RelayCommand]
        public async Task TakeProfilePicture()
        {
            try 
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = "Take Profile Picture",
                });

                var image = ImageSource.FromStream(async (d) => await photo.OpenReadAsync());
                if (image!=null)
                {
                    ProfileImageSource = image;
                    ProfileImage = await ImageStreamToString(await photo.OpenReadAsync());
                }

            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while taking Picture.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }
        
        [RelayCommand]
        public async Task TakeHospitalPicture()
        {
            try 
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = "Take Hospital Picture",
                });

                var image = ImageSource.FromStream(async (d) => await photo.OpenReadAsync());
                if (image!=null)
                {
                    HospitalImageSource = image;
                    HospitalImage = await ImageStreamToString(await photo.OpenReadAsync());
                }
            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while taking Hospital Picture.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }

        public static ImageSource ImageStringToImageSource(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
                return null;

            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                Stream stream = new MemoryStream(imageBytes);
                return ImageSource.FromStream(() => stream);
            }
            catch (FormatException ex)
            {
                throw new FormatException("The provided string is not a valid base64 string.", ex);
            }
        }

        public static async Task<string> ImageStreamToString(Stream imageStream)
        {
            if (imageStream == null)
                throw new ArgumentNullException(nameof(imageStream));

            using (var memoryStream = new MemoryStream())
            {
                await imageStream.CopyToAsync(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        [RelayCommand]
        public async Task LogOut()
        {
            await SecureStorage.SetAsync(ConstantRecord.LoginUserId, (0).ToString());
            await SecureStorage.SetAsync(ConstantRecord.LoginStatus, Enum.GetName<LoginEnum>(LoginEnum.LogOut));
            Application.Current.MainPage = new LoginPage(HandlerService.GetService<LoginViewModel>());
        }
    }
}
