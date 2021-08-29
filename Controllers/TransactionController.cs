using System.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Interfaces.Transactions;
using API.Model;
using API.Database.Transactions;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        // GETTransaction: api/Transaction
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<itemTransaction> Get()
        {
            itemTransaction itemT = new itemTransaction();
            return itemT.ReadBehavior.ReadAllTransactions();
        }

        // GETTransaction: api/Transaction/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get-Transaction")]
        public List<itemTransaction> Get(int id)
        {
            //Return all individual transaction item
            itemTransaction itemT = new itemTransaction();
            return itemT.ReadBehavior.ReadData(id);
        }

        // POST: api/Transaction
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] itemTransaction item)
        {
            item.CreateBehavior.CreateData(item);
        }

        // PUT: api/Transaction/5
        [EnableCors("AnotherPolicy")]
        [HttpPut()]
        public void Put([FromBody] itemTransaction item)
        {
            item.UpdateBehavior.UpdateData(item);
        }

        // DELETE: api/Transaction/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            itemTransaction itemT = new itemTransaction();
            itemT.DeleteBehavior.DeleteData(id);
        }
    }
}
