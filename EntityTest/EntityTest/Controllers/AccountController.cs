using DbAcess.DataAcess;
using EntityTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using EntityTest.ViewModels.Account;

namespace EntityTest.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;

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
            Console.WriteLine(user.Email);
            return View();
        }

 
     





    }
}