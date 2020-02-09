namespace InfoDiag.Controllers
{
    using System.Collections.Generic;
    using Entity.DTO;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IStatService _statService;

        public StatsController(IStatService statService)
        {
            _statService = statService;
        }

        // GET: api/Stats
        [HttpGet]
        public IActionResult Get(int? clientId, string groupId)
        {
            if (groupId != null)
            {
                return Ok(_statService.Get(groupId).Value);
            }
            else if (clientId.HasValue)
            {
                return Ok(_statService.Get(clientId.Value).Value);
            }

            return BadRequest();
        }
    }
}
