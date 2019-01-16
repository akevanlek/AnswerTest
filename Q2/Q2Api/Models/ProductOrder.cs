using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q2Api.Models
{
    public class ProductOrder 
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
