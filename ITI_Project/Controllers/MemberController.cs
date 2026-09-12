using ITI_Project.Data;
using ITI_Project.Model;
using ITI_Project.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var members = await context.Members.ToListAsync();
            if (members.Any(m => m.UserName == username))
            {
                if (members.FirstOrDefault(m => m.UserName == username)?.PasswordHash == password)
                {
                    return RedirectToAction("Index", "Book");
                }
               

            }
            return Redirect("Index");
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
