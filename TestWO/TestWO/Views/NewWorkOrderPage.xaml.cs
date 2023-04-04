using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using TestWO.Models;
using TestWO.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestWO.Views
{
    public partial class NewWorkOrderPage : ContentPage
    {
        private readonly NewWorkOrderViewModel viewModel;

        public NewWorkOrderPage()
        {
            InitializeComponent();
            viewModel = new NewWorkOrderViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            if(BindingContext is NewWorkOrderViewModel viewModel)
            {
                viewModel.OnAppeared();
            }
        }
    }
}