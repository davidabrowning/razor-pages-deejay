using Microsoft.EntityFrameworkCore;
using RazorPagesDeejay.Models;

namespace RazorPagesDeejay.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
