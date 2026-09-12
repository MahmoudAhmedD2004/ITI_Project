using ITI_Project.Data;
using ITI_Project.Model;
using ITI_Project.ModelView;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ITI_Project.Controllers
{
    public class BookController(IWebHostEnvironment ev, AppDbContext context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var books = await context.Books.Include(b => b.Author)
                .OrderByDescending(b=>b.PublishedYear).Take(5)
                .ToListAsync();
            
            var mostLoans = await context.Books.Include(b=>b.Author).Include(b => b.BookCopies).ThenInclude(bc => bc.Loans)
                .OrderByDescending(b => b.BookCopies.Sum(bc => bc.Loans.Count)).Take(4).ToListAsync();

            var categories = await context.Categories.Include(c => c.Books).ToListAsync();

            var model = new HomeIndexViewModel
            {
                NewArrivals = books,
                MostLoans = mostLoans,
                Categories = categories

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

            return  View(books);
        }
        [HttpGet]
        public async Task<IActionResult> BookView(BookViewModel model)
        {

            model.Categories = await context.Categories.ToListAsync();
            model.Books = await context.Books
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

                     (string.IsNullOrEmpty(model.Filter.Availability) ||
                         b.BookCopies.Any(bc =>
                             bc.Status == model.Filter.Availability))
                 )
                 .ToListAsync();
            switch (model.Filter.SortBy)
            {
                case "title_asc":
                    model.Books = model.Books
                        .OrderBy(b => b.Title)
                        .ToList();
                    break;

                case "title_desc":
                    model.Books = model.Books
                        .OrderByDescending(b => b.Title)
                        .ToList();
                    break;

                case "year_asc":
                    model.Books = model.Books
                        .OrderBy(b => b.PublishedYear)
                        .ToList();
                    break;

                case "year_desc":
                    model.Books = model.Books
                        .OrderByDescending(b => b.PublishedYear)
                        .ToList();
                    break;
            }

            model.Authors = await context.Authors.ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var book = await context.Books.Include(b => b.Author).Include(b => b.Category)
                        .Include(b => b.BookCopies).ThenInclude(bc => bc.Loans).
                        Include(b=>b.Reviews).ThenInclude(r=>r.Member).
                        FirstAsync(b => b.Id == id);
            return View(book);
        }
        [HttpGet]
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
                return RedirectToAction("Index");
            
            
        }
    }
}
