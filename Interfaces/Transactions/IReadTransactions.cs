using System.Transactions;
using System.Collections.Generic;
using API.Model;

namespace API.Interfaces.Transactions
{
    public interface IReadTransactions
    {
        public List<itemTransaction> ReadAllTransactions();

        public List<itemTransaction> ReadData(int i);
    }
}