using System.ComponentModel;
using TestWO.ViewModels;
using Xamarin.Forms;

namespace TestWO.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}