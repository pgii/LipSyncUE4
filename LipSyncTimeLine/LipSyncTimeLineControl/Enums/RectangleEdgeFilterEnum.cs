using System;

namespace LipSyncTimeLineControl.Enums
{
    public class RectangleEdgeFilterEnum
    {
        [Flags]
        public enum RectangleEdgeFilter
        {
            None = 0,
            TopLeft = 1,
            TopRight = 2,
            BottomLeft = 4,
            BottomRight = 8
        }
    }
}