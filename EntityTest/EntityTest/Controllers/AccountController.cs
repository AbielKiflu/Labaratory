using Microsoft.AspNetCore.Mvc; 
using EntityTest.ViewModels.Account;
using DbAcess.Models;
using Microsoft.AspNetCore.Identity;
using DbAcess.DataAcess;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UserVM user)
        {
            var newUser = _db.Users.Find(16);
            if (newUser != null)
            {
               
                var result= _hasher.VerifyHashedPassword(null, newUser.PasswordHash, user.Password).ToString();
                if(result== "Success")
                {
                    // let the user login
                    var claims = new List<Claim>();
                    claims.Add(new Claim("email", newUser.Email)); 
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(new ClaimsPrincipal(identity));
                }
                else
                {
                    // do not let the user login
                }

            }
 


            return View();
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserVM user)
        {

            if (ModelState.IsValid)
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
            else
            {
                return NotFound();
            }

        }

  


    }
}