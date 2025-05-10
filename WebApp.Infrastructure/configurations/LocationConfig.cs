using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Core.models;

namespace WebApp.Infrastructure.configurations
{
    public class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasOne(l => l.ApplicationUser).WithMany(a => a.Locations)
                    .HasForeignKey(l => l.ClientId);

            builder.HasMany(l => l.Jobs).WithOne(j => j.Location)
                    .HasForeignKey(j => j.LocationId);
            
        }

    }



}
