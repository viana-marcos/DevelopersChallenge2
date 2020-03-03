using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class TransactionRepository
    {
        private readonly BankTransactionContext _context;

        public TransactionRepository(BankTransactionContext context) 
        {
            this._context = context;
        }

        public void saveTransaction(Transaction transaction) 
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

        }

    }
}
