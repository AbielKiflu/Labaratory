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
            logger.LogInformation("Abiel");
            logger.LogInformation(Auth.HashPassword("Abule", auth.salt).Length.ToString());
            _db = db;
        }

        public IActionResult Index()
        {
            var model = _db.Users.Include(a=>a.Addresses).ToList();
            string salt = new Auth().salt;
            _db.Users.Add(new User
            {
                UserName = "Estifanos",
                Email ="Estif@gmail.com",
                PasswordHash = Auth.HashPassword("123", salt),
                Salt = salt,
            });
            _logger.LogInformation("Test Abi");
            _db.SaveChanges();
            return View(model);
        }


 

  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}