using System;
using System.Collections.Generic;
using TestWO.ViewModels;
using TestWO.Views;
using Xamarin.Forms;

namespace TestWO
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewWorkOrderPage), typeof(NewWorkOrderPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
