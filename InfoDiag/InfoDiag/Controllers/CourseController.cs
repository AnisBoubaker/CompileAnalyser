namespace InfoDiag.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("hello")]
        public IActionResult Hello()
        {
            return Ok("hello");
        }
    }
}