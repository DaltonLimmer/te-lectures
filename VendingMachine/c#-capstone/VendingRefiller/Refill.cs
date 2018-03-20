using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService;
using VendingService.Database;
using VendingService.Interfaces;
using VendingService.Mock;
using VendingService.Models;

namespace VendingRefiller
{
    public class Refill
    {
        private IVendingService _db = new VendingDBService();
        //private IVendingService _db = new MockVendingDBService();

        public void Start()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            char menuOption = ' ';
            while (menuOption != 'q')
            {
                Console.Clear();
                Console.WriteLine("1) Add Vending Item");
                Console.WriteLine("2) Refill Vending Item");
                Console.WriteLine("3) Change Vending Item");
                Console.WriteLine("q) Quit");

                try
                {
                    menuOption = Console.ReadKey().KeyChar;
                    if (menuOption == '1')
                    {
                        AddProduct();
                    }
                    else if (menuOption == '2')
                    {
                        RefillLocation();
                    }
                    else if (menuOption == '3')
                    {
                        ChangeVendingItem();
                    }
                }
                catch(Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("Exception: " + ex.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private void AddProduct()
        {
            //Create object to hold transaction data
            VendingItem item = new VendingItem();

            //Category Table
            item.CategoryName = "TestCategory";
            item.Noise = "Test Munch Crumble Pop, Yuck!";

            //Product Table
            item.ProductName = "Nasty Bites";
            item.Price = 5.00;

            //Inventory Table
            item.Qty = 1;
            item.Row = 6;
            item.Column = 1;

            //Call method to insert rows in the three tables
            _db.AddVendingItem(item);
        }

        private void RefillLocation()
        {

        }

        private void ChangeVendingItem()
        {

        }
    }
}
