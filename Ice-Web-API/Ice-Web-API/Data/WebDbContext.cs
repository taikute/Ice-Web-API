using Microsoft.EntityFrameworkCore;

namespace Ice_Web_API.Data
{
    public class WebDbContext:DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options) { }
        public DbSet<Book>? Books { get; set; }
    }
}
