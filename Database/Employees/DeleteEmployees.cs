using System.Collections.Generic;
using API.Interfaces;
using API.Model;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class DeleteEmployees : IDeleteEmployees
    {
        public static void DropTable(){
            ConnectionString myCs = new ConnectionString();
            string cs = myCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "DROP TABLE IF EXISTS Employees";
            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }
        public void DeleteEmployee(int EmployeeID)
        {
            ConnectionString tempCs = new ConnectionString();
            string cs = tempCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}