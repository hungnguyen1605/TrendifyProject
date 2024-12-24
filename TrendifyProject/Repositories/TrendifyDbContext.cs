using Microsoft.EntityFrameworkCore;

namespace TrendifyProject.Repositories
{
    public class TrendifyDbContext:DbContext
    {
        public TrendifyDbContext(DbContextOptions<TrendifyDbContext> options) : base(options) { }

    }
}
