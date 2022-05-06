using System.Data.Common;
using Business.Interface;
using Model.Model;

namespace Business
{
    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private List<ShoppingCart> _shoppingCartList = new List<ShoppingCart>();
        private List<Product> _productList = new List<Product>();

        public PointOfSaleTerminal(List<Product> productList)
        {
            _productList = productList;

        }

        public List<Product> GetProductList()
        {
            return _productList;
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            if (_shoppingCartList.Count == 0)
                return total;

            var groupCartProduct = _shoppingCartList.GroupBy(o => new
            {
                o.Products
            }).Select(s => new ShoppingCart
            {
                Products = s.Key.Products,
                Qty = s.Sum(x => x.Qty)

            });


            foreach (var product in groupCartProduct)
            {

                var bulkPricing = product?.Products?.BulkPrice;
                if (bulkPricing != null)
                {

                    var batchCount = Math.DivRem(product.Qty, bulkPricing.Qty, out var remainingUnits);
                    total += (decimal)batchCount * bulkPricing.Price +
                             (decimal)remainingUnits * product.Products.UnitPrice;

                }
                else
                {
                    total += product.Qty * product.Products.UnitPrice;
                }
            }

            return total;
        }

        public void ScanProduct(string ProductCode)
        {
            var product = _productList.Where(t => t.ProductCode == ProductCode).FirstOrDefault();
            if (product == null)
            {
                throw new ArgumentException("Product not found",nameof(ProductCode));
            }
            else
            {
                _shoppingCartList.Add(new ShoppingCart()
                {
                    Products = product,
                    Qty = 1

                });
            }
        }

        public void SetPricing(string ProductCode,decimal UnitPrice, BulkPricing? bulkPricing = null)
        {
            foreach (var product in _productList.Where(t=>t.ProductCode==ProductCode))
            {
                product.UnitPrice = UnitPrice;
                product.BulkPrice = bulkPricing;
            }
        }

        public void SetPricing(string ProductCode, decimal UnitPrice)
        {
            foreach (var product in _productList.Where(t => t.ProductCode == ProductCode))
            {
                product.UnitPrice = UnitPrice;
            }
        }

    }

}

