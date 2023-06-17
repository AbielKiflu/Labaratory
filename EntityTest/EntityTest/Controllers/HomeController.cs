using DbAcess.DataAcess;
using EntityTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using EntityTest.Helper;
using EntityTest.Helper;
using DbAcess.Models;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace EntityTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDataContext _db;

        public HomeController(ILogger<HomeController> logger, MyDataContext db)
        {
            _logger = logger;
            Auth auth = new Auth();
            _db = db;
        }

        public IActionResult Index()
        {
            HttpContext.Response.Headers["set-cookie"] = "auth=Abule;SameSite=None;secure";
            _logger.LogInformation("Abiel "  );
            ViewData["Test"] = HttpContext.Response.Headers["set-cookie"];
     
            var model = _db.Users.Include(a=>a.Addresses).ToList();
            string salt = new Auth().salt;
            
            return View(model);
        }


 

  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}