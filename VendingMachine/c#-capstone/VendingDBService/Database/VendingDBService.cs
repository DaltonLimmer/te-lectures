using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using VendingService.Interfaces;
using VendingService.Models;

namespace VendingService.Database
{
    public class VendingDBService : IVendingService
    {

        private const string _getLastIdSQL = "SELECT CAST(SCOPE_IDENTITY() as int);";
        private string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=VendingMachine;Integrated Security=true";

        #region Vending

        public void AddVendingItem(VendingItem item)
        {
            List<VendingItem> inventory = new List<VendingItem>();
            const string addProductSQL = "INSERT Product (Name, Price, CategoryId) VALUES (@ProductName, @Price, @CategoryId);";
            const string addCategorySQL = "INSERT Category (Name, Noise) VALUES (@CategoryName, @Noise);";
            const string addInventorySQL = "INSERT Inventory (Qty, Row, Col, ProductId) VALUES (@Qty, @Row, @Col, @ProductId);";
            
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(addCategorySQL + _getLastIdSQL, conn);
                    cmd.Parameters.AddWithValue("@CategoryName", item.CategoryName);
                    cmd.Parameters.AddWithValue("@Noise", item.Noise);
                    int lastId = (int)cmd.ExecuteScalar();

                    cmd.CommandText = addProductSQL + _getLastIdSQL;
                    cmd.Parameters.AddWithValue("@ProductName", item.ProductName);
                    cmd.Parameters.AddWithValue("@Price", item.Price);
                    cmd.Parameters.AddWithValue("@CategoryId", lastId);
                    lastId = (int)cmd.ExecuteScalar();

                    cmd.CommandText = addInventorySQL;
                    cmd.Parameters.AddWithValue("@Qty", item.Qty);
                    cmd.Parameters.AddWithValue("@Row", item.Row);
                    cmd.Parameters.AddWithValue("@Col", item.Column);
                    cmd.Parameters.AddWithValue("@ProductId", lastId);
                    cmd.ExecuteNonQuery();
                }
                scope.Complete();
            }
        }

        public List<VendingItem> GetVendingItems()
        {
            List<VendingItem> inventory = new List<VendingItem>();
            const string getInventoryItemsSQL = "Select Product.Name as 'ProductName', Product.Price, Inventory.Qty, Inventory.Row, " +
                                                    "Inventory.Col, Category.Name as 'CategoryName', Category.Noise " +
                                                "From Product Join Category On Category.Id = Product.CategoryId " +
                                                "Join Inventory On Inventory.ProductId = Product.Id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(getInventoryItemsSQL, conn);
                    var reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        inventory.Add(GetVendingItemFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return inventory;
        }

        private VendingItem GetVendingItemFromReader(SqlDataReader reader)
        {
            VendingItem item = new VendingItem();

            item.CategoryName = Convert.ToString(reader["CategoryName"]);
            item.ProductName = Convert.ToString(reader["ProductName"]);
            item.Qty = Convert.ToInt32(reader["Qty"]);
            item.Price = Convert.ToDouble(reader["Price"]);
            item.Row = Convert.ToInt32(reader["Row"]);
            item.Column = Convert.ToInt32(reader["Col"]);
            item.Noise = Convert.ToString(reader["Noise"]);

            return item;
        }
        
        #endregion

        #region Category

        public int AddCategoryItem(CategoryItem item)
        {
            int id = BaseItem.InvalidId;

            List<VendingItem> inventory = new List<VendingItem>();
            const string addCategorySQL = "INSERT Category (Name, Noise) VALUES (@Name, @Noise);";            
                        
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(addCategorySQL + _getLastIdSQL, conn);
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Noise", item.Noise);
                id = (int)cmd.ExecuteScalar();
            }

            return id;
        }

        public bool UpdateCategoryItem(CategoryItem item)
        {
            bool isSuccessful = false;

            const string addCategorySQL = "UPDATE Category SET Name = @Name, Noise = @Noise WHERE Id = @Id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(addCategorySQL + _getLastIdSQL, conn);
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Noise", item.Noise);
                cmd.Parameters.AddWithValue("@Id", item.Id);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    isSuccessful = true;
                }
            }

            return isSuccessful;
        }

        public void DeleteCategoryItem(int categoryId)
        {
            const string addCategorySQL = "DELETE FROM Category WHERE Id = @Id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(addCategorySQL + _getLastIdSQL, conn);
                cmd.Parameters.AddWithValue("@Id", categoryId);
                cmd.ExecuteNonQuery();
            }
        }

        public CategoryItem GetCategoryItem(int categoryId)
        {
            CategoryItem category = new CategoryItem();
            const string getCategoryItemSQL = "SELECT * FROM Category WHERE Id = @Id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(getCategoryItemSQL, conn);
                    cmd.Parameters.AddWithValue("@Id", categoryId);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        category = GetCategoryItemFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return category;
        }

        public List<CategoryItem> GetCategoryItems()
        {
            List<CategoryItem> categories = new List<CategoryItem>();
            const string getCategoryItemsSQL = "Select * From Category;";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(getCategoryItemsSQL, conn);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        categories.Add(GetCategoryItemFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return categories;
        }

        private CategoryItem GetCategoryItemFromReader(SqlDataReader reader)
        {
            CategoryItem item = new CategoryItem();

            item.Id = Convert.ToInt32(reader["Id"]);
            item.Name = Convert.ToString(reader["Name"]);
            item.Noise = Convert.ToString(reader["Noise"]);

            return item;
        }

        #endregion

        #region Product

        public int AddProductItem(ProductItem item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProductItem(ProductItem item)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductItem(int inventoryId)
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

        #endregion

        #region Inventory

        public int AddInventoryItem(InventoryItem item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInventoryItem(InventoryItem item)
        {
            throw new NotImplementedException();
        }

        public void DeleteInventoryItem(int inventoryId)
        {
            throw new NotImplementedException();
        }

        public InventoryItem GetInventoryItem(int inventoryId)
        {
            throw new NotImplementedException();
        }

        List<InventoryItem> IVendingService.GetInventoryItems()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
