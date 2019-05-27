namespace InfoDiag.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;

    /// <summary>
    /// Get and post compilations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompilationController : ControllerBase
    {
        private readonly ICompilationService compilationService;

        public CompilationController(ICompilationService compilationService)
        {
            this.compilationService = compilationService;
        }

        /// <summary>
        /// Api that is contacted by the template
        /// </summary>
        /// <param name="file">zip containing the template</param>
        /// <returns>Message</returns>
        [HttpPost]
        public IActionResult SubmitCompilation(IFormFile file)
        {
            var returnMessage = compilationService.AddCompilation(file);
            return Ok(returnMessage);
        }
    }
}