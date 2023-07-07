using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using recipe_book_api.Models;

namespace recipe_book_api.Mappings
{
    public class IdentityMap : IEntityTypeConfiguration<Identity>
    {
        public void Configure(EntityTypeBuilder<Identity> builder)
        {
            builder.ToTable("identity");

            builder.Property(a => a.Id)
                .HasColumnName("id");

            builder.Property(a => a.IdentityId)
                .HasColumnName("identity");

            builder.Property(a => a.IdentityName)
                .HasColumnName("dbName");
        }
    }
}
