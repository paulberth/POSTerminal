using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;

namespace Business.Interface
{
    public interface IProductRepository
    {

        List<Product> GetProductList();
 
 
    }

   
}
