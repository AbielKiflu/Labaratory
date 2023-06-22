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

        [HttpPost]
        public IActionResult Index(UserVM user)
        {
            var pwd = _db.Users.Find(9)?.PasswordHash;
          
            var test = new PasswordHasher<User>().VerifyHashedPassword(null,pwd, user.Password);
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

            var hashed = new PasswordHasher<User>().HashPassword(null, user.Password);
            
            newUser.PasswordHash = hashed;

            _db.Add(newUser);
            _db.SaveChanges();

            return View();
        }

 
     





    }
}