using BookStoreMachineTest.Models;

namespace BookStoreMachineTest.ViewModels
{
    public class DashboardViewModel
    {
        // Stats
        public int TotalBooks { get; set; }
        public int TotalCategories { get; set; }
        public decimal TotalInventoryValue { get; set; }
        public decimal AveragePrice { get; set; }
        public string MostPopularCategory { get; set; } = string.Empty;
        public Book? MostExpensiveBook { get; set; }

        // Table data
        public List<Book> Books { get; set; } = new();
        public string? SearchTerm { get; set; }
    }
}
