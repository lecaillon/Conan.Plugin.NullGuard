namespace Conan.Plugin.NullGuard.Test
{
    using System;
    using Xunit;

    public class Class2Test
    {
        [Fact]
        public void Instantiate_Class2_With_Null_Parameter_Works()
        {
            new Class2(null);
        }

        [Fact]
        public void A_Call_To_Foo1_With_Null_Parameter_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Class2.Foo1(null));
        }

        [Fact]
        public void A_Call_To_Foo2_With_Null_Parameter_Works()
        {
            Class2.Foo2(null);
        }

        [Fact]
        public void A_Call_To_InnerClass2_Foo1_With_Null_Parameters_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Class2.InnerClass2.Foo1(null, 0, new object()));
            Assert.Throws<ArgumentNullException>(() => Class2.InnerClass2.Foo1("", 0, null));
        }
    }
}
