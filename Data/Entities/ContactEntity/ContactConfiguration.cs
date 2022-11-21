using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Entities.ContactEntity
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder
               .Property(x => x.Email)
               .HasMaxLength(50)
               .IsRequired();

            builder
                .HasIndex(i => i.Email)
                .IsUnique();

            builder
                .HasOne(x => x.Account)
                .WithMany(x => x.Contacts)
                .HasForeignKey(x => x.AccountId);
        }
    }
}
