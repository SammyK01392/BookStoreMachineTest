using BookStoreMachineTest.Data;
using BookStoreMachineTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreMachineTest.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Books (with optional search)
        public async Task<IActionResult> Index(string? searchTerm)
        {
            var books = _context.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
                books = books.Where(b =>
                    b.Title.Contains(searchTerm) ||
                    b.Author.Contains(searchTerm) ||
                    b.Category.Contains(searchTerm));

            ViewBag.SearchTerm = searchTerm;
            return View(await books.ToListAsync());
        }

        // AJAX Search endpoint — returns partial view
        [HttpGet]
        public async Task<IActionResult> Search(string? term)
        {
            var books = string.IsNullOrWhiteSpace(term)
                ? await _context.Books.ToListAsync()
                : await _context.Books
                    .Where(b => b.Title.Contains(term) ||
                                b.Author.Contains(term) ||
                                b.Category.Contains(term))
                    .ToListAsync();

            return PartialView("_BookList", books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var book = await _context.Books.FindAsync(id);
            return book == null ? NotFound() : View(book);
        }

 
        public IActionResult Create() => View();

        // POST: Books/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Author,Category,Price,Description,CoverImageUrl")] Book book)
        {
            if (!ModelState.IsValid) return View(book);
            _context.Add(book);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Book added successfully!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var book = await _context.Books.FindAsync(id);
            return book == null ? NotFound() : View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Category,Price,Description,CoverImageUrl")] Book book)
        {
            if (id != book.Id) return NotFound();
            if (!ModelState.IsValid) return View(book);

            try
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Book updated successfully!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(b => b.Id == id)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var book = await _context.Books.FindAsync(id);
            return book == null ? NotFound() : View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null) _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Book deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}
