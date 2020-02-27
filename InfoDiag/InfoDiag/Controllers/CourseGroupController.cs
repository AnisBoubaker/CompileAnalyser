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
            return Ok(courseGroups.Value);
        }

        public IActionResult Get(string groupId)
        {
            var user = this.UserDto();

            if (user == null)
            {
                return Unauthorized();
            }

            var courseGroup = _courseGroupService.Get(user.Email, groupId);
            return Ok(courseGroup.Value);
        }

        [HttpPost("assign")]
        public IActionResult Assign(AssignCourseGroupDto dto)
        {
            var result = _courseGroupService.Assign(dto.UserIds, dto.CourseGroupId);

            if (result.Failed)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult Create(CreateCourseGroupDto dto)
        {
            var result = _courseGroupService.CreateGroupCourse(dto);

            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Error);
        }

        [HttpGet("{courseGroupId}/users")]
        public IActionResult GetPermitedUsers(string courseGroupId)
        {
            var result = _courseGroupService.GetPermitedUsers(courseGroupId);

            if (result.Success)
            {
                return Ok(result.Value);
            }

            return BadRequest(result.Error);
        }
    }
}