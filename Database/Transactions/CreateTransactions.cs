using API.Interfaces;
using API.Interfaces.Transactions;
using API.Model;
using MySql.Data.MySqlClient;

namespace API.Database.Transactions
{
    public class CreateTransactions : ICreateTransactions
    {
        public void CreateData(itemTransaction item)
        {
            ConnectionString tempCs = new ConnectionString();
            string cs = tempCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO Transactions(TransactionID, InventoryItem, EmployeeID, Rented, DueBack, Returned) VALUES(@TransactionID, @InventoryItem, @EmployeeID, @Rented, @DueBack, @Returned)";
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
        public static void CreateTable(){
            ConnectionString tempCs = new ConnectionString();
            string cs = tempCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "CREATE TABLE Transactions(TransactionID INTEGER PRIMARY KEY AUTO_INCREMENT, InventoryItem TEXT, EmployeeID TEXT, Rented TEXT, DueBack TEXT, Returned TEXT)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }
    }
}