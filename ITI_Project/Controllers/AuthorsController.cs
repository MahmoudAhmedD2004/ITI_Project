using ITI_Project.Data;
using ITI_Project.Model;
using ITI_Project.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ITI_Project.Controllers
{
    public class AuthorsController(AppDbContext context) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string? q, string sortBy = "name_asc", int page = 1)
        {
            const int pageSize = 10;
            if (page < 1) page = 1;

            var query = context.Authors.Include(a => a.Books).AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(a =>
                    a.Name.Contains(q) ||
                    (a.Bio != null && a.Bio.Contains(q)));
            }

            query = sortBy switch
            {
                "name_desc" => query.OrderByDescending(a => a.Name),
                "books_desc" => query.OrderByDescending(a => a.Books.Count),
                "books_asc" => query.OrderBy(a => a.Books.Count),
                _ => query.OrderBy(a => a.Name),
            };

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            if (totalPages > 0 && page > totalPages) page = totalPages;

            var authors = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.Search = q;
            ViewBag.SortBy = sortBy;

            return View(authors);
        }


        [HttpGet]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> Create() => View(new AuthorViewModel());


        [HttpPost]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> Create(AuthorViewModel model, [FromServices] IWebHostEnvironment webHost)
        {
            if (!ModelState.IsValid) return View(model);

            string? photoPath = null;

            if (model.Photo != null && model.Photo.Length > 0)
            {
                {
                    // 1. تحديد فولدر الحفظ داخل wwwroot
                    string uploadsFolder = Path.Combine(webHost.WebRootPath, "uploads", "authors");
                    if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                    // 2. انشاء اسم فريد للملف
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // 3. حفظ الملف علي السيرفر 
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Photo.CopyToAsync(fileStream);
                    }
                    photoPath = "/uploads/authors/" + uniqueFileName;
                }
            }

            var author = new Author
            {
                Name = model.Name,
                Bio = model.Bio,
                Photo = photoPath
            };

            context.Authors.Add(author);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var author = await context.Authors
                .FirstOrDefaultAsync(a => a.Id == id);

            if (author == null) return NotFound();

            var Books = await context.Books
                .Include(b => b.Category)
                .Include(b => b.BookCopies)
                .Where(b => b.AuthorId == id)
                .ToListAsync();

            var model = new AuthorDetailsViewModel
            {
                Author = author,
                Books = Books
            };
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> Edit(int id)
        {
            var author = await context.Authors.FindAsync(id);

            if (author == null) return NotFound();

            var model = new AuthorViewModel
            {
                Id = author.Id,
                Name = author.Name,
                Bio = author.Bio,
                ExistingPhoto = author.Photo
            };
            return View(model);
        }


        [HttpPost]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> Edit(int id, AuthorViewModel model, [FromServices] IWebHostEnvironment webHost)
        {
            if (id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);

            var author = await context.Authors.FindAsync(id);
            if (author == null) return NotFound();

            author.Name = model.Name;
            author.Bio = model.Bio;


            if (model.Photo != null && model.Photo.Length > 0)
            {
                string uploadsFolder = Path.Combine(webHost.WebRootPath, "uploads", "authors");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Photo.CopyToAsync(fileStream);
                }
                author.Photo = "/uploads/authors/" + uniqueFileName;
            }

            context.Update(author);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await context.Authors.FindAsync(id);
            if (author == null) return RedirectToAction(nameof(Index));
            return View(author);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Librarian")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await context.Authors.FindAsync(id);
            if (author != null)
            {
                context.Authors.Remove(author);
                await context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}