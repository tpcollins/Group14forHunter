using API.Interfaces;
using API.Model;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class CreateInventory : ICreateInventory
    {
        public static void CreateTable()
        {
            ConnectionString tempCs = new ConnectionString();
            string cs = tempCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "CREATE TABLE inventory(Id INTEGER PRIMARY KEY AUTO_INCREMENT, Category TEXT, Status TEXT, ItemCondition TEXT, ItemCount INTEGER)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }

        public void CreateData(Inventory item)
        {
            ConnectionString tempCs = new ConnectionString();
            string cs = tempCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO inventory(category, status, ItemCondition, ItemCount) VALUES(@category, @status, @ItemCondition, @ItemCount)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@category", item.ItemCategory);
            cmd.Parameters.AddWithValue("@status", item.RentStatus);
            cmd.Parameters.AddWithValue("@ItemCondition", item.ItemCondition);
            cmd.Parameters.AddWithValue("@ItemCount", item.ItemCount);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}