using Admin.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Admin.Data
{
    public class AplicationDbContext : IdentityDbContext
    {
        internal object orderStatuses;

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }
        public DbSet<Product> products { get; set; }
        //  public DbSet<Login> logins { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        
        public DbSet<order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }


    }


}



