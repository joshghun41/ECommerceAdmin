using ECommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Abstractions.Model
{
    public class OrderModel
    {

        public Order Order { get; set; }
        public int TotalAmount { get; set; }

    }
}
