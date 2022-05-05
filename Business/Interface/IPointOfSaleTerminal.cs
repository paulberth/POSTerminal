namespace Business.Interface
{
    public interface IPointOfSaleTerminal
    {
 
        decimal CalculateTotal();
        void ScanProduct(string ProductCode);

        IProductRepository productRepository { get; }

    }
}
