using BulkyWebRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
