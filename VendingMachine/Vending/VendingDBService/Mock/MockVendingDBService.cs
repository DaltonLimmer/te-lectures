using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService.Interfaces;
using VendingService.Models;

namespace VendingService.Mock
{
    public class MockVendingDBService : IVendingService
    {
        #region Variables

        private Dictionary<int, CategoryItem> _categoryItems = new Dictionary<int, CategoryItem>();
        private Dictionary<int, InventoryItem> _inventoryItems = new Dictionary<int, InventoryItem>();
        private Dictionary<int, ProductItem> _productItems = new Dictionary<int, ProductItem>();

        private int _categoryId = 1;
        private int _productId = 1;
        private int _inventoryId = 1;

        #endregion

        #region Vending

        public List<VendingItem> GetVendingItems()
        {
            List<VendingItem> items = new List<VendingItem>();

            try
            {
                foreach(InventoryItem item in _inventoryItems.Values.ToList())
                {
                    VendingItem vendingItem = new VendingItem();
                    vendingItem.Inventory = item;
                    vendingItem.Product = _productItems[item.ProductId];
                    vendingItem.Category = _categoryItems[vendingItem.Product.CategoryId];
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Mock database is corrupt. All inventory slots must contain a " +
                                    "reference to a product and all products must contain a reference to a category.", ex);
            }

            return items;
        }

        #endregion

        #region Category

        public int AddCategoryItem(CategoryItem item)
        {
            item.Id = _categoryId++;
            _categoryItems.Add(item.Id, item);
            return item.Id;
        }

        public bool UpdateCategoryItem(CategoryItem item)
        {
            if(_categoryItems.ContainsKey(item.Id))
            {
                _categoryItems[item.Id] = item;
            }
            else
            {
                throw new Exception("Item does not exist.");
            }
            return true;
        }

        public void DeleteCategoryItem(int categoryId)
        {
            if (_categoryItems.ContainsKey(categoryId))
            {
                _categoryItems.Remove(categoryId);
            }
            else
            {
                throw new Exception("Item does not exist.");
            }
        }

        public CategoryItem GetCategoryItem(int categoryId)
        {
            CategoryItem item = null;

            if (_categoryItems.ContainsKey(categoryId))
            {
                item = _categoryItems[categoryId];
            }
            else
            {
                throw new Exception("Item does not exist.");
            }

            return item;
        }

        public List<CategoryItem> GetCategoryItems()
        {
            return _categoryItems.Values.ToList();
        }

        #endregion

        #region Inventory

        public int AddInventoryItem(InventoryItem item)
        {
            item.Id = _inventoryId++;
            _inventoryItems.Add(item.Id, item);
            return item.Id;
        }

        public bool UpdateInventoryItem(InventoryItem item)
        {
            if (_inventoryItems.ContainsKey(item.Id))
            {
                _inventoryItems[item.Id] = item;
            }
            else
            {
                throw new Exception("Item does not exist.");
            }
            return true;
        }

        public void DeleteInventoryItem(int inventoryId)
        {
            if (_inventoryItems.ContainsKey(inventoryId))
            {
                _inventoryItems.Remove(inventoryId);
            }
            else
            {
                throw new Exception("Item does not exist.");
            }
        }

        public InventoryItem GetInventoryItem(int inventoryId)
        {
            InventoryItem item = null;

            if (_inventoryItems.ContainsKey(inventoryId))
            {
                item = _inventoryItems[inventoryId];
            }
            else
            {
                throw new Exception("Item does not exist.");
            }

            return item;
        }

        public List<InventoryItem> GetInventoryItems()
        {
            return _inventoryItems.Values.ToList();
        }

        #endregion

        #region Product

        public int AddProductItem(ProductItem item)
        {
            item.Id = _productId++;
            _productItems.Add(item.Id, item);
            return item.Id;
        }

        public bool UpdateProductItem(ProductItem item)
        {
            if (_productItems.ContainsKey(item.Id))
            {
                _productItems[item.Id] = item;
            }
            else
            {
                throw new Exception("Item does not exist.");
            }
            return true;
        }

        public void DeleteProductItem(int inventoryId)
        {
            if (_productItems.ContainsKey(inventoryId))
            {
                _productItems.Remove(inventoryId);
            }
            else
            {
                throw new Exception("Item does not exist.");
            }
        }

        public ProductItem GetProductItem(int inventoryId)
        {
            ProductItem item = null;

            if (_productItems.ContainsKey(inventoryId))
            {
                item = _productItems[inventoryId];
            }
            else
            {
                throw new Exception("Item does not exist.");
            }

            return item;
        }

        public List<ProductItem> GetProductItems()
        {
            return _productItems.Values.ToList();
        }

        #endregion
    }
}
