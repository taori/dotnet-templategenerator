using System;
using Generator.Domain.Utility;
using Shouldly;
using Xunit;

namespace Generator.Infrastructure.UnitTests
{
    public class ExceptionTests
    {
        [Fact]
        public void TestExitCodeConstructor2Throws()
        {
            Assert.Throws<ArgumentException>(() => new WellKnownException(0));
        }
        
        [Fact]
        public void TestExitCodeConstructor3Throws()
        {
            Assert.Throws<ArgumentException>(() => new WellKnownException(0));
        }
        
        [Fact]
        public void TestValidConstructor2()
        {
            var ex = new WellKnownException(1);
            ex.ShouldNotBeNull();
            ex.ExitCode.ShouldBe(1);
        }
        
        [Fact]
        public void TestValidConstructor3()
        {
            var ex = new WellKnownException(1);
            ex.ShouldNotBeNull();
            ex.ExitCode.ShouldBe(1);
        }
    }
}