using CMS.Interfaces;

namespace CMS.ViewModel
{
    public partial class AppointmentTabViewModel : BaseViewModel
    {
        public AppointmentTabViewModel(IDataBaseService dataBaseService) : base(dataBaseService)
        {
        }
    }
}
