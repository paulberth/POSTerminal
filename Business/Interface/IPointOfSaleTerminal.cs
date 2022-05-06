using Model.Model;

namespace Business.Interface
{
    public interface IPointOfSaleTerminal
    {
 
        decimal CalculateTotal();
        void ScanProduct(string ProductCode);

        void SetPricing(string ProductCode, decimal UnitPrice);
        void SetPricing(string ProductCode, decimal UnitPrice, BulkPricing? bulkPricing=null);
        List<Product> GetProductList();
    }
}
