using CMS.Tables;
using CMS.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CMS.Model
{
    public partial class ExpenceModel : BaseViewModel
    {
        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public string expenceName;

        [ObservableProperty]
        public string amount;

        [ObservableProperty]
        public DateTime createdDate;
        [ObservableProperty]
        public DateTime lastModifyDate;

        [ObservableProperty]
        public int createdBy;

        [ObservableProperty]
        public int modifiedBy;

        public Expence ToExpence()
        {
            return new Expence()
            {
                Id = Id,
                ExpenceName = ExpenceName,
                Amount = Amount,
                CreatedDate=CreatedDate,
                LastModifyDate = LastModifyDate,
                CreatedBy = CreatedBy,
                ModifiedBy = ModifiedBy
            };
        }
    }
}
