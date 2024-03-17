using CMS.Constants;
using CMS.Interfaces;
using CMS.Model;
using CMS.Services;
using CMS.Tables;
using CMS.View;
using CMS.View.Menu;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.ViewModel
{
    public partial class ExpenseViewModel : BaseViewModel, IQueryAttributable
    {
        public ExpenceService ExpenceService { get; set; }
        public UserService userService { get; set; }

        [ObservableProperty]
        private ObservableCollection<ExpenceModel> insertExpenseModelList = new ObservableCollection<ExpenceModel> { new ExpenceModel() };

        [ObservableProperty]
        public ObservableCollection<ExpenceModel> expenceModelList = new ObservableCollection<ExpenceModel>();

        [ObservableProperty]
        public ExpenceModel expenceModel;

        [ObservableProperty]
        private string searchText = string.Empty;

        [ObservableProperty]
        public bool isPageloading;

        public bool IsExpenceNameValid { get; set; }
        public bool IsAmountValid { get; set; }
        public ExpenseViewModel(IDataBaseService dataBaseService, ExpenceService _expenceService, UserService _userService) : base(dataBaseService)
        {
            ExpenceService = _expenceService;
            userService = _userService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.Count > 0)
            {
                if (query.TryGetValue("ExpenceModel", out object obj))
                {
                    if (obj is ExpenceModel expence)
                    {
                        ExpenceModel = expence;
                    }
                }
            }
        }

        [RelayCommand]
        public async Task Appearing()
        {
            try
            {
                var _expences = await ExpenceService.GetExpDetailAsync();
                ExpenceModelList = new ObservableCollection<ExpenceModel>(_expences.Select(x => x.ToExpenceModel()));
            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while loading Expence.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
            finally
            {
            }

        }

        public async Task<ExpenceModel> GetExpence(int Id)
        {
            try
            {
                var exp = await ExpenceService.GetExpDetailById(Id);
                if (exp != null)
                {
                    return exp.ToExpenceModel();
                }
            }
            catch (Exception ex)
            {
            }
            return new ExpenceModel();
        }

        [ObservableProperty]
        public bool isRefreshing;

        [RelayCommand]
        private async Task Refresh()
        {
            IsRefreshing = true;
            var _expences = await ExpenceService.GetExpDetailAsync();
            ExpenceModelList = new ObservableCollection<ExpenceModel>(_expences.Select(x=> x.ToExpenceModel()));
            IsRefreshing = false;
        }

        [RelayCommand]
        public async Task TextChanged()
        {
            try
            {
                IsPageloading = true;

                if (!string.IsNullOrEmpty(searchText) && (!string.IsNullOrWhiteSpace(searchText)))
                {
                    var _expences = await ExpenceService.GetExpDetailAsync(searchText);
                    ExpenceModelList = new ObservableCollection<ExpenceModel>(_expences.Select(x => x.ToExpenceModel()));
                }
                else
                {
                    var _expences = await ExpenceService.GetExpDetailAsync();
                    ExpenceModelList = new ObservableCollection<ExpenceModel>(_expences.Select(x => x.ToExpenceModel()));
                }
            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while Searching Treatment.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
            finally
            {
                IsPageloading = false;
            }
        }

        [RelayCommand]
        private async Task SubmitClick(object obj)
        {
            try
            {
                string message = string.Empty;
                if (InsertExpenseModelList.Any(a => string.IsNullOrEmpty(a.ExpenceName)))
                {
                    message = "Please enter expence name.";
                }

                if (!string.IsNullOrEmpty(message))
                {
                    await Toast.Make(message, CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                }
                else
                {
                    var addExpenses = InsertExpenseModelList.Where(x => x.Id == 0).ToList();

                    addExpenses.ForEach(async item =>
                    {
                        item.CreatedDate = DateTime.Now;
                        item.LastModifyDate = DateTime.Now;
                        item.CreatedBy = await userService.GetCurrentLoginUserId();//here i want to save login user id 
                        item.ModifiedBy = await userService.GetCurrentLoginUserId();
                    });

                    var retrunvalue = await ExpenceService.AddManyExpence(addExpenses.Select(x=> x.ToExpence()).ToList());
                    if (retrunvalue)
                    {
                        await Toast.Make("Expence saved successfully.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                        await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            insertExpenseModelList = new ObservableCollection<ExpenceModel>();
                        });
                    }
                    else
                    {
                        await Toast.Make("An error occurred while Saving Expence.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                    }
                }

            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while Saving Expence.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }

        [RelayCommand]
        private async Task UpdateClick(object obj)
        {
            try
            {
                if (obj is ExpenceModel expenceModel)
                {
                    string message = string.Empty;
                    if (string.IsNullOrEmpty(expenceModel.ExpenceName))
                    {
                        message = "Please enter expence name.";
                    }

                    if (!string.IsNullOrEmpty(message))
                    {
                        await Toast.Make(message, CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                    }
                    else
                    {
                        var retrunvalue = await ExpenceService.EditExpDetail(expenceModel.ToExpence());
                        if (retrunvalue)
                        {
                            await Toast.Make("Expence Updated Successfully", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                            await Shell.Current.GoToAsync("..");
                        }
                        else
                        {
                            await Toast.Make("An error occurred while Saving Expence.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                        }
                    }
                }
                else
                {
                    await Toast.Make("An error occurred while Saving Expence.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
                }
            }
            catch (Exception ex)
            {
                await Toast.Make("An error occurred while Saving Expence.", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            }
        }

        [RelayCommand]
        private async Task DeleteClick(object obj)
        {
            bool wantToDeleteRecord = await Application.Current.MainPage.DisplayAlert("Alert", "Do you really want to delete this expence?", "Yes", "No");
            if (wantToDeleteRecord)
            {
                Expence ob = new Expence() { Id = (int)obj };
                //var ob = obj as UserModel;
                var isSuccessfullyDeleted = await ExpenceService.DeleteExp(ob.Id);
                if (isSuccessfullyDeleted)
                {
                    await Application.Current.MainPage.DisplayAlert("Info", "Expence successfully deleted", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Info", "Expence successfully deleted", "OK");
                }

            }
            await Shell.Current.GoToAsync(nameof(ExpenceListView));
        }

        [RelayCommand]
        private async Task ExportClick(object obj)
        {
            //try
            //{
            //    bool isFileExported = Utilities.CsvUtilities.GenerateExpenceCsv(ListExpModel);
            //    if (isFileExported)
            //    {
            //        Application.Current.MainPage.DisplayAlert("Info", "File successfully exported", "OK");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }

        [RelayCommand]
        public async Task AddMore()
        {
            InsertExpenseModelList.Add(new ExpenceModel());
        }

        [RelayCommand]
        private async Task DeleteEntry(object obj)
        {
            if (obj is ExpenceModel expenceModel)
            {
                InsertExpenseModelList.Remove(expenceModel);
            }
        }

        private bool _isUpdateButtonClicked;

        public bool IsUpdateButtonClicked
        {
            get { return _isUpdateButtonClicked; }
            set { _isUpdateButtonClicked = value; }
        }

        [RelayCommand]
        private async Task UpdateExp(object sender)
        {
            try
            {
                if (sender is ExpenceModel value)
                {
                    var keyValues = new ShellNavigationQueryParameters(new Dictionary<string, object>());
                    keyValues.Add("ExpenceModel", value);
                    await Shell.Current.GoToAsync(nameof(UpdateExpenceView), keyValues);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }
    }
}
