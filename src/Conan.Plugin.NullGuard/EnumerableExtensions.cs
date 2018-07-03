namespace Conan.Plugin.NullGuard
{
    using System.Collections;

    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Filters the elements of a given <paramref name="source"/> based on specified T1 and T2 types.
        /// </summary>
        public static IEnumerable OfType<T1, T2>(this IEnumerable source)
        {
            foreach (object item in source)
            {
                if (item is T1 || item is T2)
                {
                    yield return item;
                }
            }
        }
    }
}
