using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using LipSyncTimeLineControl.Controls;
using LipSyncTimeLineControl.Models;

namespace LipSyncTimeLineControl.Helper
{
    internal static class BoundsHelper
    {
        internal static RectangleF GetTrackExtents(TimelineTrackBase track, Timeline timeline, int indexTrack) => RectangleToTrackExtents(track == null ? new RectangleF() : new RectangleF(track.Start, 0, track.End - track.Start, 0), timeline, indexTrack);

        internal static RectangleF RectangleToTrackExtents(RectangleF rect, Timeline timeline, int assumedTrackIndex)
        {
            Rectangle trackAreaBounds = timeline.GetTrackAreaBounds();
            int actualRowHeight = (int) (timeline.TrackHeight * timeline.RenderingScale.Y + timeline.TrackSpacing);
            int trackOffsetY = (int) (trackAreaBounds.Y + actualRowHeight * assumedTrackIndex + timeline.RenderingOffset.Y);
            int trackOffsetX = (int) (trackAreaBounds.X + rect.X * timeline.RenderingScale.X + timeline.RenderingOffset.X);
            RectangleF trackExtent = new RectangleF(trackOffsetX, trackOffsetY, rect.Width * timeline.RenderingScale.X, timeline.TrackHeight * timeline.RenderingScale.Y);
            return trackExtent;
        }

        internal static bool IntersectsAny(RectangleF test, List<RectangleF> subjects) => subjects.Any(subject => subject.IntersectsWith(test));
    }
}