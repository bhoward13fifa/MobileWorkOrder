using System;
using TestWO.Services;
using TestWO.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestWO
{
    public partial class App : Application
    {

        public App()
        {
            DevExpress.XamarinForms.DataGrid.Initializer.Init();

            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
