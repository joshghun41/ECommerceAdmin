using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Services;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        private readonly IRepository<Product> _productRepo;
        private readonly ProductService _productService;
        private ObservableCollection<Product> allProducts;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }


        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }

        private string filterText;

        public string FilterText
        {
            get { return filterText; }
            set { filterText = value; OnPropertyChanged(); }
        }


        public bool IsLower { get; set; } = false;
        public RelayCommand ToLowerCommand { get; set; }
        public RelayCommand SelectProductCommand { get; set; }
        public RelayCommand AdminCommand { get; set; }
        public MainViewModel(IRepository<Product> productRepo)
        {
            FilterText = "Lower To Higher";
            SelectedProduct=new Product();
            _productRepo = productRepo;
            _productService = new ProductService();

            AllProducts=_productRepo.GetAllData();

            ToLowerCommand = new RelayCommand((o) =>
            {
                if (!IsLower)
                {
                    FilterText = "Lower To Higher";
                }
                else
                {
                    FilterText = "Higher To Lower";
                }
                IsLower = !IsLower;
                AllProducts = _productService.GetFromLowerToHigher(IsLower);
            });

            AdminCommand = new RelayCommand(a =>
            {
                var admin_window = new AdminWindow();
                admin_window.Show();

            });
            

            SelectProductCommand = new RelayCommand((o) =>
            {
                var vm = new ProductInfoViewModel(SelectedProduct);
                vm.ProductInfo = SelectedProduct;
                var view = new ProductWindow();
                view.DataContext = vm;

                view.ShowDialog();

            });

        }
    }
}
