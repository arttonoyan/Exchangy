namespace Exchangy.DataAccess
{
    public class Rate
    {
        public int RateResultId { get; set; }
        public string Currency { get; set; }
        public double Value { get; set; }

        public int CurrencyRequestId { get; set; }
        public virtual Currency CurrencyRequest { get; set; }
    }
}