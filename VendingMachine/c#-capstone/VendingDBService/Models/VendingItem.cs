using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingService.Models
{
    public class VendingItem
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Noise { get; set; }
        public double Price { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int Qty { get; set; }
    }
}
