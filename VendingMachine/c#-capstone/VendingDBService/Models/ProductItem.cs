using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingService.Models
{
    public class ProductItem : BaseItem
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
