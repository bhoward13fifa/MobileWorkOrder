using System;
using System.ComponentModel;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestWO.Models;
using TestWO.Services;
using Xamarin.Forms;

namespace TestWO.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel, INotifyPropertyChanged
    {

        IProductEndpoint _productEndpoint = DependencyService.Get<IProductEndpoint>();
        IEmployeeEndpoint _employeeEndpoint = DependencyService.Get<IEmployeeEndpoint>();
        IWorkOrderEndpoint _workOrderEndpoint = DependencyService.Get<IWorkOrderEndpoint>();

        private async Task LoadProducts()
        {
            var productList = await _productEndpoint.GetAll();
            Products = new BindingList<ProductModel>(productList);
        }

        private async Task LoadEmployees()
        {
            var employeeList = await _employeeEndpoint.GetAll();
            Employees = new BindingList<EmployeeModel>(employeeList);
        }

        private async Task LoadWorkOrders()
        {
            var workOrderList = await _workOrderEndpoint.GetAllWorkOrders();
            WorkOrders = new BindingList<WorkOrderDBModel>(workOrderList);
        }
        public async void OnAppeared()
        {
            await LoadProducts();
            await LoadEmployees();
            await LoadWorkOrders();
            //await LoadUsers();
        }

        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }

        private DateTime _endTime;

        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged("EndTime");
            }
        }

        private BindingList<EmployeeModel> _employees;

        public BindingList<EmployeeModel> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged("Employees");
            }

        }

        private BindingList<ProductModel> _products;

        public BindingList<ProductModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged("Products");
            }
        }

        private BindingList<WorkOrderDBModel> _workOrders;

        public BindingList<WorkOrderDBModel> WorkOrders
        {
            get { return _workOrders; }
            set
            {
                _workOrders = value;
                OnPropertyChanged("WorkOrders");
            }
        }

        private string _workDescription;

        public string WorkDescription
        {
            get { return _workDescription; }
            set
            {
                _workDescription = value;
                OnPropertyChanged("WorkDescription");
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var propertyChangedHandler = PropertyChanged;
            if (propertyChangedHandler != null)
                propertyChangedHandler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
