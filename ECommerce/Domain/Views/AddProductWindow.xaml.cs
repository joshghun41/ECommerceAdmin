using ECommerce.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ECommerce.Domain.Views
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
            var vm = new AddProductViewModel();
            vm.Name = nametxtb;
            vm.Price = pricetxtb;
            vm.Description = desctxtb;
            vm.Discount = discounttxtb;
            vm.Quantity = quantitytxtb;
            this.DataContext = vm;
        }
    }
}
