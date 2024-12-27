using E_Commerce.API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.API.Data
{
    public class ECommerceDbContext: DbContext
    {
        public ECommerceDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)

        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
