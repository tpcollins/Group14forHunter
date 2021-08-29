using System.Collections.Generic;
using API.Model;
namespace API.Interfaces
{
    public interface IReadEmployees
    {
         public List<Employees> ReadAllEmployees();
    }
}