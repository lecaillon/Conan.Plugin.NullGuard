namespace Conan.Plugin.NullGuard.Test
{
    using System;
    using Xunit;

    public class Class1Test
    {
        [Fact]
        public void Instantiate_Class1_With_Null_Parameter_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Class1(null));
        }

        [Fact]
        public void A_Call_To_Bar1_Works()
        {
            new Class1("").Bar1();
        }

        [Fact]
        public void A_Call_To_Bar2_Works()
        {
            new Class1("").Bar2("HelloWorld!");
        }
    }
}
