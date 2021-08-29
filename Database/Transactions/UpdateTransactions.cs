using API.Interfaces.Transactions;
using API.Model;
using MySql.Data.MySqlClient;
namespace API.Database.Transactions
{
    public class UpdateTransactions : IUpdateTransactions
    {
        public void UpdateData(itemTransaction item)
        {
            ConnectionString tempCs = new ConnectionString();
            string cs = tempCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE Transactions SET TransactionID = @TransactionID, InventoryItem = @InventoryItem, EmployeeID = @EmployeeID, Rented = @Rented, DueBack = @DueBack, Returned = @Returned WHERE TransactionID = @TransactionID";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@TransactionID", item.TransactionID);
            cmd.Parameters.AddWithValue("@InventoryItem", item.InventoryItem);
            cmd.Parameters.AddWithValue("@EmployeeID", item.EmployeeID);
            cmd.Parameters.AddWithValue("@Rented", item.Rented);
            cmd.Parameters.AddWithValue("@DueBack", item.DueBack);
            cmd.Parameters.AddWithValue("@Returned", item.Returned);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}