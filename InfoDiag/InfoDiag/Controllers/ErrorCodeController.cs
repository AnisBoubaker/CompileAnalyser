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
    public class ErrorCodeController : ControllerBase
    {
        private readonly IErrorCodeService _errorCodeService;

        public ErrorCodeController(IErrorCodeService errorCodeService)
        {
            _errorCodeService = errorCodeService;
        }

        [HttpPost("seed")]
        public IActionResult Seed()
        {
            _errorCodeService.SeedErrorCodes();
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var errorCodes = _errorCodeService.All();

            return Ok(errorCodes);
        }
    }
}