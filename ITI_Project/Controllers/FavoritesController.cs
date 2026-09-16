using ITI_Project.Data;
using ITI_Project.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    [Authorize(Roles = "Member")]
    public class FavoritesController(AppDbContext context) : Controller
    {
        private async Task<Member?> GetCurrentMemberAsync()
        {
            return await context.Members
                .FirstOrDefaultAsync(m => m.UserName == User.Identity!.Name);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var member = await GetCurrentMemberAsync();
            if (member == null) return RedirectToAction("Index", "Member");

            var favorites = await context.Favorites
                .Include(f => f.Book).ThenInclude(b => b!.Author)
                .Where(f => f.MemberId == member.Id)
                .OrderByDescending(f => f.AddedDate)
                .ToListAsync();

            return View(favorites);
        }

        // Adds the book if it isn't favorited yet, removes it if it already is.
        [HttpPost]
        public async Task<IActionResult> Toggle(int bookId, string? returnUrl)
        {
            var member = await GetCurrentMemberAsync();
            if (member == null) return RedirectToAction("Index", "Member");

            var existing = await context.Favorites
                .FirstOrDefaultAsync(f => f.MemberId == member.Id && f.BookId == bookId);

            if (existing != null)
            {
                context.Favorites.Remove(existing);
            }
            else
            {
                context.Favorites.Add(new Favorite
                {
                    MemberId = member.Id,
                    BookId = bookId,
                    AddedDate = DateTime.Now
                });
            }

            await context.SaveChangesAsync();

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction(nameof(Index));
        }
    }
}
