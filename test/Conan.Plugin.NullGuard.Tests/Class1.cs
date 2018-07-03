namespace Conan.Plugin.NullGuard.Test
{
    class Class1
    {
        public Class1([NonNull] string p1)
        {

        }

        public void Bar1()
        {
        }

        public string Bar2(string p1)
        {
            return p1.ToLower();
        }
    }
}
