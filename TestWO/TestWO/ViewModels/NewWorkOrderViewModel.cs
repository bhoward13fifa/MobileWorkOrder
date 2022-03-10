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
    public class NewWorkOrderViewModel : BaseViewModel, INotifyPropertyChanged
    {
        IEmployeeEndpoint _employeeEndpoint;
        ICustomerEndpoint _customerEndpoint;
        IProductEndpoint _productEndpoint;
        IUserEndpoint _userEndpoint;
        IWorkOrderEndpoint _workOrderEndpoint;

        public NewWorkOrderViewModel()
        {
            CancelCommand = new Command(OnCancel);
            SubmitCommand = new Command(OnSubmit);
            AddEmployee = new Command(OnAddEmployee);
            AddPart = new Command(OnAddPart);
            //AddImage = new Command(OnAddImage);

            _productEndpoint = DependencyService.Get<IProductEndpoint>();
            _userEndpoint = DependencyService.Get<IUserEndpoint>();
            _employeeEndpoint = DependencyService.Get<IEmployeeEndpoint>();
            _workOrderEndpoint = DependencyService.Get<IWorkOrderEndpoint>();
            _customerEndpoint = DependencyService.Get<ICustomerEndpoint>();
        }

        public Command SubmitCommand { get; }
        public Command CancelCommand { get; }
        public Command AddImage { get; }
        public Command AddEmployee { get; }
        public Command AddPart { get; }

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

        public async Task LoadCustomers()
        {
            var customerList = await _customerEndpoint.GetAll();
            Customers = new BindingList<CustomerModel>(customerList);
         }

        private async Task LoadUsers()
        {
            var userList = await _userEndpoint.GetAll();
            UserInfo = new BindingList<UserModel>(userList);
        }

        public async void OnAppeared()
        {
            await LoadProducts();
            await LoadEmployees();
            await LoadCustomers();
            //await LoadUsers();
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged();
            }
        }

        private DateTime _endTime;

        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged();
            }
        }

        private BindingList<CustomerModel> _customers;

        public BindingList<CustomerModel> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        private BindingList<EmployeeModel> _employees;

        public BindingList<EmployeeModel> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }

        }

        private BindingList<ProductModel> _products;

        public BindingList<ProductModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        private BindingList<ImageModel> _images;

        public BindingList<ImageModel> Images
        {
            get { return _images; }
            set
            {
                _images = value;
                OnPropertyChanged();
            }
        }

        private string _imageFileName;

        public string ImageFileName
        {
            get { return _imageFileName; }
            set
            {
                _imageFileName = value;
                OnPropertyChanged();
            }
        }

        private byte[] _imageData;

        public byte[] ImageData
        {
            get { return _imageData; }
            set
            {
                _imageData = value;
                OnPropertyChanged();
            }
        }

        private int _productQuantity;
        public int ProductQuantity
        {
            get { return _productQuantity; }
            set
            {
                _productQuantity = value;
                OnPropertyChanged();
            }
        }

        private string _workDescription;

        public string WorkDescription
        {
            get { return _workDescription; }
            set
            {
                _workDescription = value;
                OnPropertyChanged();
            }
        }

        private EmployeeModel _selectedEmployee;

        public EmployeeModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        private CustomerModel _selectedCustomer;

        public CustomerModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        private ProductModel _selectedProduct;

        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        private ImageModel _selectedImage;

        public ImageModel SelectedImage
        {
            get { return _selectedImage; }
            set
            {
                _selectedImage = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<WorkOrderItemModel> _partsCart = new ObservableCollection<WorkOrderItemModel>();

        public ObservableCollection<WorkOrderItemModel> PartsCart
        {
            get { return _partsCart; }
            set
            {
                _partsCart = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<WorkOrderEmployeeModel> _employeeCart = new ObservableCollection<WorkOrderEmployeeModel>();

        public ObservableCollection<WorkOrderEmployeeModel> EmployeeCart
        {
            get { return _employeeCart; }
            set
            {
                _employeeCart = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<WorkOrderImageModel> _imagesCart = new ObservableCollection<WorkOrderImageModel>();

        public ObservableCollection<WorkOrderImageModel> ImagesCart
        {
            get { return _imagesCart; }
            set
            {
                _imagesCart = value;
                OnPropertyChanged();

            }
        }
        public bool CanAddEmployee
        {
            get
            {
                bool output = false;
                if (SelectedEmployee != null)
                {
                    output = true;
                }
                return output;
            }
        }
        public void OnAddEmployee()
        {
            WorkOrderEmployeeModel exisitingEmployee = EmployeeCart.FirstOrDefault(x => x.Employee == SelectedEmployee);
            if (exisitingEmployee != null)
            {
                EmployeeCart.Remove(exisitingEmployee);
                EmployeeCart.Add(exisitingEmployee);
            }
            else
            {
                WorkOrderEmployeeModel employee = new WorkOrderEmployeeModel
                {
                    Employee = SelectedEmployee
                };
                EmployeeCart.Add(employee);
            }

            OnPropertyChanged();
        }

        public bool CanAddPart
        {
            get
            {
                bool output = false;
                if (SelectedProduct != null)
                {
                    output = true;
                }
                return output;
            }
        }

        public void OnAddPart()
        {
            WorkOrderItemModel existingItem = PartsCart.FirstOrDefault(x => x.Product == SelectedProduct);
            if (existingItem != null)
            {
                PartsCart.Remove(existingItem);
                PartsCart.Add(existingItem);
            }
            else
            {
                WorkOrderItemModel item = new WorkOrderItemModel
                {
                    Product = SelectedProduct
                };
                PartsCart.Add(item);
            }

            OnPropertyChanged();
        }

        //public void AddImage()
        //{

        //    try
        //    {
        //        OpenFileDialog dlg = new OpenFileDialog
        //        {
        //            DefaultExt = ".jpg",
        //            Filter = "Image Files (*.JPG;*.JPEG) |*.JPG;*.JPEG",
        //            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        //        };

        //        bool? result = dlg.ShowDialog();

        //        if (result != true)
        //        {
        //            return;
        //        }

        //        ImageFileName = Path.GetFileName(dlg.FileName);

        //        FileStream fs = new FileStream(dlg.FileName,
        //            FileMode.Open,
        //            FileAccess.Read);

        //        BinaryReader br = new BinaryReader(fs);

        //        long numBytes = new FileInfo(dlg.FileName).Length;
        //        ImageData = br.ReadBytes((int)numBytes);

        //        fs.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString(), "Error adding attachment");
        //    }


        //    WorkOrderImageModel existingItem = ImagesCart.FirstOrDefault(x => x.Image == SelectedImage);
        //    if (existingItem != null)
        //    {
        //        //ImagesCart.Remove(existingItem);
        //        ImagesCart.Add(existingItem);
        //    }
        //    else
        //    {
        //        WorkOrderImageModel image = new WorkOrderImageModel
        //        {
        //            Image = SelectedImage,
        //        };
        //        ImagesCart.Add(image);
        //    }
        //}

        public bool CanSubmit
        {
            get
            {
                bool output = false;

                if (PartsCart.Count > 0 && EmployeeCart.Count > 0)
                {
                    output = true;
                }

                return output;
            }
        }

        public async void OnSubmit()
        {
            WorkOrderModel workOrder = new WorkOrderModel();

            foreach (var item in PartsCart)
            {
                workOrder.WorkOrderDetails.Add(new WorkOrderDetailsModel
                {
                    ProductId = item.Product.ProductId,
                    ProductQuantity = item.ProductQuantity
                });
            }

            await _workOrderEndpoint.PostWorkOrder(workOrder);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");

        }

        private BindingList<UserModel> _userInfo;

        public BindingList<UserModel> UserInfo
        {
            get { return _userInfo; }
            set
            {
                _userInfo = value;
                OnPropertyChanged();
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
