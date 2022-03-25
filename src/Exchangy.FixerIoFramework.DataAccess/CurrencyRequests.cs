using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exchangy.FixerIoFramework.DataAccess
{
    public class CurrencyRequests
    {
        [Key]
        public int CurrencyRequestsId { get; set; }
        public string BaseCurrency { get; set; }
        public DateTime RequestDate { get; set; }
        public virtual List<RateResults> Rates { get; set; }
    }
}