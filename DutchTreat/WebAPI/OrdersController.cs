using System;
using System.Collections.Generic;
using AutoMapper;
using DutchTreat.Data.Entities;
using DutchTreat.Data.Interfaces;
using DutchTreat.Models;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.WebAPI
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IDutchRepository _repo;
        public OrdersController(IDutchRepository repo)
        {
            _repo = repo;
        }

        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            try
            {
                return Ok(_repo.GetAllOrders());
            }
            catch (Exception ex)
            {
                return BadRequest($"Unabled to get all orders: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            try
            {
                Order order = _repo.GetOrderById(id);
                if (order == null)
                {
                    return NotFound("Order was not found");
                }
                return Ok(order);
            }
            catch (Exception ex)
            {   
                return NotFound(ex);
            }
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody]OrderDto order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.AddEntity(Mapper.Map<Order>(order));
                    if (_repo.SaveAll())
                    {
                        return Created($"/api/orders/{order.Id}", order); 
                    }
                } 
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
            return BadRequest("Failed to save your order");
        }
    }
}