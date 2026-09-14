using ITI_Project.Data;
using ITI_Project.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project.Controllers
{
    public class MembersController (AppDbContext context) : Controller
    {
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
            var members = await context.Members
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

                })
                .ToListAsync()
                ;

            return View(members);
        }

        // Block Member & UnBlock
        [HttpPost]  
        public async Task<IActionResult> ToggleBlock(int id)
        {
            var member = await context.Members.FindAsync(id);
            if (member == null) return NotFound();

            member.IsBlocked = !member.IsBlocked;
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var member = await context.Members.FindAsync(id);
            if (member == null) return NotFound();

            var loans = await context.Loans
                .Include(l => l.BookCopy)
                    .ThenInclude(bc => bc.Book)
                .Include(l => l.Fines)
                .Where(l => l.MemberId == id)
                .OrderByDescending(l => l.BorrowDate)
                .ToListAsync();

            ViewBag.Member = member;
            return View(loans);
        }
     
    }
}
