namespace Conan.Plugin.NullGuard.Test
{
    using System;
    using Xunit;

    public class Class1Test
    {
        [Fact]
        public void InstantiateClass1WithNullParameterThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Class1(null));
        }

        [Fact]
        public void ACallToBar1Works()
        {
            new Class1("").Bar1();
        }

        [Fact]
        public void ACallToBar2Works()
        {
            new Class1("").Bar2("HelloWorld!");
        }
    }
}
