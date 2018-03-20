﻿using System;
using System.Data.SqlClient;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingService.Database;
using VendingService.Models;

namespace VendingIntegrationTests
{
    [TestClass()]
    public class DatabaseTests
    {
        private TransactionScope tran;      //<-- used to begin a transaction during initialize and rollback during cleanup
        private VendingDBService _db = new VendingDBService();

        private const string CategoryName = "TestCategory";
        private const string CategoryNoise = "CategoryNoise";
        private int _categoryId = BaseItem.InvalidId;

        private const string ProductName = "TestProduct";
        private const double ProductPrice = 0.50;
        private int _productId = BaseItem.InvalidId;

        private const int InventoryRow = 1;
        private const int InventoryCol = 1;
        private const int InventoryQty = 10;
        private int _inventoryId = BaseItem.InvalidId;

        /// <summary>
        /// Set up the database before each test  
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            // Initialize a new transaction scope. This automatically begins the transaction.
            tran = new TransactionScope();

            // Add category item
            _categoryId = _db.AddCategoryItem(
                new CategoryItem()
                {
                    Name = CategoryName,
                    Noise = CategoryNoise
                });

            // Add product item
            _productId = _db.AddProductItem(
                new ProductItem()
                {
                    Name = ProductName,
                    Price = ProductPrice,
                    CategoryId = _categoryId
                });

            // Add inventory item
            _inventoryId = _db.AddInventoryItem(
                new InventoryItem()
                {
                    Row = InventoryRow,
                    Column = InventoryCol,
                    Qty = InventoryQty,
                    ProductId = _productId
                });
        }

        /// <summary>
        /// Cleanup runs after every single test
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose(); //<-- disposing the transaction without committing it means it will get rolled back
        }

        /// <summary>
        /// Tests the product POCO methods
        /// </summary>
        [TestMethod()]
        public void TestProduct()
        {
            // Test add product
            ProductItem item = new ProductItem();
            item.CategoryId = _categoryId;
            item.Name = "Blah";
            item.Price = 1.00;
            int id = _db.AddProductItem(item);
            Assert.AreNotEqual(0, id);

            ProductItem itemGet = _db.GetProductItem(id);
            Assert.AreEqual(item.Name, itemGet.Name);
            Assert.AreEqual(item.Price, itemGet.Price);
            Assert.AreEqual(item.CategoryId, itemGet.CategoryId);

            // Test update product
            item.Name = "What";
            item.Price = 1.50;
            Assert.IsTrue(_db.UpdateProductItem(item));

            itemGet = _db.GetProductItem(id);
            Assert.AreEqual(item.Name, itemGet.Name);
            Assert.AreEqual(item.Price, itemGet.Price);
            Assert.AreEqual(item.CategoryId, itemGet.CategoryId);

            // Test delete product
            _db.DeleteProductItem(id);
            var products = _db.GetProductItems();
            foreach(var product in products)
            {
                Assert.AreNotEqual(id, product.Id);
            }
        }

        /// <summary>
        /// Tests the category POCO methods
        /// </summary>
        [TestMethod()]
        public void TestCategory()
        {
            // Test add category
            CategoryItem item = new CategoryItem();
            item.Name = "Blah";
            item.Noise = "Bang";
            int id = _db.AddCategoryItem(item);
            Assert.AreNotEqual(0, id);

            CategoryItem itemGet = _db.GetCategoryItem(id);
            Assert.AreEqual(item.Name, itemGet.Name);
            Assert.AreEqual(item.Noise, itemGet.Noise);

            // Test update category
            item.Name = "What";
            item.Noise = "Kerplunk";
            Assert.IsTrue(_db.UpdateCategoryItem(item));

            itemGet = _db.GetCategoryItem(id);
            Assert.AreEqual(item.Name, itemGet.Name);
            Assert.AreEqual(item.Noise, itemGet.Noise);

            // Test delete category
            _db.DeleteCategoryItem(id);
            var categories = _db.GetCategoryItems();
            foreach (var category in categories)
            {
                Assert.AreNotEqual(id, category.Id);
            }
        }

        /// <summary>
        /// Tests the inventory POCO methods
        /// </summary>
        [TestMethod()]
        public void TestInventory()
        {
            // Test add inventory
            InventoryItem item = new InventoryItem();
            item.Column = 2;
            item.Row = 3;
            item.Qty = 4;
            item.ProductId = _productId;
            int id = _db.AddInventoryItem(item);
            Assert.AreNotEqual(0, id);

            InventoryItem itemGet = _db.GetInventoryItem(id);
            Assert.AreEqual(item.Column, itemGet.Column);
            Assert.AreEqual(item.Row, itemGet.Row);
            Assert.AreEqual(item.Qty, itemGet.Qty);
            Assert.AreEqual(item.ProductId, itemGet.ProductId);

            // Test update inventory
            item.Column = 3;
            item.Row = 4;
            item.Qty = 6;
            Assert.IsTrue(_db.UpdateInventoryItem(item));

            itemGet = _db.GetInventoryItem(id);
            Assert.AreEqual(item.Column, itemGet.Column);
            Assert.AreEqual(item.Row, itemGet.Row);
            Assert.AreEqual(item.Qty, itemGet.Qty);
            Assert.AreEqual(item.ProductId, itemGet.ProductId);

            // Test delete inventory
            _db.DeleteInventoryItem(id);
            var inventoryItems = _db.GetInventoryItems();
            foreach (var inventoryItem in inventoryItems)
            {
                Assert.AreNotEqual(id, inventoryItem.Id);
            }
        }
    }
}
