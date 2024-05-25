using ExcelAI.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ExcelAI.Infrastructure.DAL
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public ApplicationContext(DbContextOptions options) 
            : base(options){}
    }
}
