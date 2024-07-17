﻿using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ApiResponse response;

        public ProductController(IUnitOfWork<Product> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            response = new ApiResponse();
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            var model = await unitOfWork.productRepository.GetAll();
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

        [HttpGet("Products/{CategoryId}")]
        public async Task<ActionResult<ApiResponse>> GetProductByCategoryId(int CategoryId)
        {
            var products = unitOfWork.productRepository.GetAllProductsByCategoryId(CategoryId);
            var mappedProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return Ok(mappedProducts);
        }
    }
}
