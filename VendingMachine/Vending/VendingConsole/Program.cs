using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService.Database;
using VendingService.Helpers;

namespace VendingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingDBService db = new VendingDBService();
            var items = db.GetVendingItems();

            InventoryManager inventory = new InventoryManager(items);
            for (int rowIdx = 1; rowIdx <= inventory.RowCount; rowIdx++)
            {
                for (int colIdx = 1; colIdx <= inventory.ColCount; colIdx++)
                {
                    Console.WriteLine(inventory.GetVendingItem(rowIdx, colIdx).ToString());
                }
            }

            Console.ReadKey();
        }
    }
}
