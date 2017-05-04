using Store.DAL.Entities;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Store.DAL.Context
{
    public class StoreContext : IdentityDbContext<User>
    {
        public StoreContext()
                : base("StoreDb")
        {

        }

        public static StoreContext Create()
        {
            return new StoreContext();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigureCascadeDeleting(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureCascadeDeleting(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(x => x.Categories)
                .WithMany(x => x.Products);
        }
    }
}
