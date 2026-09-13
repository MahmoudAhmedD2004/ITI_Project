using ITI_Project.Data;
using ITI_Project.Model;
using ITI_Project.ModelView;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ITI_Project.Controllers
{
    public class MemberController(AppDbContext context) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var member = await context.Members
                .FirstOrDefaultAsync(m => m.UserName == username);
            

            if (member != null && member.PasswordHash == password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, member.UserName),
                    new Claim(ClaimTypes.Role, member.Role.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Book");
                }

            ModelState.AddModelError("", "Invalid username or password");
            return View("Index");
        }
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var member = await context.Members.Where(m=>m.UserName==User.Identity.Name).FirstOrDefaultAsync();

            if (member == null)
                return RedirectToAction("Index");

            return View(member);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Book");
        }

        [HttpPost]
        public async Task<IActionResult> Signup(string username,string email,string phone,string passwod)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            var member = new Member
            {
                UserName = username,
                Email = email,
                PhoneNumber = phone,
                PasswordHash = passwod,
                Role = Role.Member,
                MembershipStartDate = DateTime.Now,
                MembershipExpiryDate = DateTime.Now.AddDays(30)
            };
            await context.Members.AddAsync(member);
            await context.SaveChangesAsync();
            return RedirectToAction("Index","Book");
        }
    }
}
