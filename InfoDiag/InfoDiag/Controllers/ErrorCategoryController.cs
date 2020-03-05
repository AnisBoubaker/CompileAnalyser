using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace InfoDiag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorCategoryController : ControllerBase
    {
        private readonly IErrorCategoryService _errorCategoryService;

        public ErrorCategoryController(IErrorCategoryService errorCategoryService)
        {
            _errorCategoryService = errorCategoryService;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _errorCategoryService.GetAll();

            return Ok(result.Value);
        }

        [HttpPost("assign")]
        public IActionResult Assign(int categoryId, string[] errorCodeIds)
        {
            var result = _errorCategoryService.Assign(categoryId, errorCodeIds);

            if (result.Failed)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("Unassign")]
        public IActionResult Unassign(string[] errorCodeIds)
        {
            var result = _errorCategoryService.Unassign(errorCodeIds);

            if (result.Failed)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            var result = _errorCategoryService.Add(name);

            if (result.Failed)
            {
                return BadRequest();
            }

            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _errorCategoryService.Delete(id);

            if (result.Failed)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}