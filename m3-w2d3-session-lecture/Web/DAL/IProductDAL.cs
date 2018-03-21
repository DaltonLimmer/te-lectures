using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.DAL
{
    /* Step 3 - Create Interface and implement */
    public interface IProductDAL
    {
        Product GetProduct(int id);
        IList<Product> GetProducts();
    }
}
