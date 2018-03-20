using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingService.Database;
using VendingService.Helpers;
using VendingService.Models;

namespace VendingIntegrationTests
{
    //[TestClass]
    public class LoadDatabase
    {
        [TestMethod]
        public void PopulateDatabase()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                VendingDBService db = new VendingDBService();

                CategoryItem categoryItem = new CategoryItem()
                {
                    Name = "Chips",
                    Noise = "Crunch, Crunch, Crunch, Yum!"
                };
                categoryItem.Id = db.AddCategoryItem(categoryItem);

                // Add Product 1
                ProductItem productItem = new ProductItem()
                {
                    Name = "Lays Regular",
                    Price = 0.50,
                    CategoryId = categoryItem.Id
                };
                productItem.Id = db.AddProductItem(productItem);

                InventoryItem inventoryItem = new InventoryItem()
                {
                    Column = 1,
                    Row = 1,
                    Qty = 5,
                    ProductId = productItem.Id
                };
                inventoryItem.Id = db.AddInventoryItem(inventoryItem);

                // Add Product 2
                productItem.Name = "Pringles Barbeque";
                productItem.Price = 0.65;
                productItem.Id = db.AddProductItem(productItem);

                inventoryItem.Column = 2;
                inventoryItem.ProductId = productItem.Id;
                inventoryItem.Id = db.AddInventoryItem(inventoryItem);

                // Add Product 3
                productItem.Name = "Ruffles Sour Cream and Chives";
                productItem.Price = 0.75;
                productItem.Id = db.AddProductItem(productItem);

                inventoryItem.Column = 3;
                inventoryItem.ProductId = productItem.Id;
                inventoryItem.Id = db.AddInventoryItem(inventoryItem);

                // Add Product 4
                categoryItem.Name = "Candy";
                categoryItem.Noise = "Lick, Lick, Yum!";
                categoryItem.Id = db.AddCategoryItem(categoryItem);

                productItem.Name = "M&Ms Plain";
                productItem.Price = 0.55;
                productItem.CategoryId = categoryItem.Id;
                productItem.Id = db.AddProductItem(productItem);

                inventoryItem.Row = 2;
                inventoryItem.Column = 1;
                inventoryItem.ProductId = productItem.Id;
                inventoryItem.Id = db.AddInventoryItem(inventoryItem);

                // Add Product 5
                productItem.Name = "M&Ms Peanut";
                productItem.Price = 0.55;
                productItem.Id = db.AddProductItem(productItem);

                inventoryItem.Column = 2;
                inventoryItem.ProductId = productItem.Id;
                inventoryItem.Id = db.AddInventoryItem(inventoryItem);

                // Add Product 6
                productItem.Name = "Gummy Bears";
                productItem.Price = 1.00;
                productItem.Id = db.AddProductItem(productItem);

                inventoryItem.Column = 3;
                inventoryItem.ProductId = productItem.Id;
                inventoryItem.Id = db.AddInventoryItem(inventoryItem);

                // Add Product 7
                categoryItem.Name = "Nuts";
                categoryItem.Noise = "Munch, Munch, Yum!";
                categoryItem.Id = db.AddCategoryItem(categoryItem);

                productItem.Name = "Peanuts";
                productItem.Price = 1.00;
                productItem.CategoryId = categoryItem.Id;
                productItem.Id = db.AddProductItem(productItem);

                inventoryItem.Row = 3;
                inventoryItem.Column = 1;
                inventoryItem.ProductId = productItem.Id;
                inventoryItem.Id = db.AddInventoryItem(inventoryItem);

                // Add Product 8
                productItem.Name = "Cashews";
                productItem.Price = 1.50;
                productItem.Id = db.AddProductItem(productItem);

                inventoryItem.Column = 2;
                inventoryItem.ProductId = productItem.Id;
                inventoryItem.Id = db.AddInventoryItem(inventoryItem);

                // Add Product 9
                productItem.Name = "Sunflower Seeds";
                productItem.Price = 1.25;
                productItem.Id = db.AddProductItem(productItem);

                inventoryItem.Column = 3;
                inventoryItem.ProductId = productItem.Id;
                inventoryItem.Id = db.AddInventoryItem(inventoryItem);

                // Add Product 10
                categoryItem.Name = "Gum";
                categoryItem.Noise = "Chew, Chew, Yum!";
                categoryItem.Id = db.AddCategoryItem(categoryItem);

                productItem.Name = "Hubba Bubba";
                productItem.Price = 0.75;
                productItem.CategoryId = categoryItem.Id;
                productItem.Id = db.AddProductItem(productItem);

                inventoryItem.Row = 4;
                inventoryItem.Column = 1;
                inventoryItem.ProductId = productItem.Id;
                inventoryItem.Id = db.AddInventoryItem(inventoryItem);

                // Add Product 11
                productItem.Name = "Bubble Yum";
                productItem.Price = 0.75;
                productItem.Id = db.AddProductItem(productItem);

                inventoryItem.Column = 2;
                inventoryItem.ProductId = productItem.Id;
                inventoryItem.Id = db.AddInventoryItem(inventoryItem);

                // Add Product 12
                productItem.Name = "Trident";
                productItem.Price = 0.65;
                productItem.Id = db.AddProductItem(productItem);

                inventoryItem.Column = 3;
                inventoryItem.ProductId = productItem.Id;
                inventoryItem.Id = db.AddInventoryItem(inventoryItem);
                scope.Complete();
            }
        }                
    }
}
