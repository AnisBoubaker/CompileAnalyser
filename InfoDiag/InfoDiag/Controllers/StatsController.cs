using System.Collections.Generic;
using Entity.DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace InfoDiag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IStatService _statService;

        public StatsController(IStatService statService)
        {
            _statService = statService;
        }

        // GET: api/StatsIStatService
        [HttpGet]
        public IEnumerable<StatDto> Get()
        {
            return _statService.Get();
        }
    }
}
