using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exchangy.FixerIoFramework.DataAccess
{
    public class RateResults
    {
        [Key]
        public int RateResultsId { get; set; }
        public string Currency { get; set; }
        public double Rate { get; set; }
        [ForeignKey("CurrencyRequestsId")]
        public virtual CurrencyRequests CurrencyRequest { get; set; }
    }
}