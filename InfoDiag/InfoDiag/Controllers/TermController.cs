namespace InfoDiag.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class TermController : ControllerBase
    {
        private readonly ITermService termService;

        public TermController(ITermService termService)
        {
            this.termService = termService;
        }

        [HttpPost("create")]
        public IActionResult Create(string alias)
        {
            var result = termService.Create(alias);

            if (result.Failed)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPost("createMultiple")]
        public IActionResult CreateMultiple(string alias, int number)
        {
            var result = termService.CreateMultiple(alias, number);

            if (result.Failed)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}