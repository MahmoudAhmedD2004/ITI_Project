using ITI_Project.Data;
using ITI_Project.Model;
using ITI_Project.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    [Authorize]
    public class LoanController(AppDbContext context) : Controller
    {
        private const decimal FinePerDay = 5.0m;
        private const decimal BlockThreshold = 100m;

        private async Task<Member?> GetCurrentMemberAsync()
        {
            return await context.Members
                .FirstOrDefaultAsync(m => m.UserName == User.Identity!.Name);
        }

        // ---------- Member actions ----------

        private async Task PromoteNextReservationAsync(BookCopy copy)
        {
            var reservation = await context.Reservations
                .Include(r => r.Member)
                .Where(r => r.BookId == copy.BookId
                    && r.Status == "Pending"
                    && !r.Member!.IsBlocked
                    && r.Member.MembershipExpiryDate >= DateTime.Today)
                .OrderBy(r => r.ReservationDate)
                .FirstOrDefaultAsync();

            if (reservation == null)
            {
                copy.Status = BookCopyStatus.Available;
                return;
            }

            copy.Status = BookCopyStatus.Reserved;
            reservation.Status = "Fulfilled";

            context.Loans.Add(new Loan
            {
                BookCopyId = copy.Id,
                MemberId = reservation.MemberId,
                RequestDate = DateTime.Now,
                Status = LoanStatus.Requested
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RequestBorrow(int bookCopyId)
        {
            var member = await GetCurrentMemberAsync();
            if (member == null) return RedirectToAction("Index", "Member");

            if (member.IsBlocked)
            {
                TempData["Error"] = "Your account is blocked due to unpaid fines over 100 EGP. Please settle your fines to continue borrowing.";
                return RedirectToAction("MyLoans");
            }

            var copy = await context.BookCopies.FindAsync(bookCopyId);
            if (copy == null || copy.Status != BookCopyStatus.Available)
            {
                TempData["Error"] = "This copy is no longer available.";
                return RedirectToAction("Index", "Book");
            }

            var loan = new Loan
            {
                BookCopyId = copy.Id,
                MemberId = member.Id,
                RequestDate = DateTime.Now,
                Status = LoanStatus.Requested
            };

            copy.Status = BookCopyStatus.Reserved;

            await context.Loans.AddAsync(loan);
            await context.SaveChangesAsync();

            TempData["Success"] = "Your borrow request has been sent.";
            return RedirectToAction("MyLoans");
        }
        public async Task<IActionResult> MyLoans()
        {
            var member = await GetCurrentMemberAsync();
            if (member == null) return RedirectToAction("Index", "Member");

            var loans = await context.Loans
                .Include(l => l.BookCopy).ThenInclude(bc => bc!.Book)
                .Include(l => l.Fines)
                .Where(l => l.MemberId == member.Id)
                .OrderByDescending(l => l.RequestDate)
                .ToListAsync();

            return View(loans);
        }

        [HttpPost]
        public async Task<IActionResult> RequestReturn(int loanId)
        {
            var member = await GetCurrentMemberAsync();
            if (member == null) return RedirectToAction("Index", "Member");

            var loan = await context.Loans.FirstOrDefaultAsync(l => l.Id == loanId);
            if (loan == null || loan.MemberId != member.Id || loan.Status != LoanStatus.Active)
            {
                TempData["Error"] = "This loan can't be returned right now.";
                return RedirectToAction("MyLoans");
            }

            loan.Status = LoanStatus.ReturnRequested;
            await context.SaveChangesAsync();

            TempData["Success"] = "Return request sent. Please bring the book to the desk.";
            return RedirectToAction("Review",new { loanId });//
        }

        

        // ---------- Staff actions (Librarian / Admin) ----------

        [Authorize(Roles = "Librarian,Admin")]
        public async Task<IActionResult> PendingRequests()
        {
            var loans = await context.Loans
                .Include(l => l.BookCopy).ThenInclude(bc => bc!.Book)
                .Include(l => l.Member)
                .Where(l => l.Status == LoanStatus.Requested)
                .OrderBy(l => l.RequestDate)
                .ToListAsync();

            return View(loans);
        }

        [Authorize(Roles = "Librarian,Admin")]
        [HttpPost]
        public async Task<IActionResult> Approve(int loanId, int days)
        {
            if (days <= 0) days = 14; // fallback if the staff left it empty/invalid

            var loan = await context.Loans
                .Include(l => l.BookCopy)
                .FirstOrDefaultAsync(l => l.Id == loanId);

            if (loan == null || loan.Status != LoanStatus.Requested)
            {
                TempData["Error"] = "This request is no longer pending.";
                return RedirectToAction("PendingRequests");
            }

            loan.BorrowDate = DateTime.Now;
            loan.DueDate = DateTime.Now.AddDays(days);
            loan.Status = LoanStatus.Active;
            loan.BookCopy!.Status = BookCopyStatus.Borrowed;

            await context.SaveChangesAsync();
            return RedirectToAction("PendingRequests");
        }

        [Authorize(Roles = "Librarian,Admin")]
        [HttpPost]
        public async Task<IActionResult> Reject(int loanId, string reason)
        {
            var loan = await context.Loans
                .Include(l => l.BookCopy)
                .FirstOrDefaultAsync(l => l.Id == loanId);

            if (loan == null || loan.Status != LoanStatus.Requested)
            {
                TempData["Error"] = "This request is no longer pending.";
                return RedirectToAction("PendingRequests");
            }

            loan.Status = LoanStatus.Rejected;
            loan.RejectionReason = string.IsNullOrWhiteSpace(reason) ? "No reason provided." : reason;
            loan.BookCopy!.Status = BookCopyStatus.Available;

            await context.SaveChangesAsync();
            return RedirectToAction("PendingRequests");
        }

        [Authorize(Roles = "Librarian,Admin")]
        public async Task<IActionResult> PendingReturns()
        {
            var loans = await context.Loans
                .Include(l => l.BookCopy).ThenInclude(bc => bc!.Book)
                .Include(l => l.Member)
                .Where(l => l.Status == LoanStatus.ReturnRequested)
                .OrderBy(l => l.DueDate)
                .ToListAsync();

            return View(loans);
        }
        [Authorize(Roles = "Librarian,Admin")]
        [HttpPost]
        public async Task<IActionResult> ConfirmReturn(int loanId)
        {
            var loan = await context.Loans
                .Include(l => l.BookCopy)
                .Include(l => l.Member)
                .FirstOrDefaultAsync(l => l.Id == loanId);

            if (loan == null || loan.Status != LoanStatus.ReturnRequested)
            {
                TempData["Error"] = "This return is no longer pending.";
                return RedirectToAction("PendingReturns");
            }

            loan.ReturnDate = DateTime.Now;
            loan.Status = LoanStatus.Returned;
            loan.BookCopy!.Status = BookCopyStatus.Available;

            if (loan.ReturnDate > loan.DueDate)
            {
                var daysLate = (loan.ReturnDate.Value.Date - loan.DueDate!.Value.Date).Days;
                var fine = new Fine
                {
                    LoanId = loan.Id,
                    Amount = daysLate * FinePerDay,
                    CreatedDate = DateTime.Now,
                    IsPaid = false
                };
                await context.Fines.AddAsync(fine);
                await context.SaveChangesAsync();

                var unpaidTotal = await context.Fines
                    .Include(f => f.Loan)
                    .Where(f => !f.IsPaid && f.Loan!.MemberId == loan.MemberId)
                    .SumAsync(f => (decimal?)f.Amount) ?? 0m;

                if (unpaidTotal > BlockThreshold && loan.Member != null)
                {
                    loan.Member.IsBlocked = true;
                }
            }

            await context.SaveChangesAsync();
            return RedirectToAction("PendingReturns");
        }

        [HttpPost]
        public async Task<IActionResult> CancelBorrowRequest(int loanId)
        {
            var member = await GetCurrentMemberAsync();
            if (member == null) return RedirectToAction("Index", "Member");

            var loan = await context.Loans
                .Include(l => l.BookCopy)
                .FirstOrDefaultAsync(l => l.Id == loanId);

            if (loan == null || loan.MemberId != member.Id || loan.Status != LoanStatus.Requested)
            {
                TempData["Error"] = "This request can no longer be cancelled.";
                return RedirectToAction("MyLoans");
            }

            loan.Status = LoanStatus.Cancelled;
            loan.BookCopy!.Status = BookCopyStatus.Available;

            await context.SaveChangesAsync();

            TempData["Success"] = "Your borrow request was cancelled.";
            return RedirectToAction("MyLoans");
        }

        [HttpPost]
        public async Task<IActionResult> CancelReturnRequest(int loanId)
        {
            var member = await GetCurrentMemberAsync();
            if (member == null) return RedirectToAction("Index", "Member");

            var loan = await context.Loans
                .FirstOrDefaultAsync(l => l.Id == loanId);

            if (loan == null || loan.MemberId != member.Id || loan.Status != LoanStatus.ReturnRequested)
            {
                TempData["Error"] = "This return request can no longer be cancelled.";
                return RedirectToAction("MyLoans");
            }

            loan.Status = LoanStatus.Active;

            await context.SaveChangesAsync();

            TempData["Success"] = "Return request cancelled — the loan is active again.";
            return RedirectToAction("MyLoans");
        }

        [Authorize(Roles = "Librarian,Admin")]
        public async Task<IActionResult> AllFines()
        {
            var fines = await context.Fines
                .Include(f => f.Loan).ThenInclude(l => l!.Member)
                .Include(f => f.Loan).ThenInclude(l => l!.BookCopy).ThenInclude(bc => bc!.Book)
                .OrderByDescending(f => f.CreatedDate)
                .ToListAsync();

            return View(fines);
        }

        [Authorize(Roles = "Librarian,Admin")]
        [HttpPost]
        public async Task<IActionResult> MarkFinePaid(int fineId)
        {
            var fine = await context.Fines
                .Include(f => f.Loan).ThenInclude(l => l!.Member)
                .FirstOrDefaultAsync(f => f.Id == fineId);

            if (fine == null)
            {
                TempData["Error"] = "Fine not found.";
                return RedirectToAction("AllFines");
            }

            fine.IsPaid = true;
            await context.SaveChangesAsync();

            var member = fine.Loan?.Member;
            if (member != null && member.IsBlocked)
            {
                var unpaidTotal = await context.Fines
                    .Include(f => f.Loan)
                    .Where(f => !f.IsPaid && f.Loan!.MemberId == member.Id)
                    .SumAsync(f => (decimal?)f.Amount) ?? 0m;

                if (unpaidTotal <= BlockThreshold)
                {
                    member.IsBlocked = false;
                    await context.SaveChangesAsync();
                }
            }

            return RedirectToAction("AllFines");
        }
        // Add review
        public async Task<IActionResult> Review(int loanId)
        {
            ReviewViewModel model = new();
            model.Loan = await context.Loans.Include(b => b.BookCopy)
                .ThenInclude(b => b.Book)
                .FirstOrDefaultAsync(l=>l.Id==loanId);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewViewModel review)
        {
            var loan = await context.Loans.Include(b => b.BookCopy)
                .ThenInclude(b => b.Book)
                .FirstOrDefaultAsync(l => l.Id == review.LoanId);
            Review review1 = new();
            review1.Rating = review.Rating;
            review1.Comment = review.Comment;
            review1.MemberId = loan.MemberId;
            review1.BookId = loan.BookCopy.Book.Id;

            await context.Reviews.AddAsync(review1);
            await context.SaveChangesAsync();
            return Redirect("MyLoans");
        }
    }
}