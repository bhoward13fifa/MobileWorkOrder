using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestWO.Models;
using TestWO.Services;
using TestWO.Views;
using Xamarin.Forms;

namespace TestWO.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private WorkOrderDBModel _selectedWorkOrder;

        public ObservableCollection<ViewWorkOrderModel> WorkOrders { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<WorkOrderDBModel> WorkOrderTapped { get; }

        IWorkOrderEndpoint _workOrderEndpoint;
        ICustomerEndpoint _customerEndpoint;

        private BindingList<CustomerModel> _customers;

        public BindingList<CustomerModel> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged("Customers");
            }
        }

        public ItemsViewModel()
        {
            Title = "Work Orders";

            WorkOrders = new ObservableCollection<ViewWorkOrderModel>();

            //WorkOrderTapped = new Command<WorkOrderDBModel>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);

            _workOrderEndpoint = DependencyService.Get<IWorkOrderEndpoint>();

            _customerEndpoint = DependencyService.Get<ICustomerEndpoint>();
        }

        public async Task LoadCustomers()
        {
            var customerList = await _customerEndpoint.GetAll();
            Customers = new BindingList<CustomerModel>(customerList);
        }

        public async Task LoadWorkOrders()
        {
            try
            {
                WorkOrders.Clear();
                var workOrders = await _workOrderEndpoint.GetAllWorkOrders();
                foreach (var workOrder in workOrders)
                {
                    ViewWorkOrderModel showWorkOrders = new ViewWorkOrderModel();
                    showWorkOrders.Display = "Work Order # " + workOrder.WorkOrderId.ToString() + "      Customer: " + Customers.FirstOrDefault(x => x.CustomerId == workOrder.CustomerId).CustomerName;
                    showWorkOrders.Date = "Date: " + workOrder.StartTime.ToString("d");
                    WorkOrders.Add(showWorkOrders);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async void OnAppearing()
        {
            await LoadCustomers();
            IsBusy = true;
            SelectedWorkOrder = null;
            await LoadWorkOrders();
        }

        public WorkOrderDBModel SelectedWorkOrder
        {
            get => _selectedWorkOrder;
            set
            {
                SetProperty(ref _selectedWorkOrder, value);
                //OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewWorkOrderPage));
        }

        //async void OnItemSelected(WorkOrderDBModel workOrder)
        //{
        //    if (workOrder == null)
        //        return;

        //    // This will push the ItemDetailPage onto the navigation stack
        //    await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={workOrder.WorkOrderId}");
        //}
    }
}