using ITI_Project.Data;
using ITI_Project.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize(Roles = "Librarian")]
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
        [Authorize(Roles = "Librarian")]
        [HttpGet]
        [Authorize(Roles = "Librarian")]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        [Authorize(Roles = "Librarian")]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            var existingCategory = await context.Categories.FindAsync(id);
            if (existingCategory == null) return NotFound();

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Librarian")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await context.Categories
                .Include(c => c.Books)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return RedirectToAction(nameof(Index));
            return View(category);
        }

        [HttpPost]
        [Authorize(Roles = "Librarian")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
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
