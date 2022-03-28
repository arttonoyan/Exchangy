using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exchangy.DataAccess.Configurations
{
    public class RateEntityTypeConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
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
