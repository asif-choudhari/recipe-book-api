using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using recipe_book_api.Models;

namespace recipe_book_api.Mappings
{
    public class RecipeMap : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("recipe");

            builder.Property(a => a.Id)
                .HasColumnName("id");

            builder.Property(a => a.Name)
                .HasColumnName("name");

            builder.Property(a => a.Description)
                .HasColumnName("description");

            builder.Property(a => a.ImagePath)
                .HasColumnName("imgPath");

            builder.Property(a => a.IngredientsJSON)
                .HasColumnName("ingredients");

            builder.Ignore(a => a.Ingredients);
        } 
    }
}
