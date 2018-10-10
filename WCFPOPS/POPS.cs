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
    }
}
