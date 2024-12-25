using Microsoft.AspNetCore.Mvc;
using Thi.Models;

namespace Thi.Controllers
{
    public class RentalsController : Controller
    {
        private readonly ThiDbContext _context;

        public RentalsController(ThiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int customerId, DateTime rentalDate, DateTime returnDate, int comicBookId, int quantity)
        {
            if (ModelState.IsValid)
            {
                var rental = new Rentals
                {
                    CustomerID = customerId,
                    RentalDate = rentalDate,
                    ReturnDate = returnDate,
                    Status = "Dang thue"
                };
                _context.Rentals.Add(rental);
                await _context.SaveChangesAsync();

                var comicBook = await _context.ComicBooks.FindAsync(comicBookId);

                var rentalDetail = new RetalDetails
                {
                    RentalID = rental.RentalID,
                    ComicBookID = comicBookId,
                    Quantity = quantity,
                    PricePerDay = comicBook.PricePerDay
                };
                _context.RetalDetails.Add(rentalDetail);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "ComicBooks");
            }
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.ComicBooks = _context.ComicBooks.ToList();
            return View();
        }
    }
}