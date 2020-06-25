using System;
using Generator.Domain.Utility;
using Xunit;

namespace Generator.Infrastructure.UnitTests
{
    public class ExceptionTests
    {
        [Fact]
        public void TestExitCode()
        {
            Assert.Throws<ArgumentException>(() => new WellKnownException(0, "test"));
        }
    }
}