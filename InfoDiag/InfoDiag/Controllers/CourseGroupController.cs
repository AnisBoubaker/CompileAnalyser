using Entity.DTO;
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
        private readonly ICourseGroupService _courseGroupService;
        private readonly IUserService _userService;

        public CourseGroupController(
            ICourseGroupService courseGroupService,
            IUserService userService)
        {
            _courseGroupService = courseGroupService;
            _userService = userService;
        }

        [HttpGet("all")]
        public IActionResult GetAllCourseGroup()
        {
            var courseGroups = _courseGroupService.GetAll();
            return Ok(courseGroups);
        }

        [HttpPost("assign")]
        public IActionResult Assign(AssignCourseGroupDto dto)
        {
            if (_userService.Exists(dto.UserId))
            {
                _courseGroupService.Assign(dto);
                return Ok();
            }

            return BadRequest();
        }
    }
}