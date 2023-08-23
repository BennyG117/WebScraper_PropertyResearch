// User controller
// User models & login models
// User views folder & views
//routes, home, register, logout


using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebScraper_PropertyResearch.Models;
//added:
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;

namespace WebScraper_PropertyResearch.Controllers;

// Double check controllers below:
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    private MyContext db;


    public UserController(ILogger<UserController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }
//UPDATE ALL REDIRECTS and VIEWS WHERE NEEDED*
    // home method  ============================================
    //  using session...

    [HttpGet("")]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32("UUID") != null)
        {
            return RedirectToAction("Index", "SiteCheck");
        }
        return View("Index");
    }

    //  method ============================================
    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }
        // add pw hasher:
        PasswordHasher<User> hashingThePassword = new PasswordHasher<User>();
        newUser.Password = hashingThePassword.HashPassword(newUser, newUser.Password);

        db.Users.Add(newUser);
        db.SaveChanges();
        HttpContext.Session.SetInt32("UUID", newUser.UserId);
        HttpContext.Session.SetString("UserName", newUser.FirstName);


        //UPDATE:
        return RedirectToAction("Index", "SiteCheck");
    }
    //  Login method ================================================
    [HttpPost("/login")]
    public IActionResult Login(LoginUser userSubmission)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }
        //EMAIL CHECK HERE
        User? userInDb = db.Users.FirstOrDefault(e => e.Email == userSubmission.LoginEmail);
        // If no user exists with the provided email        
        if (userInDb == null)
        {
            ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
            return View("Index");
        }
        //PASSWORD CHECK
        PasswordHasher<LoginUser> hashingThePassword = new PasswordHasher<LoginUser>();
        var result = hashingThePassword.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LoginPassword);
        if (result == 0)
        {
            ModelState.AddModelError("LoginPassword", "Invalid Password/Email");
            return View("Index");
        }

        //Handle success
        HttpContext.Session.SetInt32("UUID", userInDb.UserId);
        HttpContext.Session.SetString("UserName", userInDb.FirstName);
        
        //UPDATE:
        return RedirectToAction("Index", "SiteCheck");
    }


    // Logout Method ================================================
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }







    // Privacy Method ================================================



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
