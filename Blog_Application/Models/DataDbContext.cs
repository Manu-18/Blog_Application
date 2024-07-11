using Microsoft.EntityFrameworkCore;

namespace Blog_Application.Models
{
    public class DataDbContext:DbContext
    {
        public DataDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<BlogPost>BlogPosts { get; set; }
       
    }
}
