using System.Collections.Generic;
using System.Linq;
using LipSyncTimeLineControl.Models;

namespace LipSyncTimeLineControl.Helper
{
    internal static class SurrogateHelper
    {
        public static List<TimelineTrackBase> GetSurrogates(IEnumerable<TimelineTrackBase> tracks) => new List<TimelineTrackBase>(tracks.Select(track => new SurrogateTrack(track)).ToList());
    }
}
