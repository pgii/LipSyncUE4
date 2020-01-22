using System;

namespace LipSyncTimeLineControl.Enums
{
    [Flags]
    internal enum RectangleEdgeEnum
    {
        None = 0,
        Top = 1,
        Right = 2,
        Bottom = 4,
        Left = 8
    }
}
