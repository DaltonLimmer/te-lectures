using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService;

namespace Capstone.Classes
{
    public abstract class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Location { get; set; }
        public string Noise { get; private set; }

        public abstract string EatSound();

        public Product(string[] list)
        {
            Name = list[1];
            Price = double.Parse(list[2]);
            Location = list[0];
        }

        public Product(InventoryItem item)
        {
            Name = item.ProductName;
            Price = item.Price;
            Location = GetLocation(item.RowLocation, item.ColumnLocation);
            Noise = item.ConsumeMessage;
        }

        private string GetLocation(int row, int col)
        {
            string result = "";

            switch (row)
            {
                case 1:
                    result = "A" + col;
                    break;

                case 2:
                    result = "B" + col;
                    break;

                case 3:
                    result = "C" + col;
                    break;

                case 4:
                    result = "D" + col;
                    break;

                case 5:
                    result = "E" + col;
                    break;

                default:
                    throw new Exception("Only rows 1-5 are supported by this vening machine.");
            }

            return result;
        }

    }
}
