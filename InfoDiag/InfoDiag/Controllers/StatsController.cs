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
        public IEnumerable<StatDto> Get(int? clientId, string groupId)
        {
            if (groupId != null)
            {
                return _statService.Get(groupId);
            } 
            else if (clientId.HasValue)
            {
                _statService.Get(clientId.Value);
            }

            return BadRequest();
        }
    }
}
