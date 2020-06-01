using AngularCourse.Models;
using AngularCourse.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AngularCourse.WebAPI.Controllers
{
    [Route("api/Customer")]
    [EnableCors("CorsPolitic")]
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Customer.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_unitOfWork.Customer.Insert(customer));
        }

        [HttpPut]
        public IActionResult Put([FromBody]Customer customer)
        {
            if (ModelState.IsValid && _unitOfWork.Customer.Update(customer))
            {
                return Ok(new { Mesagge = "The customer is updated." });
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Customer customer)
        {
            if (customer.Id > 0)
            {
                return Ok(_unitOfWork.Customer.Delete(customer));
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetPaginatedCustomer/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedCustomer(int page,int rows)
        {
            return Ok(_unitOfWork.Customer.CustomerPagedList(page, rows));
        }
    }
}
