using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace VendingService
{
    public class VendingDBService : IVendingService
    {
        private string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=VendingMachine;Integrated Security=true";

        public List<InventoryItem> GetInventoryItems()
        {
            List<InventoryItem> inventory = new List<InventoryItem>();
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
                        inventory.Add(GetInventoryItemFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return inventory;
        }

        private InventoryItem GetInventoryItemFromReader(SqlDataReader reader)
        {
            InventoryItem item = new InventoryItem();

            item.CategoryName = Convert.ToString(reader["CategoryName"]);
            item.ProductName = Convert.ToString(reader["ProductName"]);
            item.Qty = Convert.ToInt32(reader["Qty"]);
            item.Price = Convert.ToDouble(reader["Price"]);
            item.RowLocation = Convert.ToInt32(reader["Row"]);
            item.ColumnLocation = Convert.ToInt32(reader["Col"]);
            item.ConsumeMessage = Convert.ToString(reader["Noise"]);

            return item;
        }

        public void AddInventoryItem(InventoryItem item)
        {
            List<InventoryItem> inventory = new List<InventoryItem>();
            const string addProductSQL = "INSERT Product (Name, Price, CategoryId) VALUES (@ProductName, @Price, @CategoryId);";
            const string addCategorySQL = "INSERT Category (Name, Noise) VALUES (@CategoryName, @Noise);";
            const string addInventorySQL = "INSERT Inventory (Qty, Row, Col, ProductId) VALUES (@Qty, @Row, @Col, @ProductId);";
            const string getLastIdSQL = "SELECT CAST(SCOPE_IDENTITY() as int);";

            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(addCategorySQL + getLastIdSQL, conn);
                    cmd.Parameters.AddWithValue("@CategoryName", item.CategoryName);
                    cmd.Parameters.AddWithValue("@Noise", item.ConsumeMessage);
                    int lastId = (int)cmd.ExecuteScalar();

                    cmd.CommandText = addProductSQL + getLastIdSQL;
                    cmd.Parameters.AddWithValue("@ProductName", item.ProductName);
                    cmd.Parameters.AddWithValue("@Price", item.Price);
                    cmd.Parameters.AddWithValue("@CategoryId", lastId);
                    lastId = (int)cmd.ExecuteScalar();

                    cmd.CommandText = addInventorySQL;
                    cmd.Parameters.AddWithValue("@Qty", item.Qty);
                    cmd.Parameters.AddWithValue("@Row", item.RowLocation);
                    cmd.Parameters.AddWithValue("@Col", item.ColumnLocation);
                    cmd.Parameters.AddWithValue("@ProductId", lastId);
                    cmd.ExecuteNonQuery();                        
                }
                scope.Complete();
            }
        }
    }
}
