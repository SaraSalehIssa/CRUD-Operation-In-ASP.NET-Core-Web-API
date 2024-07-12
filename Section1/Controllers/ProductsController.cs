using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Section1.Data;
using Section1.Models;

namespace Section1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

        /* Section 1
List<Product> products = new List<Product>
{
new Product{Id=1, Name="Laptop", Description="This is Laptop"},
new Product{Id=2, Name="Phone", Description="This is Phone"},
new Product{Id=3, Name="Camera", Description="This is Camera"}
};

[HttpGet]
public IActionResult GetAll()
{
return Ok(Products);
}

[HttpGet("{id}")]
public IActionResult GetById(int id)
{
var product = products.Find(product => product.Id == id);

if(product is null)
return NotFound();

return Ok(product);
}

[HttpPost]
public IActionResult Add(Product request)
{
if(request is null)
return BadRequest();

var product = new Product
{
Id = request.Id,
Name = request.Name,
Description = request.Description
};

products.Add(product);
return Ok(product);
}

[HttpPut("{id}")]
public IActionResult Update(int id, Product request)
{
var currentProduct = products.FirstOrDefault(product => product.Id == id);

if (currentProduct is null)
{
return NotFound();
}

currentProduct.Name = request.Name;
currentProduct.Description = request.Description;

return Ok(currentProduct);
}

[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
var product = products.FirstOrDefault(product => product.Id == id);

if (product is null)
return NotFound();

products.Remove(product);
return Ok(product);
}
*/

        public ProductsController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var products = dBContext.Products;
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var product = dBContext.Products.Find(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            dBContext.Products.Add(product); // Add Locally
            dBContext.SaveChanges(); // Add Remotly (inside DB)
            return CreatedAtAction(nameof(Add), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Product product)
        {
            var oldProduct = dBContext.Products.Find(id);

            if (oldProduct == null)
                return NotFound();

            oldProduct.Name = product.Name;
            oldProduct.Description = product.Description;

            dBContext.Products.Update(oldProduct);
            dBContext.SaveChanges();
            return Ok(oldProduct);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = dBContext.Products.Find(id);

            if (product == null)
                return NotFound();

            dBContext.Products.Remove(product);
            dBContext.SaveChanges();
            return Ok();
        }
    }
}
