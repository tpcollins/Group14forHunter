using API.Interfaces.Transactions;
using System.Collections.Generic;
using API.Model;
using MySql.Data.MySqlClient;

namespace API.Database.Transactions
{
    public class ReadTransactions : IReadTransactions
    {
        public List<itemTransaction> ReadAllTransactions()
        {
            List<itemTransaction> transactionList = new List<itemTransaction>();

            ConnectionString tempCs = new ConnectionString();
            string cs = tempCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Transactions";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                transactionList.Add(new itemTransaction() { TransactionID = rdr.GetInt32(0), InventoryItem = rdr.GetString(1), EmployeeID = rdr.GetString(2), Rented = rdr.GetString(3), DueBack = rdr.GetString(4), Returned = rdr.GetString(5) });
            }
            return transactionList;
        }

        public List<itemTransaction> ReadData(int i)
        {
            List<itemTransaction> transactionList = new List<itemTransaction>();

            string cs = new ConnectionString().Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Transactions WHERE employeeID = @id";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", i);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                transactionList.Add(new itemTransaction() { TransactionID = rdr.GetInt32(0), InventoryItem = rdr.GetString(1), EmployeeID = rdr.GetString(2), Rented = rdr.GetString(3), DueBack = rdr.GetString(4), Returned = rdr.GetString(5) });
            }

            return transactionList;
        }
    }
}