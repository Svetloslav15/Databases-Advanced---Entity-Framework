namespace BillsPaymentSystem.Data.EntityConfiguration
{
    using BillsSystem.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.Property(x => x.BankName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(x => x.SWIFT)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
