using API.Interfaces;
using API.Model;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class DeleteInventory : IDeleteInventory
    {
        public static void DropTable(){
            ConnectionString myCs = new ConnectionString();
            string cs = myCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "DROP TABLE IF EXISTS inventory";
            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }

        public void DeleteInventoryItem(int id)
        {
            ConnectionString tempCs = new ConnectionString();
            string cs = tempCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "DELETE FROM inventory WHERE id = @id";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}