using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    public class BankTransaction
    {
        public decimal Amount { get; }
        public DateTime TransactionDate { get; }

        public BankTransaction(decimal amount)
        {
            Amount = amount;
            TransactionDate = DateTime.Now;
        }
    }
}
