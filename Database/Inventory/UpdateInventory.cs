using API.Interfaces;
using API.Model;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class UpdateInventory : IUpdateInventory
    {
        public void UpdateInventoryItem(Inventory item){
            ConnectionString tempCs = new ConnectionString();
            string cs = tempCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "UPDATE inventory SET Category = @Category, Status = @Status, ItemCondition = @ItemCondition, ItemCount = @ItemCount WHERE Id = @Id";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@Category", item.ItemCategory);
            cmd.Parameters.AddWithValue("@Status", item.RentStatus);
            cmd.Parameters.AddWithValue("@ItemCondition", item.ItemCondition);
            cmd.Parameters.AddWithValue("@ItemCount", item.ItemCount);
            cmd.Parameters.AddWithValue("@Id", item.Id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}