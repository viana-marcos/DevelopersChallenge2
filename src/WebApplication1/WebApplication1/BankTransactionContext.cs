using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class BankTransactionContext: DbContext
    {

        public BankTransactionContext(DbContextOptions<BankTransactionContext> options)
            : base(options)
        { }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().ToTable("transacao");
           
        }
    }
}
