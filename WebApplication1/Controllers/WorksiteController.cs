using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Models;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    public class Worksite
    {        
        public string background { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string logo { get; set; }
        public int wkid { get; set; }
    }

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class WorksiteController : Controller
    {

        TestDBContext _context;
        public WorksiteController(TestDBContext context)
        {
            _context = context;
        }

        //[Authorize]
        // GET api/worksite/id
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            //ILoggerFactory loggerFactory = new LoggerFactory().AddConsole();
            //loggerFactory.MinimumLevel = LogLevel.Debug;
            //loggerFactory.AddDebug(LogLevel.Debug);
            //var logger = loggerFactory.CreateLogger("Startup");
            //logger.LogWarning("Logger configured!");
            //var worksite = _context.Worksite.Join(_context.Wkprofile, u => u.WorksiteId, uir => uir.WorksiteId, (u, uir) => new { u, uir }).Where(m => m.r.u.URL == id).Select(mbox => new AddWorksiteToRole { pic = mbox.r.u.background_pic });
            //logger.LogWarning(id);
            //var query = _context.Worksite.Join(_context.Wkprofile, worksite => worksite.WorksiteId, wkprofile => wkprofile.WorksiteId, (worksite, wkprofile) => new { Worksite = worksite, Wkprofile = wkprofile }).Where(worksiteAndwkprofile => worksiteAndwkprofile.Worksite.Url == id); 
            var row = _context.Worksite.SingleOrDefault(r => r.Url == id);
            if (row != null)
            {                                
                var wkprofile = _context.Wkprofile.SingleOrDefault(r => r.WorksiteId == row.WorksiteId);                
                return Json(new Worksite { wkid = row.WorksiteId, name = row.Name, background = wkprofile.BackgroundPic, url = row.Url, logo = row.Logo });                
            }
            else
            {
                return Json(new Worksite { wkid = 0, name = "", background = "", url = "", logo = "" });
            }
            
        }

    }
}