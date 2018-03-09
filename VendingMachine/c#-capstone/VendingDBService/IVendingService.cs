using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingService
{
    interface IVendingService
    {
        List<InventoryItem> GetInventoryItems();
        void AddInventoryItem(InventoryItem item);
    }
}
