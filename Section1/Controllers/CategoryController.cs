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
        private readonly IUnitOfWork<Category> unitOfWork;

        public CategoryController(ApplicationDbContext dbContext, IUnitOfWork<Category> unitOfWork)
        {
            this.dbContext = dbContext;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var model = unitOfWork.categoryRepository.GetAll();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var model = unitOfWork.categoryRepository.GetById(id);
            return Ok(model);
        }

        [HttpPost]
        public ActionResult Add(Category model)
        {
            unitOfWork.categoryRepository.Add(model);
            dbContext.SaveChanges();
            return Ok(model);
        }

        [HttpPut]
        public ActionResult Update(Category model)
        {
            unitOfWork.categoryRepository.Update(model);
            dbContext.SaveChanges();
            return Ok(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            unitOfWork.categoryRepository.Delete(id);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
