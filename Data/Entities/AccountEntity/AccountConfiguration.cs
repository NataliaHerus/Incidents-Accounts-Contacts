using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities.AccountEntity
{
    public class AccountConfiguration: IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasKey(x => x.Id); 

            builder
              .Property(x => x.Name)
              .HasMaxLength(50)
              .IsRequired();

            builder
                .HasIndex(i => i.Name)
                .IsUnique();

            builder
                .HasOne(x => x.Incident)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.IncidentName);
        }
    }
}
