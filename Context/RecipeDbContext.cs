using Microsoft.EntityFrameworkCore;
using recipe_book_api.Mappings;
using recipe_book_api.Models;

namespace recipe_book_api.Context
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options) { }

        public DbSet<Identity> Identities { get; set; }
        public DbSet<Ingredient> Ingredients { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new IdentityMap());
            modelBuilder.ApplyConfiguration(new IngredientMap());
        }
    }
}
