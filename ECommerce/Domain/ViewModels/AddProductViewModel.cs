using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ECommerce.Domain.ViewModels
{
    public class AddProductViewModel : BaseViewModel
    {

        private readonly IRepository<Product> _productRepo;

        private TextBox name;

        public TextBox Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private TextBox description;

        public TextBox Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(); }
        }

        private TextBox price;

        public TextBox Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }

        private TextBox discount;

        public TextBox Discount
        {
            get { return discount; }
            set { discount = value; OnPropertyChanged(); }
        }

        private TextBox quantity;

        public TextBox Quantity
        {
            get { return quantity; }
            set { quantity = value; OnPropertyChanged(); }
        }

        public RelayCommand AddCommand { get; set; }

        public AddProductViewModel()
        {
            _productRepo = new ProductRepository();

            AddCommand = new RelayCommand((e) =>
            {
                Product p = new Product
                {
                    Name = Name.Text,
                    Description = Description.Text,
                    Price = int.Parse(Price.Text),
                    Discount = int.Parse(Discount.Text),
                    Quantity = int.Parse(Quantity.Text)
                };
                _productRepo.AddData(p);
                MessageBox.Show("Product was added");
            });
        }

    }
}
