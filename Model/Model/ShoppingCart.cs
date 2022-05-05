using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model;

public class ShoppingCart 
{
    
    public Product? Products { get; set; }

    public int Qty { get; set; }
}