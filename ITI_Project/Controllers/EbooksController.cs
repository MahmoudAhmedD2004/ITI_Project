using ITI_Project.Data;
using ITI_Project.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    public class EbooksController(IWebHostEnvironment ev, AppDbContext context) : Controller
    {
        // Admin/Librarian: list every book with its ebook status, upload/replace/remove from here.
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> Index()
        {
            var books = await context.Books
                .Include(b => b.Author)
                .OrderBy(b => b.Title)
                .ToListAsync();

            var ebooks = await context.Ebooks.ToDictionaryAsync(e => e.BookId);
            ViewBag.Ebooks = ebooks;

            return View(books);
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPost]
        public async Task<IActionResult> Upload(int bookId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["EbookError"] = "Please choose a PDF file.";
                return RedirectToAction(nameof(Index));
            }

            if (!string.Equals(Path.GetExtension(file.FileName), ".pdf", StringComparison.OrdinalIgnoreCase))
            {
                TempData["EbookError"] = "The ebook file must be a PDF.";
                return RedirectToAction(nameof(Index));
            }

            var book = await context.Books.FindAsync(bookId);
            if (book == null) return RedirectToAction(nameof(Index));

            var fileName = $"{Guid.NewGuid()}.pdf";
            var folderPath = Path.Combine(ev.WebRootPath, "files", "ebooks");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var existing = await context.Ebooks.FirstOrDefaultAsync(e => e.BookId == bookId);
            if (existing != null)
            {
                // Replacing an existing ebook: delete the old physical file first.
                var oldPath = Path.Combine(ev.WebRootPath, existing.FilePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (System.IO.File.Exists(oldPath))
                    System.IO.File.Delete(oldPath);

                existing.FilePath = $"/files/ebooks/{fileName}";
                existing.OriginalFileName = file.FileName;
                existing.UploadedDate = DateTime.Now;
            }
            else
            {
                context.Ebooks.Add(new Ebook
                {
                    BookId = bookId,
                    FilePath = $"/files/ebooks/{fileName}",
                    OriginalFileName = file.FileName,
                    UploadedDate = DateTime.Now
                });
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPost]
        public async Task<IActionResult> Remove(int bookId)
        {
            var existing = await context.Ebooks.FirstOrDefaultAsync(e => e.BookId == bookId);
            if (existing != null)
            {
                var oldPath = Path.Combine(ev.WebRootPath, existing.FilePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (System.IO.File.Exists(oldPath))
                    System.IO.File.Delete(oldPath);

                context.Ebooks.Remove(existing);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // Member-facing page: browse only the books that have an ebook version.
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Catalog()
        {
            var books = await context.Books
                .Include(b => b.Author)
                .Where(b => context.Ebooks.Any(e => e.BookId == b.Id))
                .OrderBy(b => b.Title)
                .ToListAsync();

            return View(books);
        }

        // Member-facing page: read online / download.
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Read(int bookId)
        {
            var book = await context.Books.Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == bookId);
            if (book == null) return RedirectToAction("Index", "Book");

            var ebook = await context.Ebooks.FirstOrDefaultAsync(e => e.BookId == bookId);

            ViewBag.Book = book;
            return View(ebook);
        }
    }
}