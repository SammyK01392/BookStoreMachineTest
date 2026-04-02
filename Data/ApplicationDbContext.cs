using BookStoreMachineTest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreMachineTest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ── Seed Books ──────────────────────────────────────────────
            builder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Clean Code", Author = "Robert C. Martin", Category = "Programming", Price = 35.99m, Description = "A handbook of agile software craftsmanship." },
                new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Category = "Programming", Price = 42.50m, Description = "Your journey to mastery." },
                new Book { Id = 3, Title = "Design Patterns", Author = "Gang of Four", Category = "Architecture", Price = 55.00m, Description = "Elements of reusable object-oriented software." }
            );

            // ── Seed Admin User ─────────────────────────────────────────
            // Login: admin@bookstore.com / Admin@123
            const string adminId = "a1b2c3d4-e5f6-7890-abcd-ef1234567890";

            var hasher = new PasswordHasher<IdentityUser>();
            var adminUser = new IdentityUser
            {
                Id = adminId,
                UserName = "admin@bookstore.com",
                NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                Email = "admin@bookstore.com",
                NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                EmailConfirmed = true,
                SecurityStamp = "STATIC_SECURITY_STAMP_V1",
                ConcurrencyStamp = "STATIC_CONCURRENCY_STAMP_V1"
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@123");

            builder.Entity<IdentityUser>().HasData(adminUser);
        }
    }
}