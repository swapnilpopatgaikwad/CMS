using CMS.Constants;
using CMS.Interfaces;
using CMS.Tables;
using CommunityToolkit.Maui.Alerts;
using System.Windows.Input;

namespace CMS.ViewModel
{
    public partial class AddEditPatientViewModel : BaseViewModel
    {
        private string patientName;
        public string PatientName
        {
            get { return patientName; }
            set
            {
                if (patientName != value)
                {
                    patientName = value;
                    OnPropertyChanged(nameof(PatientName));
                }
            }
        }

        private string contactNumber;
        public string ContactNumber
        {
            get { return contactNumber; }
            set
            {
                if (contactNumber != value)
                {
                    contactNumber = value;
                    OnPropertyChanged(nameof(ContactNumber));
                }
            }
        }


        private string emailAddress;
        public string EmailAddress
        {
            get { return emailAddress; }
            set
            {
                if (emailAddress != value)
                {
                    emailAddress = value;
                    OnPropertyChanged(nameof(EmailAddress));
                }
            }
        }

        private string age;
        public string Age
        {
            get { return age; }
            set
            {
                if (age != value)
                {
                    age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

        private string gender;
        public string Gender
        {
            get { return gender; }
            set
            {
                if (gender != value)
                {
                    gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                if (address != value)
                {
                    address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }


        private string country;
        public string Country
        {
            get { return country; }
            set
            {
                if (country != value)
                {
                    country = value;
                    OnPropertyChanged(nameof(Country));
                }
            }
        }

        private string state;
        public string State
        {
            get { return state; }
            set
            {
                if (state != value)
                {
                    state = value;
                    OnPropertyChanged(nameof(State));
                }
            }
        }


        private string city;
        public string City
        {
            get { return city; }
            set
            {
                if (city != value)
                {
                    city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        private string allergies;
        public string Allergies
        {
            get { return allergies; }
            set
            {
                if (allergies != value)
                {
                    allergies = value;
                    OnPropertyChanged(nameof(Allergies));
                }
            }
        }
        private string note;
        public string Note
        {
            get { return note; }
            set
            {
                if (note != value)
                {
                    note = value;
                    OnPropertyChanged(nameof(Note));
                }
            }
        }

        private bool isCovidVaccinated;
        public bool IsCovidVaccinated
        {
            get { return isCovidVaccinated; }
            set
            {
                if (isCovidVaccinated != value)
                {
                    isCovidVaccinated = value;
                    OnPropertyChanged(nameof(IsCovidVaccinated));
                }
            }
        }


        private bool isNotCovidVaccinated;
        public bool IsNotCovidVaccinated
        {
            get { return isNotCovidVaccinated; }
            set
            {
                if (isNotCovidVaccinated != value)
                {
                    isNotCovidVaccinated = value;
                    OnPropertyChanged(nameof(IsNotCovidVaccinated));
                }
            }
        }

        private bool isDiabeatic;
        public bool IsDiabeatic
        {
            get { return isDiabeatic; }
            set
            {
                if (isDiabeatic != value)
                {
                    isDiabeatic = value;
                    OnPropertyChanged(nameof(IsDiabeatic));
                }
            }
        }

        private bool isNonDiabeatic;
        public bool IsNonDiabeatic
        {
            get { return isNonDiabeatic; }
            set
            {
                if (isNonDiabeatic != value)
                {
                    isNonDiabeatic = value;
                    OnPropertyChanged(nameof(IsNonDiabeatic));
                }
            }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    OnPropertyChanged(nameof(IsBusy));
                }
            }
        }

        public ICommand SaveCommand { private set; get; }
        public ICommand AppearingCommand { private set; get; }
        public ICommand DisappearingCommand { private set; get; }

        private readonly IDataBaseService _dataBaseService;


        public AddEditPatientViewModel(IDataBaseService dataBaseService) : base(dataBaseService)
        {
            _dataBaseService = dataBaseService;
            SaveCommand = new Command(OnSave);
            AppearingCommand = new Command(OnAppearing);
            DisappearingCommand = new Command(OnDisappearing);
        }

        private void OnDisappearing(object obj)
        {

        }
        private void OnAppearing(object obj)
        {
            if (ConstantRecord.SelectedPatient != null)
            {
                PatientName = ConstantRecord.SelectedPatient.PatientName;
                ContactNumber = ConstantRecord.SelectedPatient.PatientContact;
                EmailAddress = ConstantRecord.SelectedPatient.Email;
                Age = ConstantRecord.SelectedPatient.Age;
                Gender = ConstantRecord.SelectedPatient.Gender;
                Address = ConstantRecord.SelectedPatient.Address;
                Country = ConstantRecord.SelectedPatient.Country;
                State = ConstantRecord.SelectedPatient.State;
                City = ConstantRecord.SelectedPatient.City;
                IsCovidVaccinated = ConstantRecord.SelectedPatient.IsCovidVaccinated;
                IsDiabeatic = ConstantRecord.SelectedPatient.IsDiabeatic;
                Allergies = ConstantRecord.SelectedPatient.Allergies;
                Note = ConstantRecord.SelectedPatient.Note;
            }
        }
        private async void OnSave(object obj)
        {
            try
            {
                IsBusy = true;

                if (ConstantRecord.SelectedPatient != null)
                {
                    //update existing record

                    var _patient = await _dataBaseService.FindAsync<Patient>(ConstantRecord.SelectedPatient.Id);

                    if (_patient.Id != 0)
                    {

                        var model = new Patient()
                        {
                            Id = _patient.Id,
                            PatientName = patientName,
                            PatientContact = contactNumber,
                            Email = emailAddress,
                            Age = age,
                            Gender = gender,
                            Address = address,
                            Country = country,
                            State = state,
                            City = city,
                            IsCovidVaccinated = (IsCovidVaccinated) ? IsCovidVaccinated : IsNotCovidVaccinated,
                            IsDiabeatic = (IsDiabeatic) ? IsDiabeatic : IsNonDiabeatic,
                            Allergies = allergies,
                            Note = note
                        };

                        await SaveData(model);

                    }
                }
                else
                {
                    var model = new Patient()
                    {
                        PatientName = patientName,
                        PatientContact = contactNumber,
                        Email = emailAddress,
                        Age = age,
                        Gender = gender,
                        Address = address,
                        Country = country,
                        State = state,
                        City = city,
                        IsCovidVaccinated = (IsCovidVaccinated) ? IsCovidVaccinated : IsNotCovidVaccinated,
                        IsDiabeatic = (IsDiabeatic) ? IsDiabeatic : IsNonDiabeatic,
                        Allergies = allergies,
                        Note = note
                    };

                    //add new entry
                    await SaveData(model);
                }

                await Shell.Current.Navigation.PopAsync();// .GoToAsync(nameof(AddEditPatientPage));

                ClearData();

            }
            catch
            { }

        }

        private async Task SaveData(Patient patient)
        {
            try
            {
                if (patient.Id != 0)
                {
                    var data = await _dataBaseService.UpdateItemAsync<Patient>(patient);
                    ConstantRecord.SelectedPatient = null;
                }

                else
                {

                    var data = await _dataBaseService.AddItemAsync<Patient>(patient);
                }
                isBusy = false;
                await Toast.Make("Patient data saved successfully.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();

            }
            catch { }

        }

        private void ClearData()
        {
            PatientName = string.Empty;
            ContactNumber = string.Empty;
            EmailAddress = string.Empty;
            Age = string.Empty;
            Gender = string.Empty;
            Address = string.Empty;
            Country = string.Empty;
            State = string.Empty;
            City = string.Empty;
            IsCovidVaccinated = false;
            IsDiabeatic = false;
            Allergies = string.Empty;
            Note = string.Empty;
        }
    }
}
