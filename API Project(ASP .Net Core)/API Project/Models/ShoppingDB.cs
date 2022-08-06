using Microsoft.EntityFrameworkCore;

namespace API_Project.Models
{
    public class ShoppingDB:DbContext
    {
        public ShoppingDB()
        {

        }
        public ShoppingDB(DbContextOptions options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=APIProject;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
