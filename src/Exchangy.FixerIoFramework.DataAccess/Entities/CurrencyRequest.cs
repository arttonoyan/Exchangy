using System;
using System.Collections.Generic;

namespace Exchangy.FixerIoFramework.DataAccess
{
    public class CurrencyRequest
    {
        public int CurrencyRequestId { get; set; }
        public string BaseCurrency { get; set; }
        public DateTime RequestDate { get; set; }

        public virtual List<RateResult> Rates { get; set; }
    }
}