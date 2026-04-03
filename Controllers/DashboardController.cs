using BookStoreMachineTest.Data;
using BookStoreMachineTest.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreMachineTest.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? searchTerm)
        {
            var allBooks = await _context.Books.ToListAsync();

            var filteredBooks = string.IsNullOrWhiteSpace(searchTerm)
                ? allBooks
                : allBooks.Where(b =>
                    b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    b.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                  .ToList();

            var vm = new DashboardViewModel
            {
                TotalBooks        = allBooks.Count,
                TotalCategories   = allBooks.Select(b => b.Category).Distinct().Count(),
                TotalInventoryValue = allBooks.Sum(b => b.Price),
                AveragePrice      = allBooks.Any() ? allBooks.Average(b => b.Price) : 0,
                MostPopularCategory = allBooks
                    .GroupBy(b => b.Category)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .FirstOrDefault() ?? "—",
                MostExpensiveBook = allBooks.OrderByDescending(b => b.Price).FirstOrDefault(),
                Books             = filteredBooks,
                SearchTerm        = searchTerm
            };

            return View(vm);
        }
    }
}
