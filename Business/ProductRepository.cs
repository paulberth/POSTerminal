using Business.Interface;
using Model.Model;

namespace Business.data
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetProductList()
        {
            List<Product> Products = new List<Product>
            {
                new Product{ProductCode = "A", UnitPrice = (decimal)1.25, BulkPrice = new BulkPricing(3,3)},
                new Product{ProductCode = "B", UnitPrice = (decimal)4.25 },
                new Product{ProductCode = "C", UnitPrice = (decimal)1, BulkPrice = new BulkPricing(6,5)},
                new Product{ProductCode = "D", UnitPrice = (decimal)0.75},
            };


            return Products;
        }

    }
}
