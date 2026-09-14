using System.Reflection.Metadata.Ecma335;
using ITI_Project.Data;
using ITI_Project.Model;
using ITI_Project.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace ITI_Project.Controllers
{
    public class ReservationsController (AppDbContext context) : Controller
    {
        // 1. عرض جميع الحجوزات وقائمة الانتظار للـ Admin
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Books = await context.Books.ToListAsync();
            ViewBag.Members = await context.Members.Where(m => !m.IsBlocked).ToListAsync();
            var reservations = await context.Reservations
                .Include(r => r.Book)
                .Include(r => r.Member)
                .OrderBy(r => r.ReservationDate)
                .ToListAsync();
            var reservationList = reservations.Select(r => new ReservationViewModel
            {
                Id = r.Id,
                BookTitle = r.Book?.Title?? "UnKnown",
                MemberName = r.Member?.UserName?? "UnKnown",
                MemberEmail = r.Member?.Email?? "",
                ReservationDate = r.ReservationDate,
                Status = r.Status,

                QueuePosition = context.Reservations
                .Count(other => other.BookId == r.BookId &&
                        other.Status == "Pending" &&
                        other.ReservationDate <= r.ReservationDate)
            }).ToList();

            return View(reservationList);
        }

        [HttpPost]
        public async Task<IActionResult> Create( int bookId, int memberId)
        {
            var existingReservation = await context.Reservations
                .FirstOrDefaultAsync (r => r.BookId == bookId && r.MemberId == memberId && r.Status == "Pending");

            if (existingReservation != null)
            {
                TempData["Error"] = "You already have an active reservation for this book.";
                return RedirectToAction("Details", "Book", new { id = bookId });
            }
            var reservation = new Reservation
            {
                BookId = bookId,
                MemberId = memberId,
                ReservationDate = DateTime.Now,
                Status = "pending"
            };
            context.Reservations.Add(reservation);
            await context.SaveChangesAsync();

            TempData["Success"] = "You have been added to the waiting list successfully!";
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Cancel(int id)
        {
            var reservation = await context.Reservations.FindAsync (id);
            if (reservation == null) return NotFound();

            reservation.Status = "Cancelled";
            await context.SaveChangesAsync();

            TempData["Success"] = "Reservation cancelled Successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
