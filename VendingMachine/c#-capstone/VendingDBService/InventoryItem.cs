using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingService
{
    public class InventoryItem
    {
        public const string Chips = "Chips";
        public const string Candy = "Candy";
        public const string Nuts = "Nuts";
        public const string Gum = "Gum";
        public const string Beverage = "Beverage";

        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string ConsumeMessage { get; set; }
        public double Price { get; set; }
        public int RowLocation { get; set; }
        public int ColumnLocation { get; set; }
        public int Qty { get; set; }
    }
}
