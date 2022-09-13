using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Model
{
    internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property<byte[]>("ProfilePic")
                        .HasColumnType("varbinary(max)");
            builder.Property<string>("FavTeam")
            .HasColumnType("nvarchar(max)");
        }
    }
}