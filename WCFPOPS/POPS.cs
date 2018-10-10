using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFPOPS
{
    public class POPS : IPOPS
    {
        string connectionString = "Data Source = Pal-PC; Initial Catalog = PurchaseOrderDb;Integrated Security = true";

        // Methods to perform Create Operations
        
        public void AddItem(Item item)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spAddItem", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ItemCode", item.ItemCode);
                command.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);
                command.Parameters.AddWithValue("@ItemRate", item.ItemRate);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public void AddSupplier(Supplier supplier)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spAddSupplier", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@SupplierNumber", supplier.SupplierNumber);
                command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                command.Parameters.AddWithValue("@SupplierAddress", supplier.SupplierAddress);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public void MakeOrder(POMaster pOMaster, List<PODetail> pODetails)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command1 = new SqlCommand("spAddPOMaster", con);
                    SqlCommand command2 = new SqlCommand("spAddPODetail", con);
                    command1.CommandType = CommandType.StoredProcedure;
                    command2.CommandType = CommandType.StoredProcedure;

                    command1.Parameters.AddWithValue("@PurchaseOrderNO", pOMaster.PurchaseOrderNO);
                    command1.Parameters.AddWithValue("@PurchaseDate", pOMaster.Date);
                    command1.Parameters.AddWithValue("@SupplierNumber", pOMaster.SupplierNumber);

                    con.Open();
                    command1.ExecuteNonQuery();

                    foreach (var orderItem in pODetails)
                    {
                        command2.Parameters.AddWithValue("@PurchaseOrderNO", orderItem.PurchaseOrderNO);
                        command2.Parameters.AddWithValue("@ItemCode", orderItem.ItemCode);
                        command2.Parameters.AddWithValue("@Quantity", orderItem.Quantity);

                        command2.ExecuteNonQuery();
                    }

                    con.Close();
                }
                scope.Complete();
            }
        }

        //Methods to perform Read Operations

        public List<Item> GetAllItems()
        {
            List<Item> itemsList = new List<Item>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spGetAllItems", con);
                command.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Item item = new Item();

                    item.ItemCode = (string)reader["ItemCode"];
                    item.ItemDescription = (string)reader["ItemDescription"];
                    item.ItemRate = (decimal)reader["ItemRate"];

                    itemsList.Add(item);
                }
                con.Close();
            }

            return itemsList;
        }

        public List<Order> GetAllOrders()
        {
            List<Order> ordersList = new List<Order>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spGetAllOrders", con);
                command.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Order order = new Order();

                    order.PurchaseOrderNO = (string)reader["PurchaseOrderNO"];
                    order.ItemDescription = (string)reader["ItemDescription"];
                    order.Quantity = (string)reader["Quantity"];
                    order.Date = (DateTime)reader["Date"];
                    order.SupplierName = (string)reader["SupplierName"];

                    ordersList.Add(order);
                }
                con.Close();
            }

            return ordersList;
        }

        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliersList = new List<Supplier>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spGetAllSuppliers", con);
                command.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Supplier supplier = new Supplier();

                    supplier.SupplierNumber = (string)reader["SupplierNumber"];
                    supplier.SupplierName = (string)reader["SupplierName"];
                    supplier.SupplierAddress = (string)reader["SupplierAddress"];

                    suppliersList.Add(supplier);
                }
                con.Close();
            }

            return suppliersList;
        }

        //Methods to perform Update Operations

        public void UpdateSupplier(Supplier supplier)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spUpdateSupplier", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@SupplierNumber", supplier.SupplierNumber);
                command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                command.Parameters.AddWithValue("@SupplierAddress", supplier.SupplierAddress);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateItem(Item item)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spUpdateItem", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ItemCode", item.ItemCode);
                command.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);
                command.Parameters.AddWithValue("@ItemRate", item.ItemRate);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        //Methods to perform Delete Operations

        public void DeleteSupplier(string supplierNumber)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spDeleteSupplier", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@SupplierNumber", supplierNumber);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteItem(string itemCode)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spDeleteItem", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ItemCode", itemCode);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteOrder(string purchaseOrderNO)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("spDeleteOrder", con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PurchaseOrderNO", purchaseOrderNO);

                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
                scope.Complete();

            }

        }
    }
}
