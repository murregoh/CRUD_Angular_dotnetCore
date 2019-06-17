using System;
using System.Collections.Generic;
using DutchTreat.Data.Entities;
using DutchTreat.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.WebAPI 
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDutchRepository _repository;

        public ProductsController(IDutchRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                return BadRequest($"Unable to get products: {ex.Message}");
            }
            
        }
    }
}