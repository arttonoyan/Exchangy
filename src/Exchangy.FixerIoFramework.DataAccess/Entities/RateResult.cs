using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exchangy.FixerIoFramework.DataAccess
{
    public class RateResult
    {
        public int RateResultId { get; set; }
        public string Currency { get; set; }
        public double Rate { get; set; }

        public int CurrencyRequestId { get; set; }
        public virtual CurrencyRequest CurrencyRequest { get; set; }
    }
}