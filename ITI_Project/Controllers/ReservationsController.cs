using ITI_Project.Data;
using ITI_Project.Model;
using ITI_Project.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    public class ReservationsController (AppDbContext context) : Controller
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 10;
            if (page < 1) page = 1;

            var query = context.Reservations
                .Include(r => r.Book)
                .Include(r => r.Member)
                .AsQueryable();

            if (!User.IsInRole("Admin") && !User.IsInRole("Librarian"))
            {
                var member = await context.Members
                    .FirstOrDefaultAsync(m => m.UserName == User.Identity!.Name);

                if (member == null)
                    return RedirectToAction("Index", "Member");

                query = query.Where(r => r.MemberId == member.Id);
            }

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            if (totalPages > 0 && page > totalPages) page = totalPages;

            var reservations = await query
                .OrderBy(r => r.ReservationDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var reservationList = reservations.Select(r => new ReservationViewModel
            {
                Id = r.Id,
                BookTitle = r.Book?.Title ?? "Unknown",
                MemberName = r.Member?.UserName ?? "Unknown",
                MemberEmail = r.Member?.Email ?? "",
                ReservationDate = r.ReservationDate,
                Status = r.Status,
                QueuePosition = context.Reservations.Count(other =>
                    other.BookId == r.BookId &&
                    other.Status == "Pending" &&
                    other.ReservationDate <= r.ReservationDate)
            }).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(reservationList);
        }

        [HttpPost]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Create(int bookId)
        {
            var member = await context.Members
                .FirstOrDefaultAsync(m => m.UserName == User.Identity!.Name);

            if (member == null)
                return RedirectToAction("Index", "Member");

            if (member.IsBlocked || member.MembershipExpiryDate.Date < DateTime.Today)
            {
                TempData["Error"] = "Your membership is not eligible for reservations.";
                return RedirectToAction("Details", "Book", new { id = bookId });
            }

            var book = await context.Books
                .Include(b => b.BookCopies)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
                return NotFound();

            if (book.BookCopies.Any(c => c.Status == BookCopyStatus.Available))
            {
                TempData["Error"] = "A copy is available. Please request to borrow it instead.";
                return RedirectToAction("Details", "Book", new { id = bookId });
            }

            var exists = await context.Reservations.AnyAsync(r =>
                r.BookId == bookId &&
                r.MemberId == member.Id &&
                r.Status == "Pending");

            if (exists)
            {
                TempData["Error"] = "You already have an active reservation for this book.";
                return RedirectToAction("Details", "Book", new { id = bookId });
            }

            context.Reservations.Add(new Reservation
            {
                BookId = bookId,
                MemberId = member.Id,
                ReservationDate = DateTime.Now,
                Status = "Pending"
            });

            await context.SaveChangesAsync();

            TempData["Success"] = "You have been added to the waiting list successfully.";
            return RedirectToAction("Details", "Book", new { id = bookId });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Cancel(int id)
        {
            var reservation = await context.Reservations.FindAsync(id);
            if (reservation == null)
                return NotFound();

            var isStaff = User.IsInRole("Admin") || User.IsInRole("Librarian");

            if (!isStaff)
            {
                var member = await context.Members
                    .FirstOrDefaultAsync(m => m.UserName == User.Identity!.Name);

                if (member == null || reservation.MemberId != member.Id)
                    return Forbid();
            }

            if (!string.Equals(reservation.Status, "Pending", StringComparison.OrdinalIgnoreCase))
            {
                TempData["Error"] = "Only pending reservations can be cancelled.";
                return RedirectToAction(nameof(Index));
            }

            reservation.Status = "Cancelled";
            await context.SaveChangesAsync();

            TempData["Success"] = "Reservation cancelled successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}