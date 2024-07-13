using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Section1.Core.Entities;
using Section1.Core.IRepositories;
using Section1.Infrastructure.Data;
using Section1.Infrastructure.Repositories;

namespace Section1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IProductRepository productRepository;

        public ProductController(ApplicationDbContext dbContext, IProductRepository productRepository)
        {
            this.dbContext = dbContext;
            this.productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            // var model = dbContext.Products;
            var model = productRepository.GetAllProducts();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            /*var model = dbContext.Products.Find(id);
            if (model == null)
                return NotFound();*/
            var model = productRepository.GetById(id);
            return Ok(model);
        }

        [HttpPost]
        public ActionResult Add(Product model)
        {
            // dbContext.Products.Add(model);

            productRepository.Add(model);
            dbContext.SaveChanges();
            return Ok(model);
        }

        [HttpPut]
        public ActionResult Update(Product model)
        {
            // dbContext.Products.Update(model);

            productRepository.Update(model);
            dbContext.SaveChanges();
            return Ok(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            // var model = dbContext.Products.Find(id);
            // dbContext.Products.Remove(model);

            productRepository.Delete(id);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
