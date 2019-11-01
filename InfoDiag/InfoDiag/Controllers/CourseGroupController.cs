using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace InfoDiag.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseGroupController : ControllerBase
    {
        public CourseGroupController(ICourseGroupService courseGroupService)
        {

        }

        [HttpGet("all")]
        public IActionResult GetAllCourseGroup()
        {
            return Ok();
        }
    }
}