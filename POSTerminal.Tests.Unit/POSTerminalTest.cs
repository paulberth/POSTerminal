using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Business.Interface;
using Model.Model;
using Model.Utility;
using Moq;
using NUnit.Framework;
 

namespace POSTerminalTests
{
    public class PointOfSalesTerminalTests
    {


        [Test]
        public void Test_1() // ABCDABA Verify that the total price is $13.25
        {

           decimal expectedTotalPrice =  (decimal)13.25;
            IPointOfSaleTerminal terminal = new PointOfSaleTerminal();

            var productList = terminal.productRepository.GetProductList();

            terminal.ScanProduct(SD.A);
            terminal.ScanProduct(SD.B);
            terminal.ScanProduct(SD.C);
            terminal.ScanProduct(SD.D);
            terminal.ScanProduct(SD.A);
            terminal.ScanProduct(SD.B);
            terminal.ScanProduct(SD.A);

            var calculatedCartAmount = terminal.CalculateTotal();

            Assert.That(calculatedCartAmount, Is.EqualTo(expectedTotalPrice), "The calculated total was incorrect");
        }


        [Test]
        public void Test_2() // CCCCCCC Verify that the total price is 6 : BULK PRICE $5 for a six-pack 
        {

            decimal expectedTotalPrice =  6;
            IPointOfSaleTerminal terminal = new PointOfSaleTerminal();

            var productList = terminal.productRepository.GetProductList();

            terminal.ScanProduct(SD.C);
            terminal.ScanProduct(SD.C);
            terminal.ScanProduct(SD.C);  
            terminal.ScanProduct(SD.C);
            terminal.ScanProduct(SD.C);
            terminal.ScanProduct(SD.C);
            terminal.ScanProduct(SD.C);

            var calculatedCartAmount = terminal.CalculateTotal();

            Assert.That(calculatedCartAmount, Is.EqualTo(expectedTotalPrice), "The calculated total was incorrect");
        }

        public void Test_3() // ABCD Verify that the total price is $7.25 
        {

            decimal expectedTotalPrice = (decimal)7.25;
            IPointOfSaleTerminal terminal = new PointOfSaleTerminal();

            var productList = terminal.productRepository.GetProductList();

            terminal.ScanProduct(SD.A);
            terminal.ScanProduct(SD.B);
            terminal.ScanProduct(SD.C);
            terminal.ScanProduct(SD.D);

            var calculatedCartAmount = terminal.CalculateTotal();

            Assert.That(calculatedCartAmount, Is.EqualTo(expectedTotalPrice), "The calculated total was incorrect");
        }
    }
}