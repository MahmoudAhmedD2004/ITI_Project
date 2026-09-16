using ITI_Project.Data;
using ITI_Project.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ITI_Project.Controllers
{
    public class CategoriesController(AppDbContext context) : Controller
    {
        public async Task<IActionResult> Index(string? q, string sortBy = "name_asc", int page = 1)
        {
            const int pageSize = 10;
            if (page < 1) page = 1;

            var query = context.Categories.Include(c => c.Books).AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(c =>
                    c.Name.Contains(q) ||
                    (c.Description != null && c.Description.Contains(q)));
            }

            query = sortBy switch
            {
                "name_desc" => query.OrderByDescending(c => c.Name),
                "books_desc" => query.OrderByDescending(c => c.Books.Count),
                "books_asc" => query.OrderBy(c => c.Books.Count),
                _ => query.OrderBy(c => c.Name),
            };

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            if (totalPages > 0 && page > totalPages) page = totalPages;

            var categories = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.Search = q;
            ViewBag.SortBy = sortBy;

            return View(categories);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                await context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Librarian")]
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
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await context.Categories
                .Include(c => c.Books)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return RedirectToAction(nameof(Index));
            return View(category);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Librarian")]
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