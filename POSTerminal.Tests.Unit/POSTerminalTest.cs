using Business;
using Business.Interface;
using Model.Model;
using Model.Utility;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;


namespace POSTerminalTests
{

    [TestFixture]
    public class PointOfSalesTerminalTests
    {

        private IPointOfSaleTerminal _terminal;


        [SetUp]
        public void SetUp()
        {
            //SD=ProductName List (A,B,C,D)
            //Initialize Product Data, Count : 4   
            List<Product> Products = new List<Product>
                {
                    new Product{ProductCode = SD.A, UnitPrice = (decimal)1.25, BulkPrice = new BulkPricing(3,3)},
                    new Product{ProductCode = SD.B, UnitPrice = (decimal)4.25 },
                    new Product{ProductCode = SD.C, UnitPrice = (decimal)1, BulkPrice = new BulkPricing(6,5)},
                    new Product{ProductCode = SD.D, UnitPrice = (decimal)0.75},
                };
            _terminal = new PointOfSaleTerminal(Products);

        }

    
        [Test(Description = "ABCDABA Verify that the total price is $13.25")]
        public void Test_1()
        {

            decimal expectedTotalPrice = (decimal)13.25;

            _terminal.ScanProduct(SD.A);
            _terminal.ScanProduct(SD.B);
            _terminal.ScanProduct(SD.C);
            _terminal.ScanProduct(SD.D);
            _terminal.ScanProduct(SD.A);
            _terminal.ScanProduct(SD.B);
            _terminal.ScanProduct(SD.A);

            var calculatedCartAmount = _terminal.CalculateTotal();

            Assert.That(calculatedCartAmount, Is.EqualTo(expectedTotalPrice), "The calculated total was incorrect");
        }


        [Test(Description = "CCCCCCC Verify that the total price is 6 : BULK PRICE $5 for a six-pack")]
        public void Test_2()
        {

            decimal expectedTotalPrice = 6;
            _terminal.ScanProduct(SD.C);
            _terminal.ScanProduct(SD.C);
            _terminal.ScanProduct(SD.C);
            _terminal.ScanProduct(SD.C);
            _terminal.ScanProduct(SD.C);
            _terminal.ScanProduct(SD.C);
            _terminal.ScanProduct(SD.C);

            var calculatedCartAmount = _terminal.CalculateTotal();

            Assert.That(calculatedCartAmount, Is.EqualTo(expectedTotalPrice), "The calculated total was incorrect");
        }

        [Test(Description = "ABCD Verify that the total price is $7.25")]
        public void Test_3()
        {
            decimal expectedTotalPrice = (decimal)7.25;
            _terminal.ScanProduct(SD.A);
            _terminal.ScanProduct(SD.B);
            _terminal.ScanProduct(SD.C);
            _terminal.ScanProduct(SD.D);

            var calculatedCartAmount = _terminal.CalculateTotal();

            Assert.That(calculatedCartAmount, Is.EqualTo(expectedTotalPrice), "The calculated total was incorrect");
        }

        [Test(Description = "D Price - From 0.75 to 5")]
        [TestCase(SD.D, 5)]
        public void SetPricing(string ProductCode, decimal SetPrice)
        {
            decimal expectedTotalPrice = 15;
            _terminal.SetPricing(ProductCode,SetPrice);
            _terminal.ScanProduct(SD.D);
            _terminal.ScanProduct(SD.D);
            _terminal.ScanProduct(SD.D);
            Assert.AreEqual(expectedTotalPrice, _terminal.CalculateTotal(), "The calculated total must 15");
        }

        [Test(Description = "D SetPrice 5 with bulkPricing buy 5 bulk price 20")]
        [TestCase(SD.D, 5)]
        public void SetPricingWithBulkPrice(string ProductCode, decimal SetPrice)
        {
            decimal expectedTotalPrice = 20;
            _terminal.SetPricing(ProductCode, SetPrice, new BulkPricing(5, 20));
            _terminal.ScanProduct(SD.D);
            _terminal.ScanProduct(SD.D);
            _terminal.ScanProduct(SD.D);
            _terminal.ScanProduct(SD.D);
            _terminal.ScanProduct(SD.D);
            Assert.AreEqual(expectedTotalPrice, _terminal.CalculateTotal(), "The calculated total must 20");
        }

        [Test(Description = "Initial Product Count is 4. Add 3(X,Y,Z)")]
        public void Add_Product_To_List()
        {
            decimal expectedProductCount = 7;

            var productList = _terminal.GetProductList();
            productList.Add(new Product(){ProductCode = "X"});
            productList.Add(new Product(){ProductCode = "Y"});
            productList.Add(new Product(){ProductCode = "Z"});

            Assert.AreEqual(expectedProductCount, productList.Count, "The total Product Count must 7");

        }

    }
}