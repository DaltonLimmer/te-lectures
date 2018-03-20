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
        List<CategoryItem> _categoryItems = new List<CategoryItem>();
        List<InventoryItem> _inventoryItems = new List<InventoryItem>();
        List<ProductItem> _productItems = new List<ProductItem>();

        public MockVendingDBService()
        {
            
        }

        public int AddCategoryItem(CategoryItem item)
        {
            throw new NotImplementedException();
        }

        public int AddInventoryItem(InventoryItem item)
        {
            throw new NotImplementedException();
        }

        public int AddProductItem(ProductItem item)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategoryItem(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void DeleteInventoryItem(int inventoryId)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductItem(int inventoryId)
        {
            throw new NotImplementedException();
        }

        public CategoryItem GetCategoryItem(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<CategoryItem> GetCategoryItems()
        {
            throw new NotImplementedException();
        }

        public InventoryItem GetInventoryItem(int inventoryId)
        {
            throw new NotImplementedException();
        }

        public List<InventoryItem> GetInventoryItems()
        {
            throw new NotImplementedException();
        }

        public ProductItem GetProductItem(int inventoryId)
        {
            throw new NotImplementedException();
        }

        public List<ProductItem> GetProductItems()
        {
            throw new NotImplementedException();
        }

        public List<VendingItem> GetVendingItems()
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategoryItem(CategoryItem item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInventoryItem(InventoryItem item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProductItem(ProductItem item)
        {
            throw new NotImplementedException();
        }
    }
}
