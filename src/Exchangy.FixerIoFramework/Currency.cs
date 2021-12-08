using System.Collections.Generic;

namespace Exchangy.FixerIoFramework
{
    public class Currency
    {
        public bool Success { get; set; }
        public int TimeStamp { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
        public Dictionary<string, double> Rates { get; set; }
    }
}
