using AngularCourse.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCourse.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    [EnableCors("CorsPolitic")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetPaginatedOrders/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedOrders(int page, int rows)
        {
            return Ok(_unitOfWork.Order.getPaginatedOrderList(page, rows));
        }
        [HttpGet]
        [Route("GetOrderById/{orderId:int}")]
        public IActionResult GetOrderById(int orderId)
        {
            return Ok(_unitOfWork.Order.GetOrderById(orderId));
        }
    }
}
