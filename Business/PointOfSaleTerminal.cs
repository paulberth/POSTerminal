using Business.data;
using Business.Interface;
using Model.Model;

namespace Business
{
    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private List<ShoppingCart> _shoppingCartList = new List<ShoppingCart>();
        private List<Product> _productList = new List<Product>();

        public PointOfSaleTerminal()
        {



            productRepository = new ProductRepository();
            if (_productList.Count() == 0)
                _productList = productRepository.GetProductList();

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

            if (product != null)
            {

                _shoppingCartList.Add(new ShoppingCart()
                {
                    Products = product,
                    Qty = 1

                });
            }
        }

        public IProductRepository productRepository { get; private set; }
    }

}

