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
        private IErrorCodeService errorCodeService;

        public ErrorCodeController(IErrorCodeService errorCodeService)
        {
            this.errorCodeService = errorCodeService;
        }

        [HttpGet("seed")]
        public IActionResult Seed()
        {
            errorCodeService.SeedErrorCodes();
            return Ok();
        }
    }
}