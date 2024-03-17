using CMS.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CMS.ViewModel
{
    public partial class BaseViewModel: ObservableObject
    {
        [ObservableProperty]
        public bool isPageLoading;

        protected IDataBaseService _dataBaseService;
        public BaseViewModel() { }
        public BaseViewModel(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
            //_dataBaseService = HandlerService.GetService<IDataBaseService>();
        }
    }
}
