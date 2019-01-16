using Q2Api;
using Q2Api.Models;
using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;

namespace Q2Test
{
    public class CalulateOrderTest
    {
        [Fact]
        public void CalulateOrder()
        {
            Order inputOrder = new Order()
            {               
                Products = new List<ProductOrder>() {
                     new ProductOrder{
                        Product = new Product
                        {
                            Id = "p01",
                            Name = "iPhoneXSMax",
                            Is3Free1 = true,
                            Price = 2000,
                        },
                        Quantity = 9
                    },
                    new ProductOrder{
                        Product = new Product
                        {
                            Id = "p02",
                            Name = "HUAWEI Mate 20 X",
                            Is3Free1 = true,
                            Price = 4000,
                        },
                        Quantity = 7
                    },
                    new ProductOrder{
                        Product = new Product
                        {
                            Id = "p03",
                            Name = "iPhoneX",
                            Is3Free1 = false,
                            Price = 3500,
                        },
                        Quantity = 8
                    },
                },
                CheckOutPrice = 0,
                Discount = 0,
                TotalPrice = 0,
            };
            var cal = new Q2Cal();

            var result = cal.CalulateOrder(inputOrder);

            Order expectedOrder = new Order()
            {            
                Products = new List<ProductOrder>() {
                     new ProductOrder{
                        Product = new Product
                        {
                            Id = "p01",
                            Name = "iPhoneXSMax",
                            Is3Free1 = true,
                            Price = 2000,
                        },
                        Quantity = 9
                    },
                    new ProductOrder{
                        Product = new Product
                        {
                            Id = "p02",
                            Name = "HUAWEI Mate 20 X",
                            Is3Free1 = true,
                            Price = 4000,
                        },
                        Quantity = 7
                    },
                    new ProductOrder{
                        Product = new Product
                        {
                            Id = "p03",
                            Name = "iPhoneX",
                            Is3Free1 = false,
                            Price = 3500,
                        },
                        Quantity = 8
                    },
                },
                TotalPrice = 74000,
                Discount = 8000,
                CheckOutPrice = 66000,
            };

            result.Should().BeEquivalentTo(expectedOrder);
        }

    }
}
