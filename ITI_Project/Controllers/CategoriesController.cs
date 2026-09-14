using Microsoft.AspNetCore.Mvc;
using ITI_Project.Data;
using ITI_Project.Model;
using Microsoft.EntityFrameworkCore;


namespace ITI_Project.Controllers
{
    public class CategoriesController (AppDbContext context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await context.Categories
                .Include(c => c.Books)
                .ToListAsync();

            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                await context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit (Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Update(category);
                await context.SaveChangesAsync();
            }
            return RedirectToAction (nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category != null)
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
