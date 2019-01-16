using Q2Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q2Api
{
    public class Q2Cal
    {
        public Order CalulateOrder(Order order)
        {
            order.TotalPrice = order.Products.Sum(x => x.Product.Price * x.Quantity);
            order.Discount = 0;
            foreach (var item in order.Products)
            {
                if (item.Product.Is3Free1 && item.Quantity >= 4)
                {
                    var n = (double)item.Quantity / 4;
                    var freeItem = Math.Floor(n);
                    order.Discount += freeItem * item.Product.Price;
                }
            }
            order.CheckOutPrice = order.TotalPrice - order.Discount;
            return order;
        }
    }
}
