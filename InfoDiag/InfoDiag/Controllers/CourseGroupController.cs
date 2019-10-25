using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfoDiag.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseGroupController : ControllerBase
    {
    }
}