using ITI_Project.Data;
using ITI_Project.Model;
using ITI_Project.ModelView;
using ITI_Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ITI_Project.Controllers
{
    public class BookController(IWebHostEnvironment ev, AppDbContext context, IAiService _aiService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var books = await context.Books.Include(b => b.Author)
                .OrderByDescending(b => b.PublishedYear).Take(5)
                .ToListAsync();

            var mostLoans = await context.Books.Include(b => b.Author).Include(b => b.BookCopies).ThenInclude(bc => bc.Loans)
                .OrderByDescending(b => b.BookCopies.Sum(bc => bc.Loans.Count)).Take(4).ToListAsync();

            var categories = await context.Categories.Include(c => c.Books).ToListAsync();

            var favorites = new List<Book>();
            if (User.Identity != null && User.Identity.IsAuthenticated && User.IsInRole("Member"))
            {
                favorites = await context.Favorites
                    .Include(f => f.Book).ThenInclude(b => b!.Author)
                    .Where(f => f.Member!.UserName == User.Identity.Name)
                    .OrderByDescending(f => f.AddedDate)
                    .Take(4)
                    .Select(f => f.Book!)
                    .ToListAsync();
            }

            var model = new HomeIndexViewModel
            {
                NewArrivals = books,
                MostLoans = mostLoans,
                Categories = categories,
                Favorites = favorites

            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return RedirectToAction(nameof(Index));

            var books = await context.Books.Include(b => b.Author).
                Where(b => b.Author.Name.Contains(query) ||
                b.Title.Contains(query) || b.ISBN.Contains(query)).ToListAsync();

            return View(books);
        }
        [HttpGet]
        public async Task<IActionResult> BookView(BookViewModel model)
        {
            const int pageSize = 10;

            model.Categories = await context.Categories.ToListAsync();
            var query = context.Books
                 .Include(b => b.Author)
                 .Include(b => b.Category)
                 .Include(b => b.BookCopies)
                 .Where(b =>
                     (model.Filter.Category == 0 ||
                         b.CategoryId == model.Filter.Category) &&

                     (model.Filter.Author == 0 ||
                         b.AuthorId == model.Filter.Author) &&

                     (string.IsNullOrEmpty(model.Filter.BookLanguage) ||
                         b.BookLanguage == model.Filter.BookLanguage) &&

                     (model.Filter.Availability == null ||
                         b.BookCopies.Any(bc =>
                             bc.Status == model.Filter.Availability))
                 );

            switch (model.Filter.SortBy)
            {
                case "title_asc":
                    query = query.OrderBy(b => b.Title);
                    break;
                case "title_desc":
                    query = query.OrderByDescending(b => b.Title);
                    break;
                case "year_asc":
                    query = query.OrderBy(b => b.PublishedYear);
                    break;
                case "year_desc":
                    query = query.OrderByDescending(b => b.PublishedYear);
                    break;
                default:
                    query = query.OrderBy(b => b.Title);
                    break;
            }

            var totalCount = await query.CountAsync();
            model.Filter.TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            if (model.Filter.Page < 1) model.Filter.Page = 1;
            if (model.Filter.TotalPages > 0 && model.Filter.Page > model.Filter.TotalPages)
                model.Filter.Page = model.Filter.TotalPages;

            model.Books = await query
                .Skip((model.Filter.Page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            model.Authors = await context.Authors.ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var book = await context.Books.Include(b => b.Author).Include(b => b.Category)
                        .Include(b => b.BookCopies).ThenInclude(bc => bc.Loans).
                        Include(b => b.Reviews).ThenInclude(r => r.Member).
                        FirstAsync(b => b.Id == id);

            ViewBag.IsFavorite = User.Identity != null && User.Identity.IsAuthenticated
                && await context.Favorites.AnyAsync(f => f.BookId == id && f.Member!.UserName == User.Identity.Name);

            ViewBag.HasEbook = await context.Ebooks.AnyAsync(e => e.BookId == id);

            return View(book);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> CreateBook(BookViewModel model)
        {
            model.Authors = await context.Authors.ToListAsync();
            model.Categories = await context.Categories.ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Create")] CreateBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var vm = new BookViewModel
                {
                    Create = model,
                    Authors = await context.Authors.ToListAsync(),
                    Categories = await context.Categories.ToListAsync()
                };
                return View("CreateBook", vm);
            }
            string path = "";
            if (model.CoverImageFile != null && model.CoverImageFile.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.CoverImageFile.FileName)}";
                var folderPath = Path.Combine(ev.WebRootPath, "images", "books");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.CoverImageFile.CopyToAsync(stream);
                }

                // هنا بس بتتحول لـ string وتتخزن في العمود
                path = $"/images/books/{fileName}";
            }


            var newBook = new Book
            {
                Title = model.Title,
                ISBN = model.ISBN,
                Summary = model.Summary,
                BookLanguage = model.BookLanguage,
                PublishedYear = model.PublishedYear,
                CoverImage = path,
                AuthorId = model.AuthorId,
                CategoryId = model.CategoryId
            };
            await context.Books.AddAsync(newBook);
            await context.SaveChangesAsync();

            if (model.EbookFile != null && model.EbookFile.Length > 0)
            {
                if (string.Equals(Path.GetExtension(model.EbookFile.FileName), ".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    var ebookFileName = $"{Guid.NewGuid()}.pdf";
                    var ebookFolderPath = Path.Combine(ev.WebRootPath, "files", "ebooks");

                    if (!Directory.Exists(ebookFolderPath))
                        Directory.CreateDirectory(ebookFolderPath);

                    var ebookFilePath = Path.Combine(ebookFolderPath, ebookFileName);

                    using (var stream = new FileStream(ebookFilePath, FileMode.Create))
                    {
                        await model.EbookFile.CopyToAsync(stream);
                    }

                    context.Ebooks.Add(new Ebook
                    {
                        BookId = newBook.Id,
                        FilePath = $"/files/ebooks/{ebookFileName}",
                        OriginalFileName = model.EbookFile.FileName,
                        UploadedDate = DateTime.Now
                    });
                    await context.SaveChangesAsync();
                }
                else
                {
                    TempData["EbookError"] = "The ebook file must be a PDF. The book was created without an ebook version.";
                }
            }

            return RedirectToAction("Index");


        }
        public async Task<IActionResult> Report(ReportViewModel model)
        {
            model.Loans = await context.Loans.Include(l => l.Member)
                .Include(l => l.BookCopy).ThenInclude(bc => bc.Book)
                .Where(l => l.Status == LoanStatus.Returned
                         && l.ReturnDate != null
                         && l.DueDate != null
                         && l.ReturnDate > l.DueDate.Value.AddDays(14))
                .ToListAsync();

            var loans = await context.Loans.GroupBy(l => l.BookCopyId)
                .Select(g => new { g.Key, Count = g.Count() })
                .Take(10).ToListAsync();

            foreach (var l in loans)
            {
                var book = await context.BookCopies.Include(bc => bc.Book)
                    .FirstOrDefaultAsync(bc => bc.Id == l.Key);
                if (book?.Book != null)
                    model.MostBorrowed[book.Book.Title] = l.Count;
            }

            var category = await context.Categories.Include(c => c.Books).ThenInclude(b => b.BookCopies)
                .ThenInclude(bc => bc.Loans).ToListAsync();
            model.Categories = category
                .Where(c => c.Books.All(b => b.BookCopies.All(bc => !bc.Loans.Any())))
                .ToList();

            var loansPerMonth = await context.Loans
                .Where(l => l.BorrowDate != null)
                .GroupBy(l => new { l.BorrowDate!.Value.Year, l.BorrowDate!.Value.Month })
                .Select(g => new { g.Key.Year, g.Key.Month, Count = g.Count() })
                .OrderBy(g => g.Year).ThenBy(g => g.Month)
                .ToListAsync();

            var labels = loansPerMonth
                .Select(x => new DateTime(x.Year, x.Month, 1).ToString("MMM yyyy"))
                .ToList();

            var values = loansPerMonth.Select(x => x.Count).ToList();

            ViewBag.ChartLabels = labels;
            ViewBag.ChartValues = values;

            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "Librarian,Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null) return RedirectToAction("Index", "Book");

            return View(book);
        }

        [HttpPost]
        [Authorize(Roles = "Librarian,Admin")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book is not null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Book");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await context.Books.FindAsync(id);

            BookViewModel model = new();
            model.Book = book;
            model.Authors = await context.Authors.ToListAsync();
            model.Categories = await context.Categories.ToListAsync();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditBook(Book book)
        {
            context.Books.Update(book);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Book");
        }
        [HttpPost]
        public async Task<IActionResult> AutoSummary([FromBody] AutoSummaryRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.BackCoverText))
            {
                return BadRequest(new { message = "Back cover text is required." });
            }

            try
            {
                var categoryNames = await context.Categories.Select(c => c.Name).ToListAsync();

                var result = await _aiService.GenerateBookSummaryAsync(request.BackCoverText, categoryNames);
                return Json(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
