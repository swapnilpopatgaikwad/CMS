using CMS.Interfaces;
using CMS.Popups;
using CMS.Services;
using CMS.View;
using CMS.ViewModel;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui.Storage;
using Microsoft.Maui.LifecycleEvents;
using Mopups.Hosting;
using Mopups.Interfaces;
using Mopups.Services;
using QuestPDF.Infrastructure;
using The49.Maui.BottomSheet;
using CMS.View.Menu;
using zoft.MauiExtensions.Controls;

namespace CMS
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseBottomSheet()
                .ConfigureMopups()
                .UseZoftAutoCompleteEntry()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcon");
                });

            builder.ConfigureLifecycleEvents(events =>
            {
#if ANDROID
                events.AddAndroid(android => android.OnCreate((activity, bundle) => ChangeStatusBarColor(activity)));
                static void ChangeStatusBarColor(Android.App.Activity activity)
                {
                    if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
                    {
                        activity.Window.SetStatusBarColor(Android.Graphics.Color.ParseColor(Microsoft.Maui.Graphics.Colors.Green.ToHex()));
                    }
                }
#endif
            });


            builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);

            builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);

            builder.Services.AddSingleton<IDataBaseService, DataBaseService>();
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<CountryService>();
            builder.Services.AddSingleton<ExpenceService>();
            builder.Services.AddSingleton<MedicineService>();

            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddSingleton<CreateAccountViewModel>();
            builder.Services.AddSingleton<CreateAccountPage>();

            builder.Services.AddSingleton<ForgotPasswordViewModel>();
            builder.Services.AddSingleton<ForgotPasswordPage>();

            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<LoginPage>();

            builder.Services.AddSingleton<DashboardViewModel>();
            builder.Services.AddSingleton<DashboardPage>();

            builder.Services.AddSingleton<UserProfileViewModel>();
            builder.Services.AddSingleton<UserProfile>();

            builder.Services.AddSingleton<PatientTabViewModel>();
            builder.Services.AddSingleton<PatientTabPage>();

            builder.Services.AddSingleton<TreatmentTabViewModel>();
            builder.Services.AddSingleton<TreatmentTabPage>();

            builder.Services.AddSingleton<ReportTabViewModel>();
            builder.Services.AddSingleton<ReportTabPage>();

            builder.Services.AddSingleton<AppointmentTabViewModel>();
            builder.Services.AddSingleton<AppointmentTabPage>();

            builder.Services.AddSingleton<AddPatientViewModel>();
            builder.Services.AddSingleton<AddPatientsPopup>();

            builder.Services.AddSingleton<AddEditPatientPage>();
            builder.Services.AddSingleton<AddEditPatientViewModel>();

            builder.Services.AddTransient<AddEditTreatementPage>();
            builder.Services.AddTransient<AddTreatementViewModel>();

            builder.Services.AddTransient<PrescriptionPage>();
            builder.Services.AddTransient<PrescriptionViewModel>();

            builder.Services.AddTransient<UserFeedbackPage>();
            builder.Services.AddTransient<UserFeedbackViewModel>();

            builder.Services.AddTransient<MedicinePage>();
            builder.Services.AddTransient<MedicineViewModel>();

            builder.Services.AddTransient<AddUpdateMedicinePage>();
            builder.Services.AddTransient<AddUpdateMedicineViewModel>();

            builder.Services.AddTransient<ExpensePage>();
            builder.Services.AddTransient<ExpenceListView>();
            builder.Services.AddTransient<UpdateExpenceView>();
            builder.Services.AddTransient<ExpenseViewModel>();

            //#if DEBUG
            //            builder.Logging.AddDebug();
            //#endif

            //Register Routes
            RegisterRoutes();

            QuestPDF.Settings.License = LicenseType.Community;

            return builder.Build();
        }

        public static void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(CreateAccountPage), typeof(CreateAccountPage));
            Routing.RegisterRoute(nameof(ForgotPasswordPage), typeof(ForgotPasswordPage));
            Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
            Routing.RegisterRoute(nameof(UserProfile), typeof(UserProfile));
            Routing.RegisterRoute(nameof(AddEditTreatementPage), typeof(AddEditTreatementPage));
            Routing.RegisterRoute(nameof(AddEditPatientPage), typeof(AddEditPatientPage));
            Routing.RegisterRoute(nameof(AddTreatementPage), typeof(AddTreatementPage));
            Routing.RegisterRoute(nameof(PrescriptionPage), typeof(PrescriptionPage));
            Routing.RegisterRoute(nameof(ExpensePage), typeof(ExpensePage));
            Routing.RegisterRoute(nameof(ExpenceListView), typeof(ExpenceListView));
            Routing.RegisterRoute(nameof(UpdateExpenceView), typeof(UpdateExpenceView));
            Routing.RegisterRoute(nameof(MedicinePage), typeof(MedicinePage));
            Routing.RegisterRoute(nameof(UserFeedbackPage), typeof(UserFeedbackPage));
            Routing.RegisterRoute(nameof(AddUpdateMedicinePage), typeof(AddUpdateMedicinePage));
        }
    }
}
