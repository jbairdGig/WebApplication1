using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Item
    {
        public bool result { get; set; }
        public string message { get; set; }
    }

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        TestDBContext _context;
        public AuthController(TestDBContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET api/auth
        [HttpGet]
        public IActionResult Get()
        {
            var userid = "";
            var name = "";
            var email = "";
            bool check = false;
            var message = "";

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                //IEnumerable<Claim> claims = identity.Claims;
                // or
                userid = identity.FindFirst("user_id").Value;
                //name = identity.FindFirst("name").Value;
                //email = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            }

            //look for match in SQL Server, if no match or not activated then false, if match and activated then true           
            var user = _context.Users.Find(userid);

            if(user != null && user.Active == "Y")
            {
                check = true;
                message = "You have an active account, welcome!";
            }
            else if(user != null && user.Active == "N")
            {
                check = false;
                message = "Your account is not activated yet";
            }
            else if (user == null)
            {
                check = false;
                message = "You need to register first";
            }
            

            //return new string[] { "value1", "value2" };
            return Json(new Item { result = check, message = message });
        }

    }
}