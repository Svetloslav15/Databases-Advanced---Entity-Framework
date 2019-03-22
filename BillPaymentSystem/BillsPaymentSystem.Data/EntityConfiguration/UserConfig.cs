using BillsSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPaymentSystem.Data.EntityConfiguration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(f => f.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(80);

            builder.Property(p => p.Password)
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
