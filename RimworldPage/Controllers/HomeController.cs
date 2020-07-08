using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using WebApplication.Models.Database;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext ctx)
        {
            _logger = logger;
            _context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(FileUpload data)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("File", "The file could not be processed.");
                return View();
            }

            await using (var memoryStream = new MemoryStream())
            {
                await data.FormFile.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    _logger.LogDebug(data.FormFile.FileName);
                    var xml = new XmlDocument();
                    var text = Encoding.UTF8.GetString(memoryStream.ToArray());
                    try
                    {
                        xml.LoadXml(text.Trim('\uFEFF', '\u200B'));
                        var mods = new List<Mod>();
                        var ids = xml.SelectNodes("/ModList/modIds/li").Cast<XmlNode>()
                            .Select(x => x.InnerText);
                        var names = xml.SelectNodes("/ModList/modNames/li").Cast<XmlNode>()
                            .Select(x => x.InnerText);

                        foreach (var (id, name) in ids.Zip(names))
                        {
                            mods.Add(new Mod { Id = id, Name = name });
                        }

                        var modList = new ModList()
                        {
                            Id = Guid.NewGuid().ToString(),
                            CreationDate = DateTime.Now,
                            Name = data.Name
                        };
                        await _context.ModLists.AddAsync(modList);
                        await _context.SaveChangesAsync();
                        return Redirect($"/ModList/{modList.Id}");
                    }
                    catch (Exception e)
                    {
                        _logger.LogError("File is not an xml");
                        _logger.LogDebug(e.ToString());
                        ModelState.AddModelError("File", "The file is not an xml file");
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}