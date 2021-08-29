using API.Interfaces;
using API.Model;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class CreateEmployee : ICreateEmployee
    {
        public static void CreateTable()
        {
            ConnectionString tempCs = new ConnectionString();
            string cs = tempCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "CREATE TABLE Employees(EmployeeID INTEGER PRIMARY KEY AUTO AUTO_INCREMENT, EmpFName TEXT, EmpLName TEXT)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }
        public void CreateEmployees(Employees employee)
        {
            ConnectionString tempCs = new ConnectionString();
            string cs = tempCs.Cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO Employees(EmpFName, EmpLName) VALUES(@EmpFName, @EmpLName)";
            using var cmd = new MySqlCommand(stm, con);
            //cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
            cmd.Parameters.AddWithValue("@EmpFName", employee.EmpFName);
            cmd.Parameters.AddWithValue("@EmpLName", employee.EmpLName);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}