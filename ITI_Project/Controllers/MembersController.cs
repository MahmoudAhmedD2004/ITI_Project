using ITI_Project.Data;
using ITI_Project.Model;
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
                    Role = m.Role,
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

        // ---------- Admin-only: full member management ----------

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View(new AdminCreateMemberViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(AdminCreateMemberViewModel model)
        {
            if (await context.Members.AnyAsync(m => m.UserName == model.UserName))
                ModelState.AddModelError(nameof(model.UserName), "This username is already taken.");

            if (await context.Members.AnyAsync(m => m.Email == model.Email))
                ModelState.AddModelError(nameof(model.Email), "This email is already registered.");

            if (!ModelState.IsValid)
                return View(model);

            var member = new Member
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PasswordHash = model.Password,
                Role = model.Role,
                MembershipStartDate = DateTime.Now,
                MembershipExpiryDate = DateTime.Now.AddDays(30)
            };

            context.Members.Add(member);
            await context.SaveChangesAsync();

            TempData["Success"] = "New user created successfully.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var member = await context.Members.FindAsync(id);
            if (member == null) return NotFound();

            var model = new AdminEditMemberViewModel
            {
                Id = member.Id,
                UserName = member.UserName,
                Email = member.Email,
                PhoneNumber = member.PhoneNumber,
                Role = member.Role
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, AdminEditMemberViewModel model)
        {
            if (id != model.Id) return BadRequest();

            var member = await context.Members.FindAsync(id);
            if (member == null) return NotFound();

            if (await context.Members.AnyAsync(m => m.UserName == model.UserName && m.Id != id))
                ModelState.AddModelError(nameof(model.UserName), "This username is already taken.");

            if (await context.Members.AnyAsync(m => m.Email == model.Email && m.Id != id))
                ModelState.AddModelError(nameof(model.Email), "This email is already registered.");

            if (!string.IsNullOrWhiteSpace(model.NewPassword) && model.NewPassword.Length < 6)
                ModelState.AddModelError(nameof(model.NewPassword), "Password must be at least 6 characters.");

            if (!ModelState.IsValid)
                return View(model);

            member.UserName = model.UserName;
            member.Email = model.Email;
            member.PhoneNumber = model.PhoneNumber;
            member.Role = model.Role;

            if (!string.IsNullOrWhiteSpace(model.NewPassword))
                member.PasswordHash = model.NewPassword;

            await context.SaveChangesAsync();

            TempData["Success"] = "User updated successfully.";
            return RedirectToAction(nameof(Index));
        }

    }
}