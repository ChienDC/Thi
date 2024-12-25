using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thi.Models;

namespace Thi.Controllers
{
    public class ComicBooksController : Controller
    {
        private readonly ThiDbContext _context;

        public ComicBooksController(ThiDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ComicBooks.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComicBookID,Title,Author,PricePerDay")] ComicBooks comicBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comicBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comicBooks);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicBooks = await _context.ComicBooks
                .FirstOrDefaultAsync(m => m.ComicBookID == id);
            if (comicBooks == null)
            {
                return NotFound();
            }

            return View(comicBooks);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicBooks = await _context.ComicBooks.FindAsync(id);
            if (comicBooks == null)
            {
                return NotFound();
            }
            return View(comicBooks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComicBookID,Title,Author,PricePerDay")] ComicBooks comicBooks)
        {
            if (id != comicBooks.ComicBookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comicBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComicBooksExists(comicBooks.ComicBookID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(comicBooks);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicBooks = await _context.ComicBooks
                .FirstOrDefaultAsync(m => m.ComicBookID == id);
            if (comicBooks == null)
            {
                return NotFound();
            }

            return View(comicBooks);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comicBooks = await _context.ComicBooks.FindAsync(id);
            if (comicBooks != null)
            {
                _context.ComicBooks.Remove(comicBooks);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComicBooksExists(int id)
        {
            return _context.ComicBooks.Any(e => e.ComicBookID == id);
        }
    }
}
