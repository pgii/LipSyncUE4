using System.Drawing;
using System.Windows.Forms;

namespace LipSyncTimeLineControl.Helper
{
    internal static class SelectionHelper
    {
        public static bool IsSelected(RectangleF selectionRectangle, RectangleF boundingRectangle, Keys modifierKeys) => (modifierKeys & Keys.Alt) != 0 ? selectionRectangle.Contains(boundingRectangle) : selectionRectangle.IntersectsWith(boundingRectangle);
    }
}