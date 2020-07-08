using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication.Models.Database;

namespace WebApplication.Controllers
{
    public class ModListController : Controller
    {
        private readonly ILogger<ModListController> _logger;
        private readonly MyContext _context;

        public ModListController(ILogger<ModListController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("/ModList/{id}")]
        public async Task<IActionResult> ShowList([FromRoute] string id)
        {
            _logger.LogDebug($"The id is {id}");
            var modList = await _context.ModLists
                .Include(m => m.Mods)
                .ThenInclude(m => m.Mod)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modList == null) return NotFound();

            return View(modList);
        }
    }
}