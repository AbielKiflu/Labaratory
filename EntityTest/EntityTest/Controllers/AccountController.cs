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
        private readonly IPasswordHasher<User> _hasher;

        public AccountController(ILogger<AccountController> logger, MyDataContext db, IPasswordHasher<User> hasher)
        {
            _logger = logger;
            _db = db;
            _hasher = hasher;
        }

        [HttpGet]
        public IActionResult Index()
        {   
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserVM user)
        {
            var newUser = _db.Users.Find(14);
             
            var test = _hasher.VerifyHashedPassword(null, newUser.PasswordHash, user.Password);
             
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

            newUser.PasswordHash = _hasher.HashPassword(null, user.Password);
             
            _db.Add(newUser);
            _db.SaveChanges();

            return View();
        }

 
     





    }
}