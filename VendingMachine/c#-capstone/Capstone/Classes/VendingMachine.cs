using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendingService;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        string finalDestination = @"..\..\..\etc\Log.txt";
        
        string filePathSalesReport = @"..\..\..\etc\SalesReport.txt";

        private List<Product> _products = new List<Product>();
        private Dictionary<string, ProductInventory> _inventory = new Dictionary<string, ProductInventory>();

        // Dictionary for the sales report
        private Dictionary<string, ProductInventory> _salesReport = new Dictionary<string, ProductInventory>();

        // List to store selected items for the 'Finish Transaction' page.
        private List<Product> addToCart = new List<Product>();

        // Running Balance property
        public double CurrentMoneyProvided { get; set; }

         // Total Bill property
        public double TotalBill { get; set; }

         // Selected items counter
        public int ItemCounter { get; set; }
        public string FinalDestination { get => finalDestination; set => finalDestination = value; }

        // Constructor which sets initial deposit balance & total bill balance to $0.00
        public VendingMachine()
        {
            CurrentMoneyProvided = 0.00;
            TotalBill = 0.00;
            ItemCounter = 0;
        }

        public void TurnOn()
        {
            LoadDataFromDatabase();
            //LoadData();
            MainMenu();
        }

        private void LoadDataFromDatabase()
        {
            VendingDBService db = new VendingDBService();
            List<InventoryItem> inventory = db.GetInventoryItems();
            foreach (InventoryItem item in inventory)
            {
                if (item.CategoryName == InventoryItem.Chips)
                {
                    Chips product = new Chips(item);

                    _products.Add(product);
                    _inventory.Add(product.Location, new ProductInventory(product, item.Qty));
                    _salesReport.Add(product.Location, new ProductInventory(product, item.Qty));
                }
                else if (item.CategoryName == InventoryItem.Candy)
                {
                    Candy product = new Candy(item);

                    _products.Add(product);
                    _inventory.Add(product.Location, new ProductInventory(product, item.Qty));
                    _salesReport.Add(product.Location, new ProductInventory(product, item.Qty));
                }
                else if (item.CategoryName == InventoryItem.Beverage)
                {
                    Beverage product = new Beverage(item);

                    _products.Add(product);
                    _inventory.Add(product.Location, new ProductInventory(product, item.Qty));
                    _salesReport.Add(product.Location, new ProductInventory(product, item.Qty));
                }
                else if (item.CategoryName == InventoryItem.Gum)
                {
                    Gum product = new Gum(item);

                    _products.Add(product);
                    _inventory.Add(product.Location, new ProductInventory(product, item.Qty));
                    _salesReport.Add(product.Location, new ProductInventory(product, item.Qty));
                }
                else if (item.CategoryName == InventoryItem.Nuts)
                {
                    Nuts product = new Nuts(item);

                    _products.Add(product);
                    _inventory.Add(product.Location, new ProductInventory(product, item.Qty));
                    _salesReport.Add(product.Location, new ProductInventory(product, item.Qty));
                }
            }
        }

        private void LoadData()
        {
            string filePath = @"..\..\..\etc\vendingmachine.csv";

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] productInfo = line.Split('|');

                    if (productInfo[0][0] == ('A'))
                    {
                        Chips chip = new Chips(productInfo);
                        _products.Add(chip);
                        _inventory.Add(chip.Location, new ProductInventory(chip));
                        _salesReport.Add(chip.Location, new ProductInventory(chip));
                    }
                    else if (productInfo[0][0] == ('B'))
                    {
                        Candy candy = new Candy(productInfo);
                        _products.Add(candy);
                        _inventory.Add(candy.Location, new ProductInventory(candy));
                        _salesReport.Add(candy.Location, new ProductInventory(candy));
                    }
                    else if (productInfo[0][0] == ('C'))
                    {
                        Beverage beverage = new Beverage(productInfo);
                        _products.Add(beverage);
                        _inventory.Add(beverage.Location, new ProductInventory(beverage));
                        _salesReport.Add(beverage.Location, new ProductInventory(beverage));
                    }
                    else if (productInfo[0][0] == ('D'))
                    {
                        Gum gum = new Gum(productInfo);
                        _products.Add(gum);
                        _inventory.Add(gum.Location, new ProductInventory(gum));
                        _salesReport.Add(gum.Location, new ProductInventory(gum));
                    }
                }
            }
        }

        private void MainMenu()
        {
            bool isMainFinished = false;

            while (!isMainFinished)
            {
                Console.Clear();
                Console.WriteLine();
                using (StreamWriter sw1 = new StreamWriter(filePathSalesReport))
                {
                    foreach (Product prod in _products)
                    {
                        sw1.WriteLine(prod.Name + "|" + _salesReport[prod.Location].SaleQty);
                    }
                    sw1.WriteLine();
                    sw1.WriteLine($"**TOTAL SALES** ${TotalBill}");
                }
                Console.WriteLine("****MAIN MENU****");
                Console.WriteLine();
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine();
                Console.WriteLine("(2) Purchase");

                char userChoice = Console.ReadKey().KeyChar;
                if (userChoice == '1')
                {
                    InventoryMenu();
                }
                else if (userChoice == '2')
                {
                    PurchaseMenu();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Invalid selection. Please select '1' or '2'.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private void PurchaseMenu()
        {
            bool isPurchaseFinished = false;

            while (!isPurchaseFinished)
            {
                Console.Clear();
                Console.WriteLine();
                using (StreamWriter sw1 = new StreamWriter(filePathSalesReport))
                {
                    foreach (Product prod in _products)
                    {
                        sw1.WriteLine(prod.Name + "|" + _salesReport[prod.Location].SaleQty);
                    }
                    sw1.WriteLine();
                    sw1.WriteLine($"**TOTAL SALES** ${TotalBill}");
                }
                Console.WriteLine("***PURCHASE PROCESS***\t" +
                    "(To return to MAIN MENU, press '0')");
                Console.WriteLine();
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine();
                Console.WriteLine("(2) Select Product");
                Console.WriteLine();
                Console.WriteLine("(3) Finish Transaction  -OR-  Return Change if Total Bill = $0.00");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Current Money Provided: ${CurrentMoneyProvided}");
                Console.WriteLine();
                Console.WriteLine($"Total Bill: ${TotalBill}");
                Console.WriteLine();
                Console.WriteLine($"Number of Items in Your Cart: {ItemCounter}");

                char purchaseMenuChoice = Console.ReadKey().KeyChar;
                if (purchaseMenuChoice == '1')
                {
                    FeedMoney();
                }
                else if (purchaseMenuChoice == '2')
                {
                    SelectProduct();
                }
                else if (purchaseMenuChoice == '3')
                {
                    FinishTransaction();
                }
                else if (purchaseMenuChoice == '0')
                {
                    MainMenu();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Invalid selection. Please select '1', '2', or '3'.");
                    Console.WriteLine("Press '0' to return to the **MAIN MENU**");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

       
        private void InventoryMenu()
        {
            Console.Clear();
            Console.WriteLine("{0,-10}{1,-40}{2,-10}{3,-10}", "Item ID", "Product Name", "Price", "Quantity");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (Product prod in _products)
            {
                Console.WriteLine("{0,-10}{1,-40}{2,-10}{3,-5}", "   " + prod.Location, prod.Name, prod.Price.ToString("c"), "   " + _inventory[prod.Location].Qty);
            }
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to return to **MAIN MENU**");
            Console.ReadKey();
        }

        private void FeedMoney()
        {
            bool isDepositFinished = false;

            while (!isDepositFinished)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("***DEPOSIT MONEY***\t(To return to PURCHASE MENU, press '0')");
                Console.WriteLine();
                Console.WriteLine("Select '1', '2', '3', or '4' to add the listed amounts to your balance.");
                Console.WriteLine();
                Console.WriteLine("(1) Add $1.00");
                Console.WriteLine();
                Console.WriteLine("(2) Add $2.00");
                Console.WriteLine();
                Console.WriteLine("(3) Add $5.00");
                Console.WriteLine();
                Console.WriteLine("(4) Add $10.00");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Current Money Provided: ${CurrentMoneyProvided}");
                Console.WriteLine();
                Console.WriteLine($"Total Bill: ${TotalBill}");

                char despositChoice = Console.ReadKey().KeyChar;

                using (StreamWriter sw = File.AppendText(FinalDestination))
                {
                    if (despositChoice == '1')
                    {
                        CurrentMoneyProvided += 1;
                        sw.WriteLine(DateTime.Now + $"  FEED MONEY:  $1.00 \t\t" + " $" + CurrentMoneyProvided);
                    }
                    else if (despositChoice == '2')
                    {
                        CurrentMoneyProvided += 2;
                        sw.WriteLine(DateTime.Now + $"  FEED MONEY:  $2.00 \t\t" + " $" + CurrentMoneyProvided);
                    }
                    else if (despositChoice == '3')
                    {
                        CurrentMoneyProvided += 5;
                        sw.WriteLine(DateTime.Now + $"  FEED MONEY:  $5.00 \t\t" + " $" + CurrentMoneyProvided);
                    }
                    else if (despositChoice == '4')
                    {
                        CurrentMoneyProvided += 10;
                        sw.WriteLine(DateTime.Now + $"  FEED MONEY:  $10.00\t\t" + " $" + CurrentMoneyProvided);
                    }
                    
                    else if (despositChoice == '0')
                    {
                        sw.Close();
                        PurchaseMenu();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Invalid selection. Please select '1', '2', '3', or '4'.");
                        Console.WriteLine("Press '0' to return to the **PURCHASE MENU**");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
        }


        private void SelectProduct()
        {
            bool isSelectionFinished = false;

            while (!isSelectionFinished)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("***MAKE A SELECTION***\t" +
                    "(To return to PURCHASE MENU, press '0' and then hit 'Enter')");
                Console.WriteLine();
                Console.WriteLine("{0,-10}{1,-22}{2,-10}{3,-10}", "Item ID", "Product Name", "Price", "Quantity");
                Console.WriteLine("--------------------------------------------------");
                using (StreamWriter sw1 = new StreamWriter(filePathSalesReport))
                {
                    foreach (Product prod in _products)
                    {
                        Console.WriteLine("{0,-10}{1,-22}{2,-10}{3,-5}", "   " + prod.Location, prod.Name,
                            "$" + prod.Price, "   " + _inventory[prod.Location].Qty);
                        sw1.WriteLine(prod.Name + "|" + _salesReport[prod.Location].SaleQty);
                    }
                    sw1.WriteLine();
                    sw1.WriteLine($"**TOTAL SALES** ${TotalBill}");
                }
                Console.WriteLine();
                Console.WriteLine($"Current Money Provided: ${CurrentMoneyProvided}");
                Console.WriteLine();
                Console.WriteLine($"Total Bill: ${TotalBill}");
                Console.WriteLine();
                Console.WriteLine("Choose ONE item from the list above." +
                    " Input the appropriate Item ID (example: 'A1'), and hit 'Enter' to select item.");

                string productSelectionInput = Console.ReadLine();

                using (StreamWriter sw = File.AppendText(FinalDestination))
                {
                        if (productSelectionInput.Equals("0"))
                        {
                            sw.Close();
                            PurchaseMenu();
                        }
                        foreach (Product prod in _products)
                        {
                            if ((productSelectionInput.ToUpper().Equals(prod.Location))
                                && (CurrentMoneyProvided >= prod.Price)
                                && (_inventory[prod.Location].Qty != "Sold Out"))
                            {
                                TotalBill += prod.Price;
                                sw.WriteLine(DateTime.Now + $" {prod.Name} {prod.Location}:  ${CurrentMoneyProvided} \t\t"
                                    + " $" + (CurrentMoneyProvided - prod.Price));
                                CurrentMoneyProvided -= prod.Price;
                                ItemCounter += 1;
                                _inventory[prod.Location].DeductItem();
                                _salesReport[prod.Location].AddToSalesReport();
                                addToCart.Add(prod);
                                Console.WriteLine();
                                Console.WriteLine($"1 {prod.Name} has been dispensed and added to your cart.");
                                Console.WriteLine();
                                Console.WriteLine("***Returning to Purchase Menu***");
                                Thread.Sleep(3500);
                                sw.Close();
                                PurchaseMenu();
                            }
                        }
                        foreach (Product prod in _products)
                        {
                            if ((productSelectionInput.ToUpper().Equals(prod.Location))
                                    && (CurrentMoneyProvided < prod.Price))
                            {
                                Console.WriteLine();
                                Console.WriteLine("Insufficient funds.  ***Returning to Purchase Menu***");
                                Thread.Sleep(3500);
                                sw.Close();
                                PurchaseMenu();
                            }
                        }
                        foreach (Product prod in _products)
                        {
                            if ((productSelectionInput.ToUpper().Equals(prod.Location))
                                && (_inventory[prod.Location].Qty == "Sold Out"))
                            {
                                Console.WriteLine();
                                Console.WriteLine("Selected product is Sold Out.  ***Returning to Purchase Menu***");
                                Thread.Sleep(3500);
                                sw.Close();
                                PurchaseMenu();
                            }
                        }
                        foreach (Product prod in _products)
                        {
                            if (!productSelectionInput.ToUpper().Equals(prod.Location))
                            {
                                Console.WriteLine();
                                Console.WriteLine("Invalid item selection.  ***Returning to Purchase Menu***");
                                Thread.Sleep(3500);
                                sw.Close();
                                PurchaseMenu();
                            }
                        }
                    
                }
                Console.ReadKey();
            }
        }

        private void FinishTransaction()
        {
            bool isTransactionFinalized = false;

            while (!isTransactionFinalized)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("***PURCHASE CONFIRMATION PAGE***\t" +
                    "(To return to PURCHASE MENU, press '0')");
                Console.WriteLine();
                Console.WriteLine($"Current Money Provided is: ${CurrentMoneyProvided}");
                Console.WriteLine();
                Console.WriteLine($"Total Bill is: ${TotalBill}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Number of Items in Your Cart: {ItemCounter}");
                Console.WriteLine();
                Console.WriteLine("List of Selected Items:");
                Console.WriteLine();

                foreach (Product prod in addToCart)
                {
                    Console.WriteLine($"\t1 - {prod.Name}");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"*Press '1' to Confirm & Complete Transaction*");
                
                char confirmationChoice = Console.ReadKey().KeyChar;
                if (confirmationChoice == '0')
                {
                    PurchaseMenu();
                }
                else if (confirmationChoice == '1')
                {
                    MakeChangeAndConsume();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid selection. Please press '1' to confirm & complete transaction.");
                    Console.WriteLine("Press '0' to return to the **PURCHASE MENU**");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }


        private void MakeChangeAndConsume()
        {
            bool isFinalPageRunning = false;

            while (!isFinalPageRunning)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("***TRANSACTION COMPLETE***");
                Console.WriteLine();
                Console.WriteLine($"Current Money Provided was: ${CurrentMoneyProvided}");
                Console.WriteLine();
                Console.WriteLine($"Total Bill was: ${TotalBill}");
                Console.WriteLine();
                Console.WriteLine($"Number of Items in Your Cart: {ItemCounter}");
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(2500);
                Console.WriteLine("MAKING CHANGE AND DISPENSING ITEM(S)....");
                Thread.Sleep(2000);
                Console.WriteLine();

                double changeRemaining = CurrentMoneyProvided;
                double changeAfterQuarters = 0.00;
                double changeAfterDimes = 0.00;
                double numberOfQuarters = 0;
                double numberOfDimes = 0;
                double numberOfNickels = 0;
                double quarterValue = 0.25;
                double dimeValue = 0.10;
                double nickelValue = 0.05;

                using (StreamWriter sw = File.AppendText(FinalDestination))
                {
                    sw.WriteLine(DateTime.Now + " GIVE CHANGE:  " + "$"
                        + changeRemaining + "\t\t" + "$" + (changeRemaining - changeRemaining));
                }
                    // If change due is equal to or higher than 25 cents
                if (changeRemaining >= quarterValue)
                {
                    numberOfQuarters = Math.Floor(changeRemaining / quarterValue);
                    changeAfterQuarters = changeRemaining - (numberOfQuarters * quarterValue);

                    if (changeRemaining % quarterValue != 0)
                    {
                        if (changeAfterQuarters >= dimeValue)
                        {
                            numberOfDimes = Math.Floor(changeAfterQuarters / dimeValue);
                            changeAfterDimes = changeAfterQuarters - (numberOfDimes * dimeValue);
                            if (changeAfterQuarters % dimeValue != 0)
                            {
                                numberOfNickels = 1;
                            }
                            else
                            {
                                numberOfDimes = Math.Floor(changeAfterQuarters / dimeValue);
                            }
                        }
                        else
                        {
                            numberOfNickels = 1;
                        }
                    }
                    else
                    {
                        numberOfQuarters = Math.Floor(changeRemaining / quarterValue);
                    }
                }
                // if change due is between 10 and 20 cents 
                else if ((changeRemaining >= dimeValue) && (changeRemaining < quarterValue))
                {
                    numberOfDimes = Math.Floor(changeRemaining / dimeValue);
                    if (changeRemaining % dimeValue != 0)
                    {
                        numberOfNickels = 1;
                    }
                    else
                    {
                        numberOfDimes = Math.Floor(changeRemaining / dimeValue);
                    }
                }
                // if change due is 5 cents
                else if (changeRemaining == nickelValue)
                {
                    numberOfNickels = 1;
                }
                // if no change due
                else
                {
                    numberOfNickels = 0;
                }

                CurrentMoneyProvided = 0.00;

                Console.WriteLine($"Total Change Returned: ${changeRemaining}");
                Console.WriteLine($"\tNumber of Quarters Returned: {numberOfQuarters}");
                Console.WriteLine($"\tNumber of Dimes Returned: {numberOfDimes}");
                Console.WriteLine($"\tNumber of Nickels Returned: {numberOfNickels}");
                Thread.Sleep(2000);
                Console.WriteLine();
                Console.WriteLine($"Current Money Provided is: ${CurrentMoneyProvided}");
                Thread.Sleep(1500);
                Console.WriteLine();

                foreach (Product prod in addToCart)
                {
                    Console.WriteLine($"Enjoy your {prod.Name}.\t{prod.EatSound()}");
                    Thread.Sleep(1300);
                }

                Console.WriteLine();
                Console.WriteLine("THANK YOU FOR USING THE VENDO-MATIC 500!");
                Console.WriteLine();
                Console.WriteLine("***Shutting Down***");
                Thread.Sleep(7000);
                Environment.Exit(0);
            }
        }
    }
}
