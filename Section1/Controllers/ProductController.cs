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
        private readonly IUnitOfWork<Product> unitOfWork;

        public ProductController(IUnitOfWork<Product> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var model = unitOfWork.productRepository.GetAll();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var model = unitOfWork.productRepository.GetById(id);
            return Ok(model);
        }

        [HttpPost]
        public ActionResult Add(Product model)
        {
            unitOfWork.productRepository.Add(model);
            unitOfWork.Save();
            return Ok(model);
        }

        [HttpPut]
        public ActionResult Update(Product model)
        {
            unitOfWork.productRepository.Update(model);
            unitOfWork.Save();
            return Ok(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            unitOfWork.productRepository.Delete(id);
            unitOfWork.Save();
            return Ok();
        }
    }
}
