using AngularCourse.Models;
using AngularCourse.UnitOfWork;
using AngularCourse.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AngularCourse.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Supplier")]
    [EnableCors("CorsPolitic")]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Supplier.GetById(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody]Supplier supplier)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_unitOfWork.Supplier.Insert(supplier));
        }

        [HttpPut]
        public IActionResult Put([FromBody]Supplier supplier)
        {
            if (ModelState.IsValid && _unitOfWork.Supplier.Update(supplier))
            {
                return Ok(new { Mesagge = "The supplier is updated." });
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Supplier supplier)
        {
            if (supplier.Id > 0)
            {
                return Ok(_unitOfWork.Supplier.Delete(supplier));
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("GetPaginatedSupplier")]
        public IActionResult GetPaginatedSupplier([FromBody]GetPaginatedSupplier request)
        {
            return Ok(_unitOfWork.Supplier.SupplierPagedList(request.Page, request.Rows, request.SearchTerm));
        }
    }
}