using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchangy.FixerIoFramework.DataAccess
{
    internal class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        public CurrencyContext Context { get; set; }
        public CurrencyRepository(CurrencyContext context) : base(context)
        {
            Context = context;
        }
    }
}
