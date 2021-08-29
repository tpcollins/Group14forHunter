using System.Collections.Generic;
using API.Interfaces;
using API.Model;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class ReadEmployees : IReadEmployees
    {
        public List<Employees> ReadAllEmployees()
        {
            List<Employees> employeeList = new List<Employees>();

            ConnectionString tempCs = new ConnectionString();
            string cs = tempCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Employees";
            using var cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read()){
                Employees temp = new Employees(){EmployeeID = rdr.GetInt32(0), EmpFName = rdr.GetString(1), EmpLName = rdr.GetString(2)};
                employeeList.Add(temp);
            }
            return employeeList;
        }
    }
}