using ITI_Project.Data;
using ITI_Project.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    public class MembersController(AppDbContext context) : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 10;
            if (page < 1) page = 1;

            var query = context.Members
                .Select(m => new MemberViewModel
                {
                    Id = m.Id,
                    UserName = m.UserName,
                    Email = m.Email,
                    MembershipStartDate = m.MembershipStartDate,
                    MembershipExpiryDate = m.MembershipExpiryDate,
                    IsBlocked = m.IsBlocked,
                    ActiveLoansCount = context.Loans.Count(l => l.MemberId == m.Id && l.ReturnDate == null),
                    TotalUnpaidFines = context.Fines.Where(f => f.Loan.MemberId == m.Id && !f.IsPaid).Sum(f => f.Amount)
                });

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            if (totalPages > 0 && page > totalPages) page = totalPages;

            var members = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(members);
        }

        // Block Member & UnBlock
        [HttpPost]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> ToggleBlock(int id)
        {
            var member = await context.Members.FindAsync(id);
            if (member == null) return NotFound();

            member.IsBlocked = !member.IsBlocked;
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Librarian")]
        public async Task<IActionResult> Details(int id, int loansPage = 1, int reservationsPage = 1)
        {
            const int pageSize = 5;

            var member = await context.Members.FindAsync(id);
            if (member == null) return NotFound();

            // Loans with paging
            var loansQuery = context.Loans
                .Include(l => l.BookCopy).ThenInclude(bc => bc.Book)
                .Include(l => l.Fines)
                .Where(l => l.MemberId == id)
                .OrderByDescending(l => l.RequestDate);

            var totalLoans = await loansQuery.CountAsync();
            var totalLoansPages = (int)Math.Ceiling(totalLoans / (double)pageSize);
            if (loansPage < 1) loansPage = 1;
            if (totalLoansPages > 0 && loansPage > totalLoansPages) loansPage = totalLoansPages;

            var loans = await loansQuery
                .Skip((loansPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Reservations with paging
            var reservationsQuery = context.Reservations
                .Include(r => r.Book)
                .Where(r => r.MemberId == id)
                .OrderByDescending(r => r.ReservationDate);

            var totalReservations = await reservationsQuery.CountAsync();
            var totalReservationsPages = (int)Math.Ceiling(totalReservations / (double)pageSize);
            if (reservationsPage < 1) reservationsPage = 1;
            if (totalReservationsPages > 0 && reservationsPage > totalReservationsPages)
                reservationsPage = totalReservationsPages;

            var reservations = await reservationsQuery
                .Skip((reservationsPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.Member = member;
            ViewBag.Loans = loans;
            ViewBag.Reservations = reservations;
            ViewBag.LoansPage = loansPage;
            ViewBag.TotalLoansPages = totalLoansPages;
            ViewBag.ReservationsPage = reservationsPage;
            ViewBag.TotalReservationsPages = totalReservationsPages;

            return View();
        }

    }
}