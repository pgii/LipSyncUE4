using LipSyncTimeLineControl.Models;
using System.Windows.Forms;

namespace LipSyncTimeLineControl
{
    public sealed class MorphListBox : ListBox
    {
        public MorphListBox()
        {
            ItemHeight = 16;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            const TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;

            if (e.Index >= 0)
            {
                e.DrawBackground();

                if (e.Index >= 0 && e.Index < Items.Count && Items[e.Index] is TimelineTrackBase timelineTrack)
                {
                    TextRenderer.DrawText(e.Graphics, timelineTrack.Name, e.Font, e.Bounds, e.ForeColor, flags);
                    e.DrawFocusRectangle();
                }
            }
        }
    }
}
