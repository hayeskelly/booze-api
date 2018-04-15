using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuckIBooze.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuckIBooze.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly LiquorStoreContext db;
        public ProductsController(LiquorStoreContext db)
        {
            this.db = db;

            if (this.db.Products.Count() == 0)
            {
                //handle this
            }
        }
        
        [HttpGet("beer", Name="GetBeer")]
        public List<string> GetBeer(string sup)
        {
            sup = "Beer";
            var mytypes = db.Products.Where(prod => prod.supertype == sup).Select(sub => sub.subtype).Distinct();
            List<string> types = mytypes.ToList();
            return types;
        }

        [HttpGet("wine", Name="GetWine")]
        public List<string> GetWine(string sup)
        {
            sup = "Wine";
            var mytypes = db.Products.Where(prod => prod.supertype == sup).Select(sub => sub.subtype).Distinct();
            List<string> types = mytypes.ToList();
            return types;
        }

        [HttpGet("liquor", Name="GetLiquor")]
        public List<string> GetLiquor(string sup)
        {
            sup = "Liquor";
            var mytypes = db.Products.Where(prod => prod.supertype == sup).Select(sub => sub.subtype).Distinct();
            List<string> types = mytypes.ToList();
            return types;
        }
        
        [HttpGet]
        public List<string> GetTypes()
        {
            var mytypes = db.Products.Select(type => type.supertype).Distinct();
            List<string> types = mytypes.ToList();
            return types;
        }
        
        [HttpGet("all", Name="GetAll")]
        public IActionResult GetAll()
        {
           return Ok(db.Products);
        }

        [HttpGet("{id}", Name="GetProduct")]
        public IActionResult GetById(int id)
        {
            var product = db.Products.Find(id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if(product == null)
            {
                return BadRequest();
            }

            this.db.Products.Add(product);
            this.db.SaveChanges();

            return CreatedAtRoute("GetProduct", new {id = product.Id}, product);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product newProduct)
        {
            if (newProduct == null || newProduct.Id != id)
            {
                return BadRequest();
            }
            var currentProduct = this.db.Products.FirstOrDefault(x => x.Id == id);

            if (currentProduct == null)
            {
                return NotFound();
            }

            this.db.Products.Update(currentProduct);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = this.db.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            this.db.Products.Remove(product);
            this.db.SaveChanges();

            return NoContent();
        }
    }
    
}
