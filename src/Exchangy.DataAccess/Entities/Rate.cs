namespace Exchangy.DataAccess
{
    public class Rate
    {
        public int RateId { get; set; }
        public string Currency { get; set; }
        public double Value { get; set; }

        public int CurrencyId { get; set; }
        public virtual Currency BaseCurrency { get; set; }
    }
}