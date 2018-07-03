namespace Conan.Plugin.NullGuard.Test
{
    using System;

    class Class2
    {
        public Class2(string p1)
        {

        }

        public static void Foo1([NonNull] string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void Foo2(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class InnerClass2
        {
            public static void Foo1([NonNull] string p1, int p2, [NonNull] object p3)
            {
                Console.WriteLine("Hello World!");
            }
        }
    }
}
