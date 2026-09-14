using System.Linq.Expressions;
using System.Threading.Tasks;
using ITI_Project.Data;
using ITI_Project.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITI_Project.Model;

namespace ITI_Project.Controllers
{
    public class AuthorsController(AppDbContext context) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var authors = await context.Authors
                .Include(a => a.Books)
                .ToListAsync();
            return View(authors);
        }


        [HttpGet]
        public async Task<IActionResult> Create() => View(new AuthorViewModel());


        [HttpPost]
        public async Task<IActionResult> Create(AuthorViewModel model, [FromServices] IWebHostEnvironment webHost)
        {
            if (!ModelState.IsValid) return View(model);

            string? photoPath = null;

            if (model.Photo != null && model.Photo.Length > 0)
            {
                {
                    // 1. تحديد فولدر الحفظ داخل wwwroot
                    string uploadsFolder = Path.Combine(webHost.WebRootPath, "upload", "authors");
                    if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                    // 2. انشاء اسم فريد للملف
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // 3. حفظ الملف علي السيرفر 
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Photo.CopyToAsync(fileStream);
                    }
                    photoPath = "/uploads/authors" + uniqueFileName;
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
        public async Task<IActionResult> Edit (int id)
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
        

        [HttpPost]
        public async Task<IActionResult> Delete (int id)
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
