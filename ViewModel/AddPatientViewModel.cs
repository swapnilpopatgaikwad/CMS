using CMS.Interfaces;

namespace CMS.ViewModel
{
    public partial class AddPatientViewModel : BaseViewModel
    {
        public AddPatientViewModel(IDataBaseService dataBaseService) : base(dataBaseService)
        {
        }
    }
}
