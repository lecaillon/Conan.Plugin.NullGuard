namespace Conan.Plugin.NullGuard.Test
{
    using System;
    using Xunit;

    public class Class2Test
    {
        [Fact]
        public void InstantiateClass2WithNullParameterWorks()
        {
            new Class2(null);
        }

        [Fact]
        public void ACallToFoo1WithNullParameterThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Class2.Foo1(null));
        }

        [Fact]
        public void ACallToFoo2WithNullParameterWorks()
        {
            Class2.Foo2(null);
        }

        [Fact]
        public void ACallToInnerClass2Foo1WithNullParametersThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Class2.InnerClass2.Foo1(null, 0, new object()));
            Assert.Throws<ArgumentNullException>(() => Class2.InnerClass2.Foo1("", 0, null));
        }
    }
}
