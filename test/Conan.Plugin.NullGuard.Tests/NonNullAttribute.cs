namespace Conan.Plugin.NullGuard.Test
{
    using System;

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class NonNullAttribute : Attribute
    {
    }
}
