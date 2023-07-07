using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using recipe_book_api.Models;

namespace recipe_book_api.Mappings
{
    public class IngredientMap : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder) 
        {
            builder.ToTable("ingredient");

            builder.Property(a => a.Id)
                .HasColumnName("id");

            builder.Property(a => a.Name)
                .HasColumnName("name");

            builder.Property(a => a.Amount)
                .HasColumnName("amount");
        }
    }
}
