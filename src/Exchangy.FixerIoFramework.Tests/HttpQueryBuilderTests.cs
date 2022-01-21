using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exchangy.FixerIoFramework.Tests
{
    public class HttpQueryBuilderTests
    {
        [Fact]
        public void BuildTest()
        {
            var query = HttpQueryBuilder.Build(KeyValuePair.Create("symbols", "AMD"));
            Assert.Equal("symbols=AMD", query);

            query = HttpQueryBuilder.Build(
                KeyValuePair.Create("test1", "a1"),
                KeyValuePair.Create("test2", "a2"));

            Assert.Equal("test1=a1&test2=a2", query);
        }
    }
}
