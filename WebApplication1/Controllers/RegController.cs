using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class RegWorksite
    {
        public string company { get; set; }
        public string first { get; set; }
        public string last { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public int locations { get; set; }
        public int employees { get; set; }
        public string code { get; set; }
        public string note { get; set; }
    }


    [Produces("application/json")]
    [Route("api/Reg")]
    public class RegController : Controller
    {

        TestDBContext _context;
        public RegController(TestDBContext context)
        {
            _context = context;
        }

        [Route("~/api/RegCompany")]
        [HttpPost]
        public IActionResult RegCompany([FromForm]RegWorksite obj)
        {
            //db.Add(obj);
            
            return new JsonResult("{\"success\":true, \"company\":\"" + obj.company + "\", \"message\":\"message goes here on error\"}");
        }
    }

}