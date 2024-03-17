using CMS.ViewModel;
using Mopups.Pages;
using The49.Maui.BottomSheet;

namespace CMS.Popups;

public partial class AddTreatementPage : BottomSheet
{
	public AddTreatementPage()
    {
        InitializeComponent();
        var vm = new AddTreatementViewModel();
        vm.IsAddTreatment = true;
        BindingContext = vm;
        vm.bottomSheet = this;
    }
}