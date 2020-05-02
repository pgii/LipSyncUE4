using System.Collections.Generic;
using System.Drawing;

namespace LipSyncTimeLineControl.Helper
{
    internal static class Extensions
    {
        public static Rectangle ToRectangle(this RectangleF input)
        {
            return new Rectangle((int) input.X, (int) input.Y, (int) input.Width, (int) input.Height);
        }

        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item;
        }
    }
}