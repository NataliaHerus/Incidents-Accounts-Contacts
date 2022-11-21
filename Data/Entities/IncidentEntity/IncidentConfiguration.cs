using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities.IncidentEntity
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.Property(x => x.Name).ValueGeneratedOnAdd();

            builder.HasKey(x => x.Name);

            builder
                .Property(x => x.Description)
                .IsRequired();
        }
    }
}
