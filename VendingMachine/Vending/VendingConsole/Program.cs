using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService.Database;
using VendingService.Helpers;
using VendingService.Models;

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

            Console.WriteLine();
            Console.WriteLine();

            ReportManager reportManager = new ReportManager();
            Report report = reportManager.GetReport(2018, db.GetProductItems());
            var reportItems = report.ReportItems;
            foreach (var item in reportItems)
            {
                Console.WriteLine($"{item.Name}|{item.Qty}");
            }
            Console.WriteLine();
            Console.WriteLine($"**Total Sales** {report.TotalSales.ToString("c")}");

            Console.ReadKey();
        }
    }
}
