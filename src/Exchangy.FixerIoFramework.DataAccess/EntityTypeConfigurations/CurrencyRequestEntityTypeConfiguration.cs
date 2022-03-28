using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exchangy.FixerIoFramework.DataAccess.EntityTypeConfigurations
{
    public class CurrencyRequestEntityTypeConfiguration : IEntityTypeConfiguration<CurrencyRequest>
    {
        public void Configure(EntityTypeBuilder<CurrencyRequest> builder)
        {
            builder
                .HasKey(b => b.CurrencyRequestId);
        }
    }
}
