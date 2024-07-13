using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Section1.Core.Entities;
using Section1.Core.IRepositories;
using Section1.Infrastructure.Data;

namespace Section1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IGenericRepository<Category> genericRepository;

        public CategoryController(ApplicationDbContext dbContext, IGenericRepository<Category> genericRepository)
        {
            this.dbContext = dbContext;
            this.genericRepository = genericRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var model = genericRepository.GetAll();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var model = genericRepository.GetById(id);
            return Ok(model);
        }

        [HttpPost]
        public ActionResult Add(Category model)
        {
            genericRepository.Add(model);
            dbContext.SaveChanges();
            return Ok(model);
        }

        [HttpPut]
        public ActionResult Update(Category model)
        {
            genericRepository.Update(model);
            dbContext.SaveChanges();
            return Ok(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            genericRepository.Delete(id);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
