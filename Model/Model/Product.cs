 
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model;

public class Product
{
         
    public string? ProductCode { get; set; }

    public decimal UnitPrice { get; set; }
    public BulkPricing? BulkPrice { get; set; }

        

}