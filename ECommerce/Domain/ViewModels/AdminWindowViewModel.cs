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
using System.Windows;

namespace ECommerce.Domain.ViewModels
{
    public class AdminWindowViewModel : BaseViewModel
    {

        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<Product> _productRepo;
        private readonly ProductService _productService;
        private ObservableCollection<Order> allProducts;

        public ObservableCollection<Order> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Product> allProducts2;

        public ObservableCollection<Product> AllProducts2
        {
            get { return allProducts2; }
            set { allProducts2 = value; OnPropertyChanged(); }
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

        private string totalPrice;

        public string TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public RelayCommand TotalOrderPriceCommand { get; set; }
        public RelayCommand SelectProductCommand { get; set; }
        public RelayCommand AddProductCommand { get; set; }
        public RelayCommand AdminCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public AdminWindowViewModel(IRepository<Order> orderRepo,IRepository<Product>productRepo)
        {
            FilterText = "Lower To Higher";
            SelectedProduct = new Product();
            _orderRepo = orderRepo;
            _productRepo =productRepo;
            _productService = new ProductService();



            AllProducts = _orderRepo.GetAllData();
            AllProducts2 = _productRepo.GetAllData();

            //ToLowerCommand = new RelayCommand((o) =>
            //{
            //    if (!IsLower)
            //    {
            //        FilterText = "Lower To Higher";
            //    }
            //    else
            //    {
            //        FilterText = "Higher To Lower";
            //    }
            //    IsLower = !IsLower;
            //    AllProducts = _productService.GetFromLowerToHigher(IsLower);
            //});


            SelectProductCommand = new RelayCommand((o) =>
            {
                var vm = new ProductInfoViewModel(SelectedProduct);
                vm.ProductInfo = SelectedProduct;
                var view = new UpdateProductWindow();
                view.DataContext = vm;
                view.ShowDialog();

            });


            AddProductCommand = new RelayCommand(a =>
            {
            
                var add_view = new AddProductWindow();
              
                add_view.Show();
            });


            UpdateCommand = new RelayCommand(u =>
            {
                MessageBox.Show("For Update Product you must Select product from ListView");
            });

            TotalOrderPriceCommand = new RelayCommand(t =>
            {

                var result = 0;
                foreach (var item in AllProducts)
                {
                    result += ((int)item.Product.Price * (int)item.Amount);
                }
                if (TotalPrice != null)
                {
                    totalPrice = TotalPrice.ToString();
                    TotalPrice = result.ToString();
                }
                else
                {

                    TotalPrice = result.ToString();
                }
                MessageBox.Show($"Total Price of All Products is {TotalPrice} $");
            });

        }

    }
}
