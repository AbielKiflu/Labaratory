using DbAcess.DataAcess;
using EntityTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace EntityTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDataContext _db;

        public HomeController(ILogger<HomeController> logger, MyDataContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var model = _db.Users.Include(a=>a.Addresses).ToList();

            return View(model);
        }


  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}