using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.Models;
using RestaurantOrder.services;

namespace RestaurantOrder.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersConstroller : ControllerBase
    {
        private readonly IDishServices _repository;

        public OrdersConstroller(IDishServices repository)
        {
            _repository = repository;
        }
      
        [HttpPost]
        public ActionResult AddOrder(string inputOrder)
        {
            try
            {
                var order = _repository.AddOrder(inputOrder);

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
