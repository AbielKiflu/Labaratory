using Microsoft.AspNetCore.Mvc; 
using EntityTest.ViewModels.Account;
using DbAcess.Models;
using Microsoft.AspNetCore.Identity;
using DbAcess.DataAcess;

namespace EntityTest.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly MyDataContext _db;

        public AccountController(ILogger<AccountController> logger, MyDataContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {   
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserVM user)
        {

            // hash the password
            var newUser = new User
            {
                Email = user.Email,
                UserName = user.Email.Split("@")[0]
            };

            var hashed = new PasswordHasher<User>().HashPassword(newUser, user.PasswordHash);
            
            newUser.PasswordHash = hashed;

            _db.Add(newUser);
            _db.SaveChanges();

            return View();
        }

 
     





    }
}