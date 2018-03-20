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
        #region Variables

        private const string _getLastIdSQL = "SELECT CAST(SCOPE_IDENTITY() as int);";
        private string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=VendingMachine;Integrated Security=true";
        
        #endregion

        #region Vending Methods

        public List<VendingItem> GetVendingItems()
        {
            List<VendingItem> inventory = new List<VendingItem>();
            const string getInventoryItemsSQL = "Select Inventory.*, Product.Id, Product.Name As 'ProductName', " +
                                                    "Product.Price, Product.CategoryId, Category.Id, Category.Name As 'CategoryName', " +
                                                    "Category.Noise " +
                                                "From Product " +
                                                "Join Category On Category.Id = Product.CategoryId " +
                                                "Join Inventory On Inventory.ProductId = Product.Id;";

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

            return inventory;
        }

        private VendingItem GetVendingItemFromReader(SqlDataReader reader)
        {
            VendingItem item = new VendingItem();

            item.Category = GetCategoryItemFromReader(reader);
            item.Inventory = GetInventoryItemFromReader(reader);
            item.Product = GetProductItemFromReader(reader);

            return item;
        }

        #endregion

        #region Category Methods

        public int AddCategoryItem(CategoryItem item)
        {
            const string sql = "INSERT Category (Name, Noise) VALUES (@Name, @Noise);";            
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql + _getLastIdSQL, conn);
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Noise", item.Noise);
                item.Id = (int)cmd.ExecuteScalar();
            }

            return item.Id;
        }

        public bool UpdateCategoryItem(CategoryItem item)
        {
            bool isSuccessful = false;

            const string sql = "UPDATE Category SET Name = @Name, Noise = @Noise WHERE Id = @Id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
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
            const string sql = "DELETE FROM Category WHERE Id = @Id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", categoryId);
                cmd.ExecuteNonQuery();
            }
        }

        public CategoryItem GetCategoryItem(int categoryId)
        {
            CategoryItem category = new CategoryItem();
            const string sql = "SELECT Category.Id, Category.Name As 'CategoryName', Category.Noise FROM Category WHERE Id = @Id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", categoryId);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    category = GetCategoryItemFromReader(reader);
                }
            }

            return category;
        }

        public List<CategoryItem> GetCategoryItems()
        {
            List<CategoryItem> categories = new List<CategoryItem>();
            const string sql = "Select Category.Id, Category.Name As 'CategoryName', Category.Noise From Category;";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
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
            item.Name = Convert.ToString(reader["CategoryName"]);
            item.Noise = Convert.ToString(reader["Noise"]);

            return item;
        }

        #endregion

        #region Product Methods

        public int AddProductItem(ProductItem item)
        {
            const string sql = "INSERT Product (Name, Price, CategoryId) VALUES (@Name, @Price, @CategoryId);";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql + _getLastIdSQL, conn);
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Price", item.Price);
                cmd.Parameters.AddWithValue("@CategoryId", item.CategoryId);
                item.Id = (int)cmd.ExecuteScalar();
            }

            return item.Id;
        }

        public bool UpdateProductItem(ProductItem item)
        {
            bool isSuccessful = false;

            const string sql = "UPDATE Product SET Name = @Name, Price = @Price, CategoryId = @CategoryId WHERE Id = @Id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Price", item.Price);
                cmd.Parameters.AddWithValue("@CategoryId", item.CategoryId);
                cmd.Parameters.AddWithValue("@Id", item.Id);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    isSuccessful = true;
                }
            }

            return isSuccessful;
        }

        public void DeleteProductItem(int productId)
        {
            const string sql = "DELETE FROM Product WHERE Id = @Id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", productId);
                cmd.ExecuteNonQuery();
            }
        }

        public ProductItem GetProductItem(int productId)
        {
            ProductItem product = new ProductItem();
            const string sql = "SELECT Product.Id, Product.Name As 'ProductName', Product.Price, Product.CategoryId " +
                               "FROM Product WHERE Id = @Id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", productId);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    product = GetProductItemFromReader(reader);
                }
            }

            return product;
        }

        public List<ProductItem> GetProductItems()
        {
            List<ProductItem> products = new List<ProductItem>();
            const string sql = "SELECT Product.Id, Product.Name As 'ProductName', Product.Price, Product.CategoryId FROM Product;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(GetProductItemFromReader(reader));
                }
            }

            return products;
        }

        private ProductItem GetProductItemFromReader(SqlDataReader reader)
        {
            ProductItem item = new ProductItem();

            item.Id = Convert.ToInt32(reader["Id"]);
            item.Name = Convert.ToString(reader["ProductName"]);
            item.Price = Convert.ToDouble(reader["Price"]);
            item.CategoryId = Convert.ToInt32(reader["CategoryId"]);

            return item;
        }

        #endregion

        #region Inventory Methods

        public int AddInventoryItem(InventoryItem item)
        {
            const string sql = "INSERT Inventory (Qty, Row, Col, ProductId) VALUES (@Qty, @Row, @Col, @ProductId);";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql + _getLastIdSQL, conn);
                cmd.Parameters.AddWithValue("@Qty", item.Qty);
                cmd.Parameters.AddWithValue("@Row", item.Row);
                cmd.Parameters.AddWithValue("@Col", item.Column);
                cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                item.Id = (int)cmd.ExecuteScalar();
            }

            return item.Id;
        }

        public bool UpdateInventoryItem(InventoryItem item)
        {
            bool isSuccessful = false;

            const string sql = "UPDATE Inventory SET Qty = @Qty, Row = @Row, Col = @Col, ProductId = @ProductId WHERE Id = @Id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Qty", item.Qty);
                cmd.Parameters.AddWithValue("@Row", item.Row);
                cmd.Parameters.AddWithValue("@Col", item.Column);
                cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                cmd.Parameters.AddWithValue("@Id", item.Id);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    isSuccessful = true;
                }
            }

            return isSuccessful;
        }

        public void DeleteInventoryItem(int inventoryId)
        {
            const string sql = "DELETE FROM Inventory WHERE Id = @Id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", inventoryId);
                cmd.ExecuteNonQuery();
            }
        }

        public InventoryItem GetInventoryItem(int inventoryId)
        {
            InventoryItem inventory = new InventoryItem();
            const string sql = "SELECT * FROM Inventory WHERE Id = @Id;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", inventoryId);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    inventory = GetInventoryItemFromReader(reader);
                }
            }

            return inventory;
        }

        public List<InventoryItem> GetInventoryItems()
        {
            List<InventoryItem> inventory = new List<InventoryItem>();
            const string sql = "SELECT * FROM Inventory;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    inventory.Add(GetInventoryItemFromReader(reader));
                }
            }

            return inventory;
        }

        private InventoryItem GetInventoryItemFromReader(SqlDataReader reader)
        {
            InventoryItem item = new InventoryItem();

            item.Id = Convert.ToInt32(reader["Id"]);
            item.Qty = Convert.ToInt32(reader["Qty"]);
            item.Column = Convert.ToInt32(reader["Col"]);
            item.Row = Convert.ToInt32(reader["Row"]);
            item.ProductId = Convert.ToInt32(reader["ProductId"]);

            return item;
        }
        #endregion

    }
}
