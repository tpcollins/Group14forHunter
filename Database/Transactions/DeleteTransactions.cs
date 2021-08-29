using API.Interfaces.Transactions;
using MySql.Data.MySqlClient;
using API.Model;

namespace API.Database.Transactions
{
    public class DeleteTransactions : IDeleteTransactions
    {
        public void DeleteData(int TransactionID)
        {
            ConnectionString tempCs = new ConnectionString();
            string cs = tempCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DELETE FROM Transactions where TransactionID = @TransactionID";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@TransactionID", TransactionID);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
        public static void DropTable(){
            ConnectionString myCs = new ConnectionString();
            string cs = myCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "DROP TABLE IF EXISTS Transactions";
            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }
    }
}