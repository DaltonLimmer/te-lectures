using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingService.Models
{
    public class CategoryItem : BaseItem
    {
        public string Name { get; set; }
        public string Noise { get; set; }
    }
}
