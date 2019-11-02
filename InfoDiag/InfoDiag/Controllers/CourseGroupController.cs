namespace InfoDiag.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseGroupController : ControllerBase
    {
        private readonly ICourseGroupService _courseGroupService;

        public CourseGroupController(ICourseGroupService courseGroupService)
        {
            _courseGroupService = courseGroupService;
        }

        [HttpGet("all")]
        public IActionResult GetAllCourseGroup()
        {
            var courseGroups = _courseGroupService.GetAll();
            return Ok(courseGroups);
        }
    }
}