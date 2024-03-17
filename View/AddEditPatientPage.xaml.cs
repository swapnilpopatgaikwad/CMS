using CMS.ViewModel;

namespace CMS.View;

public partial class AddEditPatientPage : ContentPage//, IQueryAttributable
{
    public AddEditPatientPage(AddEditPatientViewModel addEditPatientViewModel)
    {
        InitializeComponent();
        BindingContext = addEditPatientViewModel;

    }

    //public void ApplyQueryAttributes(IDictionary<string, object> query)
    //{
    //    try
    //    {

    //        var dept = query["SelectedDepartment"] as Patient;
    //    }
    //    catch
    //    {

    //    }
    //}
}