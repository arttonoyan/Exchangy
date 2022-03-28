using System;
using System.Collections.Generic;

namespace Exchangy.DataAccess
{
    public class Currency
    {
        public int CurrencyRequestId { get; set; }
        public string BaseCurrency { get; set; }
        public DateTime RequestDate { get; set; }

        public virtual List<Rate> Rates { get; set; }
    }
}