namespace Conan.Plugin.NullGuard.Test
{
    using System;

    class Class1
    {
        public Class1([NonNull] string p1)
        {

        }

        public void Bar1()
        {
            Console.WriteLine("Hello World!");
        }

        public void Bar2(string message)
        {
            Console.WriteLine(message);
        }
    }
}
