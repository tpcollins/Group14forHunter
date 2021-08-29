using System;
using System.Collections.Generic;
using API.Interfaces;
using API.Model;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class ReadInventory : IReadInventory
    {
        public Inventory ReadInventoryItem(int id)
        {
            List<Inventory> invList = new List<Inventory>();

            string cs = new ConnectionString().Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM inventory WHERE Id = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                invList.Add(new Inventory() { Id = rdr.GetInt32(0), ItemCategory = rdr.GetString(1), RentStatus = rdr.GetString(2), ItemCondition = rdr.GetString(3), ItemCount = rdr.GetInt32(4) });
            }

            return invList[0];
        }

        public List<Inventory> ReadAllInventory()
        {
            List<Inventory> inventoryList = new List<Inventory>();

            ConnectionString tempCs = new ConnectionString();
            string cs = tempCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM inventory";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                inventoryList.Add(new Inventory() { Id = rdr.GetInt32(0), ItemCategory = rdr.GetString(1), RentStatus = rdr.GetString(2), ItemCondition = rdr.GetString(3), ItemCount = rdr.GetInt32(4) });
            }
            return inventoryList;
        }
    }
}