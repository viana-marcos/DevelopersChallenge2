using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;




//Control responsible for uploading
namespace WebApplication1.Controllers


{
    [ApiController]
    [Route("[controller]")]
    public class UploadOFXController : ControllerBase
    {

        private readonly BankTransactionContext _context;

        public UploadOFXController(BankTransactionContext context)
        {
            _context = context;
        }

        // POST api/<controller>

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post()
        {
            var uploadService = new UploadService();
            List<Transaction> transactions = uploadService.GetTransactions(Request.Form.Files);

            _context.Add(transactions.ElementAt(transactions.Count -1));
            _context.Add(transactions.ElementAt(transactions.Count - 2));
            _context.Add(transactions.ElementAt(transactions.Count - 3));
            _context.Add(transactions.ElementAt(transactions.Count - 4));
            _context.Add(transactions.ElementAt(transactions.Count - 5));
            _context.SaveChanges();
            return Ok(transactions);
                       

        }        

    }


   
}