using LipSyncTimeLineControl.Models;
using System.Drawing;
using System.Windows.Forms;

namespace LipSyncTimeLineControl.ToolTipCustom
{
    class ToolTipTrack : ToolTip
    {
        private TimelineTrackBase _enterTrack;

        public void Show(TimelineTrackBase enterTrack, string text, IWin32Window window, Point point, int duration)
        {
            if (_enterTrack != enterTrack)
            {
                _enterTrack = enterTrack;
                Show(text, window, point, duration);
            }
        }

        public void Hidden(IWin32Window window)
        {
            _enterTrack = new TextTimelineTrack("", 0, 0 , 0);
            Hide(window);
        }
    }
}
