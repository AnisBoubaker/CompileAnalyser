using InfoDiag.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace InfoDiag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("all")]
        public IActionResult GetAllClients()
        {
            var user = this.UserDto();

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(_clientService.GetAllClients(user.Email));
        }
    }
}