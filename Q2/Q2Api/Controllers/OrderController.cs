using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q2Api.Models;

namespace Q2Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public static List<Product> storeProducts = new List<Product>();
        public static Order userOrder = new Order();

        public OrderController()
        {

        }

        [HttpGet("GetStoreProducts")]
        public List<Product> GetStoreProducts()
        {
            return storeProducts;
        }

        [HttpGet("GetOrder")]
        public Order GetOrder()
        {
            return userOrder;
        }

        [HttpPost("{productId}")]
        public Order AddOrder(string productId)
        {
            var product = storeProducts.Where(x => x.Id == productId)?.FirstOrDefault();

            var p = userOrder.Products.Where(x => x.Product.Id == productId)?.FirstOrDefault();
            if (p != null)
            {
                p.Quantity += 1;
            }
            else
            {
                userOrder.Products.Add(new ProductOrder()
                {
                    Product = product,
                    Quantity = 1
                });
            }

            var cal = new Q2Cal();
            userOrder = cal.CalulateOrder(userOrder);
            return userOrder;
        }

        [HttpPost("AddStoreProduct")]
        public List<Product> AddStoreProduct([FromBody]Product newProduct)
        {
            if (newProduct.Price <= 0 && String.IsNullOrWhiteSpace(newProduct.Name))
            {
                throw new Exception("ข้อมูลผิดพลาด");
            }
            newProduct.Id = Guid.NewGuid().ToString();
            storeProducts.Add(newProduct);
            return storeProducts;
        }
    }
}
