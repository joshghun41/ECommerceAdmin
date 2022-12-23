using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerce.Domain.ViewModels
{
    public class UpdateProductViewModel : BaseViewModel
    {
        private readonly IRepository<Product> _dataContext;
        public RelayCommand UpdateCommand { get; set; }

        public Product SelectedItem { get; set; } = new Product();
        public UpdateProductViewModel(Product p)
        {
            _dataContext = new ProductRepository();

            SelectedItem.Name = p.Name;
            SelectedItem.Price = p.Price;
            SelectedItem.Discount = p.Discount;
            SelectedItem.Quantity = p.Quantity;
            SelectedItem.Description = p.Description.ToString();

            UpdateCommand = new RelayCommand((e) =>
            {
                _dataContext.UpdateData(SelectedItem);
                MessageBox.Show("Successfully Updated");
            });
        }
    }
}
