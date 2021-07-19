using System.Drawing;

namespace LipSyncTimeLineControl.Extension
{
    internal static class RectangleExtension
    {
        public static Rectangle ToRectangle(this RectangleF input) => new Rectangle((int) input.X, (int) input.Y, (int) input.Width, (int) input.Height);
    }
}