using System;
using API.Database.Transactions;
using API.Interfaces.Transactions;
namespace API.Model
{
    public class itemTransaction
    {
        public int TransactionID { get; set; }
        public string InventoryItem { get; set; }
        public string EmployeeID { get; set; }
        public string Rented { get; set; }

        public string DueBack { get; set; }

        public string Returned { get; set; }

        public ICreateTransactions CreateBehavior { get; set; } // CreateBehavior for Create class
        public IReadTransactions ReadBehavior { get; set; } // ReadBehavior for Read class
        public IUpdateTransactions UpdateBehavior { get; set; } // UpdateBehavior for Update class
        public IDeleteTransactions DeleteBehavior { get; set; } // DeleteBehavior for Delete class

        public itemTransaction()
        {
            CreateBehavior = new CreateTransactions();
            ReadBehavior = new ReadTransactions();
            UpdateBehavior = new UpdateTransactions();
            DeleteBehavior = new DeleteTransactions();
            Returned = new String(Returned);
        }
        public override string ToString()
        {
            return InventoryItem + " " + EmployeeID + " " + Rented + " " + DueBack + " " + Returned;
        }
    }
}