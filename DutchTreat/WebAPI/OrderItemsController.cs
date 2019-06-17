using System.Collections.Generic;
using DutchTreat.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DutchTreat.Models;
using DutchTreat.Data.Entities;
using AutoMapper;
using System;
using System.Linq;

namespace DutchTreat.WebAPI
{
    [Route("api/orders/{id}/[Controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IDutchRepository _repo;
        public OrderItemsController(IDutchRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderItemDto>> GetAllOrderItems(int id)
        {
            try
            {
                Order order = _repo.GetOrderById(id);
                if (order == null)
                    return NotFound("Order was not found");

                IEnumerable<OrderItem> orderItems = order.Items;

                return Ok(Mapper.Map<IEnumerable<OrderItemDto>>(orderItems));
            }
            catch (Exception ex)
            {
                return BadRequest($"Unable to get order item: {ex.Message}");
            }
            
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<OrderItemDto>> GetOrderItemsById(int orderId, int id)
        {
            try
            {
                Order order = _repo.GetOrderById(orderId);
                if (order == null)
                    return NotFound("Order was not found");

                OrderItem orderItem = order.Items
                                    .Where(o => o.Id == id)
                                    .FirstOrDefault();

                return Ok(Mapper.Map<OrderItemDto>(orderItem));
            }
            catch (Exception ex)
            {
                return BadRequest($"Unable to get order item: {ex.Message}");
            }
            
        }
    }
}