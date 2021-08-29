using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        // GETInventory: api/Inventory
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Inventory> Get()
        {
            Inventory inventory = new Inventory();
            return inventory.ReadBehavior.ReadAllInventory();
        }

        // GETInventory: api/Inventory/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get-Inventory")]
        public Inventory Get(int id)
        {
            //Return all individual inventory item
            Inventory inv = new Inventory();
            return inv.ReadBehavior.ReadInventoryItem(id);
        }

        // POST: api/Inventory
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Inventory inv)
        {
            inv.CreateBehavior.CreateData(inv);
        }

        // PUT: api/Inventory/5
        [EnableCors("AnotherPolicy")]
        [HttpPut()]
        public void Put([FromBody] Inventory inv)
        {
            //Console.WriteLine("STUFF: " + inv.RentStatus + inv.ItemCategory);
            inv.UpdateBehavior.UpdateInventoryItem(inv);
        }

        // DELETE: api/Inventory/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete()]
        public void Delete([FromBody] Inventory inv2)
        {
            Inventory inv = new Inventory();
            inv.DeleteBehavior.DeleteInventoryItem(inv2.Id);
        }
    }
}
