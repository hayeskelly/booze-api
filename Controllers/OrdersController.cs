using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuckIBooze.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuckIBooze.API.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly LiquorStoreContext db;
        public OrdersController(LiquorStoreContext db)
        {
            this.db = db;

            if (this.db.Orders.Count() == 0)
            {
                //handle this
            }
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
           return Ok(db.Orders);
        }

        [HttpGet("{id}", Name="GetOrder")]
        public IActionResult GetById(int id)
        {
            var order = db.Orders.Find(id);

            if(order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]Order order)
        {
            
            if(order == null)
            {
                return BadRequest();
            }

            this.db.Orders.Add(order);
            this.db.SaveChanges();

            return CreatedAtRoute("GetOrder", new {id = order.Id}, order);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Order newOrder)
        {
            if (newOrder == null || newOrder.Id != id)
            {
                return BadRequest();
            }

            this.db.Orders.Update(newOrder);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = this.db.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            this.db.Orders.Remove(order);
            this.db.SaveChanges();

            return NoContent();
        }
    }
    
}
