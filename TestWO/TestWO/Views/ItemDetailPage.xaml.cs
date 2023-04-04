using System.ComponentModel;
using TestWO.ViewModels;
using Xamarin.Forms;

namespace TestWO.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        private readonly ItemDetailViewModel viewModel;
        public ItemDetailPage()
        {
            InitializeComponent();
            viewModel = new ItemDetailViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            if (BindingContext is ItemDetailViewModel viewModel)
            {
                viewModel.OnAppeared();
            }
        }
    }
}