using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exchangy.FixerIoFramework.DataAccess.EntityTypeConfigurations
{
    public class RateResultEntityTypeConfiguration : IEntityTypeConfiguration<RateResult>
    {
        public void Configure(EntityTypeBuilder<RateResult> builder)
        {
            builder
                .HasKey(b => b.RateResultId);

            builder
                .HasOne(p => p.CurrencyRequest)
                .WithMany(b => b.Rates)
                .HasForeignKey(p => p.CurrencyRequestId);
        }
    }
}
