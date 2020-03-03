using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly BankTransactionContext _context;

        public TransactionController(BankTransactionContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return _context.Transactions.ToList();
            
        }
    }
}

