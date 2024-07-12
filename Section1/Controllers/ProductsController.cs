using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Section1.Models;

namespace Section1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
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
    }
}
