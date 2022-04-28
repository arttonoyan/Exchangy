using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exchangy.DataAccess.Configurations
{
    public class RateEntityTypeConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder
                .HasKey(b => b.RateId);

            builder
                .HasOne(p => p.BaseCurrency)
                .WithMany(b => b.Rates)
                .HasForeignKey(p => p.CurrencyId);
        }
    }
}
