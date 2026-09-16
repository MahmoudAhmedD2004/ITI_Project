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
        public async Task<IActionResult> MyLoans(string? q, LoanStatus? status, string sortBy = "date_desc")
        {
            var member = await GetCurrentMemberAsync();
            if (member == null) return RedirectToAction("Index", "Member");

            var query = context.Loans
                .Include(l => l.BookCopy).ThenInclude(bc => bc!.Book)
                .Include(l => l.Fines)
                .Where(l => l.MemberId == member.Id)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(l => l.BookCopy != null && l.BookCopy.Book != null && l.BookCopy.Book.Title.Contains(q));
            }

            if (status != null)
            {
                query = query.Where(l => l.Status == status);
            }

            query = sortBy switch
            {
                "date_asc" => query.OrderBy(l => l.RequestDate),
                "date_desc" => query.OrderByDescending(l => l.RequestDate),
                "due_asc" => query.OrderBy(l => l.DueDate),
                "due_desc" => query.OrderByDescending(l => l.DueDate),
                _ => query.OrderByDescending(l => l.RequestDate),
            };

            var loans = await query.ToListAsync();

            ViewBag.Search = q;
            ViewBag.StatusFilter = status;
            ViewBag.SortBy = sortBy;

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
            return RedirectToAction("Review", new { loanId });//
        }



        // ---------- Staff actions (Librarian / Admin) ----------

        [Authorize(Roles = "Librarian,Admin")]
        public async Task<IActionResult> AllLoans(string? q, LoanStatus? status, string sortBy = "date_desc", int page = 1)
        {
            int pageSize = 10; // Number of loans per page

            var query = context.Loans
                .Include(l => l.BookCopy).ThenInclude(bc => bc!.Book)
                .Include(l => l.Member)
                .Include(l => l.Fines)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(l =>
                    (l.Member != null && l.Member.UserName.Contains(q)) ||
                    (l.BookCopy != null && l.BookCopy.Book != null && l.BookCopy.Book.Title.Contains(q)));
            }

            if (status != null)
            {
                query = query.Where(l => l.Status == status);
            }

            query = sortBy switch
            {
                "date_asc" => query.OrderBy(l => l.RequestDate),
                "date_desc" => query.OrderByDescending(l => l.RequestDate),
                "due_asc" => query.OrderBy(l => l.DueDate),
                "due_desc" => query.OrderByDescending(l => l.DueDate),
                _ => query.OrderByDescending(l => l.RequestDate),
            };

            var totalLoans = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalLoans / (double)pageSize);

            // Ensure page is within valid range
            if (page < 1) page = 1;
            if (page > totalPages && totalPages > 0) page = totalPages;

            var loans = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.Search = q;
            ViewBag.StatusFilter = status;
            ViewBag.SortBy = sortBy;

            return View(loans);
        }

        [Authorize(Roles = "Librarian,Admin")]
        public async Task<IActionResult> PendingRequests(string? q, string sortBy = "date_asc")
        {
            var query = context.Loans
                .Include(l => l.BookCopy).ThenInclude(bc => bc!.Book)
                .Include(l => l.Member)
                .Where(l => l.Status == LoanStatus.Requested)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(l =>
                    (l.Member != null && l.Member.UserName.Contains(q)) ||
                    (l.BookCopy != null && l.BookCopy.Book != null && l.BookCopy.Book.Title.Contains(q)));
            }

            query = sortBy switch
            {
                "date_desc" => query.OrderByDescending(l => l.RequestDate),
                _ => query.OrderBy(l => l.RequestDate),
            };

            var loans = await query.ToListAsync();

            ViewBag.Search = q;
            ViewBag.SortBy = sortBy;

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
            await PromoteNextReservationAsync(loan.BookCopy!);

            await context.SaveChangesAsync();
            return RedirectToAction("PendingRequests");
        }

        [Authorize(Roles = "Librarian,Admin")]
        public async Task<IActionResult> PendingReturns(string? q, string sortBy = "due_asc")
        {
            var query = context.Loans
                .Include(l => l.BookCopy).ThenInclude(bc => bc!.Book)
                .Include(l => l.Member)
                .Where(l => l.Status == LoanStatus.ReturnRequested)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(l =>
                    (l.Member != null && l.Member.UserName.Contains(q)) ||
                    (l.BookCopy != null && l.BookCopy.Book != null && l.BookCopy.Book.Title.Contains(q)));
            }

            query = sortBy switch
            {
                "due_desc" => query.OrderByDescending(l => l.DueDate),
                _ => query.OrderBy(l => l.DueDate),
            };

            var loans = await query.ToListAsync();

            ViewBag.Search = q;
            ViewBag.SortBy = sortBy;

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

            // Calculate the fine based on ReturnDate vs DueDate
            if (loan.ReturnDate != null && loan.DueDate != null && loan.ReturnDate.Value.Date > loan.DueDate.Value.Date)
            {
                var daysLate = (loan.ReturnDate.Value.Date - loan.DueDate.Value.Date).Days;
                var fineAmount = daysLate * FinePerDay;

                var existingFine = await context.Fines.FirstOrDefaultAsync(f => f.LoanId == loan.Id);

                if (existingFine == null)
                {
                    var fine = new Fine
                    {
                        LoanId = loan.Id,
                        Amount = fineAmount,
                        CreatedDate = DateTime.Now,
                        IsPaid = false
                    };
                    await context.Fines.AddAsync(fine);
                }
                else
                {
                    // Fine already exists (rare but possible) - recalculate its amount
                    existingFine.Amount = fineAmount;
                }

                await context.SaveChangesAsync();

                // Update the member's blocked status if unpaid total exceeds the threshold
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
            await PromoteNextReservationAsync(loan.BookCopy!);

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
        public async Task<IActionResult> AllFines(string? q, bool? paid, string sortBy = "date_desc")
        {
            // Saved fines (already paid or still unpaid)
            var savedFinesQuery = context.Fines
                .Include(f => f.Loan).ThenInclude(l => l!.Member)
                .Include(f => f.Loan).ThenInclude(l => l!.BookCopy).ThenInclude(bc => bc!.Book)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                savedFinesQuery = savedFinesQuery.Where(f =>
                    (f.Loan != null && f.Loan.Member != null && f.Loan.Member.UserName.Contains(q)) ||
                    (f.Loan != null && f.Loan.BookCopy != null && f.Loan.BookCopy.Book != null && f.Loan.BookCopy.Book.Title.Contains(q)));
            }

            if (paid != null)
            {
                savedFinesQuery = savedFinesQuery.Where(f => f.IsPaid == paid);
            }

            savedFinesQuery = sortBy switch
            {
                "date_asc" => savedFinesQuery.OrderBy(f => f.CreatedDate),
                "amount_desc" => savedFinesQuery.OrderByDescending(f => f.Amount),
                "amount_asc" => savedFinesQuery.OrderBy(f => f.Amount),
                _ => savedFinesQuery.OrderByDescending(f => f.CreatedDate),
            };

            var savedFines = await savedFinesQuery.ToListAsync();

            // Overdue Active/ReturnRequested loans that don't have a Fine record yet
            var overdueLoansQuery = context.Loans
                .Include(l => l.BookCopy).ThenInclude(bc => bc.Book)
                .Include(l => l.Member)
                .Where(l => (l.Status == LoanStatus.Active || l.Status == LoanStatus.ReturnRequested) &&
                            l.DueDate.HasValue &&
                            l.DueDate.Value.Date < DateTime.Now.Date &&
                            !context.Fines.Any(f => f.LoanId == l.Id))
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                overdueLoansQuery = overdueLoansQuery.Where(l =>
                    (l.Member != null && l.Member.UserName.Contains(q)) ||
                    (l.BookCopy != null && l.BookCopy.Book != null && l.BookCopy.Book.Title.Contains(q)));
            }

            // The "paid" filter only applies to recorded fines; overdue-without-fine loans
            // are inherently unpaid, so hide them when the "Paid" filter is selected.
            if (paid == true)
            {
                overdueLoansQuery = overdueLoansQuery.Where(l => false);
            }

            var overdueLoans = await overdueLoansQuery
                .OrderByDescending(l => l.DueDate)
                .ToListAsync();

            ViewBag.SavedFines = savedFines;
            ViewBag.OverdueLoans = overdueLoans;
            ViewBag.Search = q;
            ViewBag.PaidFilter = paid;
            ViewBag.SortBy = sortBy;

            return View();
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

                if (unpaidTotal < BlockThreshold)
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
                .FirstOrDefaultAsync(l => l.Id == loanId);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewViewModel review)
        {
            var member = await GetCurrentMemberAsync();
            if (member == null) return RedirectToAction("Index", "Member");

            var loan = await context.Loans.Include(b => b.BookCopy)
                .ThenInclude(b => b.Book)
                .FirstOrDefaultAsync(l => l.Id == review.LoanId);

            if (loan == null || loan.MemberId != member.Id)
            {
                TempData["Error"] = "This loan could not be found.";
                return RedirectToAction("MyLoans");
            }

            Review review1 = new();
            review1.Rating = review.Rating;
            review1.Comment = review.Comment;
            review1.MemberId = loan.MemberId;
            review1.BookId = loan.BookCopy.Book.Id;

            await context.Reviews.AddAsync(review1);
            await context.SaveChangesAsync();
            return RedirectToAction("MyLoans");
        }
    }
}