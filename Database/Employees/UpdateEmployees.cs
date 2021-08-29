using System.Collections.Generic;
using API.Interfaces;
using API.Model;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class UpdateEmployees : IUpdateEmployees
    {
        public void UpdateEmployee(Employees employee)
        {
            ConnectionString tempCs = new ConnectionString();
            string cs = tempCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "UPDATE Employees SET EmployeeID = @EmployeeID, EmpFName = @EmpFName, EmpLName = @EmpLName WHERE EmployeeID = @EmployeeID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
            cmd.Parameters.AddWithValue("@EmpFName", employee.EmpFName);
            cmd.Parameters.AddWithValue("@EmpLName", employee.EmpLName);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}