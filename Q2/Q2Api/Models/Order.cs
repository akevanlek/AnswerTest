using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q2Api.Models
{
    public class Order
    {      
        public List<ProductOrder> Products { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public double CheckOutPrice { get; set; }

        public Order()
        {
            Products = new List<ProductOrder>();
        }
    }
}
