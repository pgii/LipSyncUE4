using System.Drawing;
using LipSyncTimeLineControl.Enums;

namespace LipSyncTimeLineControl.Helper
{
    internal static class RectangleHelper
    {
        internal static RectangleF Normalize(PointF start, PointF end)
        {
            RectangleF result = new RectangleF();
            if (end.X < start.X)
            {
                result.X = end.X;
                result.Width = start.X - result.X;
            }
            else
            {
                result.X = start.X;
                result.Width = end.X - result.X;
            }

            if (end.Y < start.Y)
            {
                result.Y = end.Y;
                result.Height = start.Y - result.Y;
            }
            else
            {
                result.Y = start.Y;
                result.Height = end.Y - result.Y;
            }

            return result;
        }

        internal static RectangleEdgeEnum IsPointOnEdge(RectangleF rectangle, PointF test, float tolerance)
        {
            if (!rectangle.Contains(test))
                return RectangleEdgeEnum.None;

            RectangleEdgeEnum result = RectangleEdgeEnum.None;

            if (test.X <= rectangle.X + rectangle.Width && test.X >= rectangle.X + rectangle.Width - tolerance)
                result |= RectangleEdgeEnum.Right;

            if (test.X >= rectangle.X && test.X <= rectangle.X + tolerance)
                result |= RectangleEdgeEnum.Left;

            return result;
        }
    }
}