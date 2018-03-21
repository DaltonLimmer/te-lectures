using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingService.Models
{
    public class InventoryItem : BaseItem
    {
        public int ProductId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int Qty { get; set; }
    }
}
