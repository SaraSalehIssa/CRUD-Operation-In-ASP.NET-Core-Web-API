using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Section1.API.mapping_profiles;
using Section1.Core.Entities;
using Section1.Core.Entities.DTO;
using Section1.Core.IRepositories;
using Section1.Infrastructure.Data;
using Section1.Infrastructure.Repositories;
using System.Collections;
using System.Collections.Generic;

namespace Section1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork<Product> unitOfWork;
        private readonly IMapper mapper;
        public ApiResponse response;

        public ProductController(IUnitOfWork<Product> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            response = new ApiResponse();
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllProducts(int pageSize = 2, int pageNumber = 1)
        {
            var model = await unitOfWork.productRepository.GetAll(page_size : pageSize, page_number : pageNumber);
            var check = model.Any();
            if (check)
            {
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.IsSuccess = check;
                var mappedProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(model);
                response.Result = mappedProducts;
            }
            else
            {
                response.ErrorMessages = "Products not found!";
                response.StatusCode = System.Net.HttpStatusCode.OK;
                response.IsSuccess = check;
            }
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await unitOfWork.productRepository.GetById(id);
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Product model)
        {
            await unitOfWork.productRepository.Add(model);
            await unitOfWork.Save();
            return Ok(model);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Product model)
        {
            unitOfWork.productRepository.Update(model);
            await unitOfWork.Save();
            return Ok(model);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            unitOfWork.productRepository.Delete(id);
            await unitOfWork.Save();
            return Ok();
        }

        [HttpGet("Product/{CategoryId}")]
        public async Task<ActionResult<ApiResponse>> GetProductByCategoryId(int CategoryId)
        {
            var products = await unitOfWork.productRepository.GetAllProductsByCategoryId(CategoryId);
            var mappedProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return Ok(mappedProducts);
        }
    }
}
