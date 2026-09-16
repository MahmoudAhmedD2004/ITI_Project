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
            var member = await context.Members.Where(m => m.UserName == User.Identity.Name).FirstOrDefaultAsync();

            if (member == null)
                return RedirectToAction("Index");

            return View(member);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var member = await context.Members
                .FirstOrDefaultAsync(m => m.UserName == User.Identity!.Name);

            if (member == null) return RedirectToAction("Index");

            var model = new EditProfileViewModel
            {
                Email = member.Email,
                PhoneNumber = member.PhoneNumber
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            var member = await context.Members
                .FirstOrDefaultAsync(m => m.UserName == User.Identity!.Name);

            if (member == null) return RedirectToAction("Index");

            if (!ModelState.IsValid)
                return View(model);

            var emailTaken = await context.Members
                .AnyAsync(m => m.Email == model.Email && m.Id != member.Id);

            if (emailTaken)
            {
                ModelState.AddModelError(nameof(model.Email), "This email is already registered to another account.");
                return View(model);
            }

            member.Email = model.Email;
            member.PhoneNumber = model.PhoneNumber;
            await context.SaveChangesAsync();

            TempData["Success"] = "Your profile has been updated.";
            return RedirectToAction("Profile");
        }

        [Authorize]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View(new ChangePasswordViewModel());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var member = await context.Members
                .FirstOrDefaultAsync(m => m.UserName == User.Identity!.Name);

            if (member == null) return RedirectToAction("Index");

            if (!ModelState.IsValid)
                return View(model);

            if (member.PasswordHash != model.CurrentPassword)
            {
                TempData["Error"] = "Your current password is incorrect.";
                return View(model);
            }

            member.PasswordHash = model.NewPassword;
            await context.SaveChangesAsync();

            TempData["Success"] = "Your password has been changed.";
            return RedirectToAction("Profile");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Book");
        }

        [HttpPost]
        public async Task<IActionResult> Signup(string username, string email, string phone, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
                ModelState.AddModelError("", "Username must be at least 3 characters.");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
                ModelState.AddModelError("", "Please enter a valid email.");

            if (string.IsNullOrWhiteSpace(phone))
                ModelState.AddModelError("", "Phone number is required.");

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                ModelState.AddModelError("", "Password must be at least 6 characters.");

            if (await context.Members.AnyAsync(m => m.UserName == username))
                ModelState.AddModelError("", "This username is already taken.");

            if (await context.Members.AnyAsync(m => m.Email == email))
                ModelState.AddModelError("", "This email is already registered.");

            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var member = new Member
            {
                UserName = username,
                Email = email,
                PhoneNumber = phone,
                PasswordHash = password,
                Role = Role.Member,
                MembershipStartDate = DateTime.Now,
                MembershipExpiryDate = DateTime.Now.AddDays(30)
            };
            await context.Members.AddAsync(member);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Book");
        }
    }
}