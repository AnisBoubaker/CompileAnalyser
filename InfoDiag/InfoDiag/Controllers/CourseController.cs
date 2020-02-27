namespace InfoDiag.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("alias")]
        public IActionResult GetCourseIds()
        {
            var result = _courseService.GetCourseIds();

            if (result.Failed)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }
    }
}