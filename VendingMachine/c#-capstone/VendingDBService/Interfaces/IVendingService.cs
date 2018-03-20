using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService.Models;

namespace VendingService.Interfaces
{
    public interface IVendingService
    {
        //Vending
        List<VendingItem> GetVendingItems();
        void AddVendingItem(VendingItem item);

        //Category
        int AddCategoryItem(CategoryItem item);
        bool UpdateCategoryItem(CategoryItem item);
        void DeleteCategoryItem(int categoryId);
        CategoryItem GetCategoryItem(int categoryId);
        List<CategoryItem> GetCategoryItems();

        //Inventory
        int AddInventoryItem(InventoryItem item);
        bool UpdateInventoryItem(InventoryItem item);
        void DeleteInventoryItem(int inventoryId);
        InventoryItem GetInventoryItem(int inventoryId);
        List<InventoryItem> GetInventoryItems();

        //Product
        int AddProductItem(ProductItem item);
        bool UpdateProductItem(ProductItem item);
        void DeleteProductItem(int inventoryId);
        ProductItem GetProductItem(int inventoryId);
        List<ProductItem> GetProductItems();

    }
}
