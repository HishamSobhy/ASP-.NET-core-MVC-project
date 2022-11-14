using lec5.Data;
using lec5.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace lec5.Controllers
{
    public class accountController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        DataBase db;

        public accountController(DataBase _db)
        {
            db = _db;
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            
            var usr = db.Users.Include(a=>a.roles).FirstOrDefault(a => a.username == model.username);
                if (usr!=null)
                {
                List<string> roles = new List<string>();
                Claim c1 = new Claim(ClaimTypes.Name, usr.Name);
                //Claim c2 = new Claim(ClaimTypes.Role, "Admin");
                //Claim c3 = new Claim(ClaimTypes.Role, "Student");
                ClaimsIdentity ci = new ClaimsIdentity("cookie");

                ci.AddClaim(c1);

            
                foreach (var item in usr.roles)
                {
                    ci.AddClaim(new Claim(ClaimTypes.Role, item.RoleName));
                }

                //ci.AddClaim(c2);
                //ci.AddClaim(c3);

                ClaimsPrincipal cp = new ClaimsPrincipal(ci);


                await HttpContext.SignInAsync(cp);
                return RedirectToAction("index", "student");
                }
            else
            {
                ModelState.AddModelError("","Username or passwowrd not exist");
                return View(model);
            }
         
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
