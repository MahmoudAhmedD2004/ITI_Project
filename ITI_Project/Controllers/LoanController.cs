using ITI_Project.Data;
using ITI_Project.Model;
using ITI_Project.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    // TODO: once ASP.NET Core Identity is added, protect this controller with
    // [Authorize(Roles = "Admin,Librarian")] and auto-fill MemberId from the
    // signed-in user's session instead of picking it from a dropdown.
    public class LoanController(AppDbContext context) : Controller
    {
        private const int LoanPeriodDays = 14;
        private const decimal FinePerDay = 5m;

        public async Task<IActionResult> Index()
        {
            var loans = await context.Loans
                .Include(l => l.Member)
                .Include(l => l.BookCopy).ThenInclude(bc => bc!.Book)
                .Where(l => l.ReturnDate == null)
                .OrderBy(l => l.DueDate)
                .ToListAsync();

            return View(loans);
        }

        [HttpGet]
        public async Task<IActionResult> Borrow(int bookId)
        {
            var book = await context.Books
                .Include(b => b.BookCopies)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null) return NotFound();

            var model = await BuildBorrowViewModel(book);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Borrow(BorrowViewModel model)
        {
            var member = await context.Members.FindAsync(model.MemberId);
            if (member == null)
                ModelState.AddModelError(nameof(model.MemberId), "Please select a valid member.");
            else if (member.IsBlocked)
                ModelState.AddModelError(nameof(model.MemberId), "This member is blocked and cannot borrow books.");

            var freeCopy = await context.BookCopies
                .FirstOrDefaultAsync(bc => bc.BookId == model.BookId && bc.Status == "Available");

            if (freeCopy == null)
                ModelState.AddModelError("", "There are no available copies of this book right now.");

            if (!ModelState.IsValid)
            {
                var book = await context.Books
                    .Include(b => b.BookCopies)
                    .FirstOrDefaultAsync(b => b.Id == model.BookId);

                if (book == null) return NotFound();

                var refreshed = await BuildBorrowViewModel(book);
                refreshed.MemberId = model.MemberId;
                return View(refreshed);
            }

            var loan = new Loan
            {
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(LoanPeriodDays),
                MemberId = model.MemberId,
                BookCopyId = freeCopy!.Id
            };

            freeCopy.Status = "Borrowed";
            context.Loans.Add(loan);
            await context.SaveChangesAsync();

            TempData["Success"] = $"Loan created for \"{model.BookTitle}\". Due date: {loan.DueDate:yyyy-MM-dd}.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Return(int id)
        {
            var loan = await context.Loans
                .Include(l => l.BookCopy)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (loan == null) return NotFound();

            if (loan.ReturnDate != null)
            {
                TempData["Error"] = "This loan has already been returned.";
                return RedirectToAction(nameof(Index));
            }

            loan.ReturnDate = DateTime.Now;

            if (loan.BookCopy != null)
                loan.BookCopy.Status = "Available";

            if (loan.ReturnDate.Value.Date > loan.DueDate.Date)
            {
                int lateDays = (loan.ReturnDate.Value.Date - loan.DueDate.Date).Days;
                var fine = new Fine
                {
                    Amount = lateDays * FinePerDay,
                    CreatedDate = DateTime.Now,
                    IsPaid = false,
                    LoanId = loan.Id
                };
                context.Fines.Add(fine);
                TempData["Warning"] = $"Book returned {lateDays} day(s) late — a fine of {fine.Amount:0.##} was created.";
            }
            else
            {
                TempData["Success"] = "Book returned on time, no fine.";
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<BorrowViewModel> BuildBorrowViewModel(Book book)
        {
            return new BorrowViewModel
            {
                BookId = book.Id,
                BookTitle = book.Title,
                BookCover = book.CoverImage,
                TotalCopies = book.BookCopies.Count,
                AvailableCopies = book.BookCopies.Count(bc => bc.Status == "Available"),
                Members = await context.Members
                    .Where(m => !m.IsBlocked)
                    .OrderBy(m => m.UserName)
                    .ToListAsync()
            };
        }
    }
}