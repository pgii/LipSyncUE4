using System.Collections.Generic;

namespace LipSyncTimeLineControl.Extension
{
    internal static class CommonExtension
    {
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }
    }
}
