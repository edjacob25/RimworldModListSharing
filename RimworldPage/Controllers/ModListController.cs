using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
    public class ModListController : Controller
    {
        private readonly ILogger<ModListController> _logger;

        public ModListController(ILogger<ModListController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/ModList/{id}")]
        public IActionResult ShowList([FromRoute] string id)
        {
            _logger.LogDebug($"The id is {id}");
            ViewBag.id = id;
            return View();
        }
    }
}