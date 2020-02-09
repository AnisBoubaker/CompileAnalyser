namespace InfoDiag.Controllers
{
    using Entity.DTO;
    using InfoDiag.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

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
            var user = this.UserDto();

            if (user == null)
            {
                return Unauthorized();
            }

            var courseGroups = _courseGroupService.GetAll(user.Email);
            return Ok(courseGroups);
        }

        [HttpPost("assign")]
        public IActionResult Assign(AssignCourseGroupDto dto)
        {
            if (_userService.Exists(dto.UserId))
            {
                _courseGroupService.Assign(dto.UserId, dto.CourseGroupId);
                return Ok();
            }

            return BadRequest();
        }
    }
}