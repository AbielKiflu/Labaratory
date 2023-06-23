using Microsoft.AspNetCore.Mvc; 
using EntityTest.ViewModels.Account;
using DbAcess.Models;
using Microsoft.AspNetCore.Identity;
using DbAcess.DataAcess;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace EntityTest.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyDataContext _db;
        private readonly IPasswordHasher<User> _hasher;
        private readonly ILogger<AccountController> _logger;



        public AccountController(ILogger<AccountController> logger, MyDataContext db, IPasswordHasher<User> hasher)
        {
            _db = db;
            _logger = logger;
            _hasher = hasher;
        
        }


        // an action that calls the login view
        [HttpGet]
        public IActionResult Index()
        {   
            return View();
        }


        // an action that processes the login credential ...
        [HttpPost]
        public async Task<IActionResult> Index(UserVM user)
        {
            var newUser = _db.Users.Find(15);
            if (newUser != null)
            {
               
                var result= _hasher.VerifyHashedPassword(null, newUser.PasswordHash, user.Password).ToString();
                if(result== "Success")
                {
                    // let the user login
                    var claims = new List<Claim>();
                    claims.Add(new Claim("email", newUser.Email)); 
                    var identity = new ClaimsIdentity(claims);
                   
                    HttpContext.User = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, HttpContext.User);
                      
                }
                else
                {
                    // do not let the user login
                }

            }
            
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