using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.DTO;
using InfoDiag.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
        public IActionResult Assign(AssignCategoryDto dto)
        {
            var result = _errorCategoryService.Assign(dto.CategoryId, dto.ErrorCodeIds);

            if (result.Failed)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("Unassign")]
        public IActionResult Unassign(SimpleBody<string[]> errorCodeIds)
        {
            var result = _errorCategoryService.Unassign(errorCodeIds.Value);

            if (result.Failed)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult Add(SimpleBody<string> name)
        {
            var result = _errorCategoryService.Add(name.Value);

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