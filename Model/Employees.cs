using API.Database;
using API.Interfaces;

namespace API.Model
{
    public class Employees
    {
        public int EmployeeID{get;set;}
        public string EmpFName{get;set;}
        public string EmpLName{get;set;}

        public ICreateEmployee CreateBehavior{get;set;} // CreateBehavior for Create class
        public IReadEmployees ReadBehavior{get;set;} // ReadBehavior for Read class
        public IUpdateEmployees UpdateBehavior{get;set;} // UpdateBehavior for Update class
        public IDeleteEmployees DeleteBehavior{get;set;} // DeleteBehavior for Delete class

        public Employees(){
            CreateBehavior = new CreateEmployee();
            ReadBehavior = new ReadEmployees();
            UpdateBehavior = new UpdateEmployees();
            DeleteBehavior = new DeleteEmployees();
        }
        public override string ToString()
        {
            return EmployeeID + " " + EmpFName + " " + EmpLName;
        }
    }
}