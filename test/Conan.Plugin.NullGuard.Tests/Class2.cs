namespace Conan.Plugin.NullGuard.Test
{
    class Class2
    {
        public Class2(string p1)
        {

        }

        public static int Foo1([NonNull] string[] args)
        {
            return args.Length;
        }

        public static int Foo2(string[] args)
        {
            return 1;
        }

        public class InnerClass2
        {
            public static string Foo1([NonNull] string p1, int p2, [NonNull] object p3)
            {
                return p1.ToLower() + p3.ToString();
            }
        }
    }
}
