using LipSyncTimeLineControl.Models;
using System.Collections.Generic;

namespace LipSyncTimeLineControl
{
    public static class ExpressionTemplate
    {
        public static readonly Dictionary<string, ExpressionTimelineTrack> ExpressionTrackTemplateDictionary = new Dictionary<string, ExpressionTimelineTrack>
        {
            {"MouthSmile", new ExpressionTimelineTrack("MouthSmile", 0, 50, 0.5f)},
            {"SmileFullFace", new ExpressionTimelineTrack("SmileFullFace", 0, 50, 1)},
            {"BrowUpDown", new ExpressionTimelineTrack("BrowUpDown", 0, 50, 1)},
            {"Flirting", new ExpressionTimelineTrack("Flirting", 0, 50, 1)},
            {"Frown", new ExpressionTimelineTrack("Frown", 0, 50, 1)},
            {"EyesClosed", new ExpressionTimelineTrack("EyesClosed", 0, 50, 1)},
            {"EyesUpDown", new ExpressionTimelineTrack("EyesUpDown", 0, 50, 1)},
            {"EyesSideSide", new ExpressionTimelineTrack("EyesSideSide", 0, 50, 1)}
        };

        public static bool GetExpressionTrackFromName(string phonemeName, out ExpressionTimelineTrack phonemeTimelineTrack)
        {
            if (ExpressionTrackTemplateDictionary.ContainsKey(phonemeName))
            {
                phonemeTimelineTrack = (ExpressionTimelineTrack)ExpressionTrackTemplateDictionary[phonemeName].Clone();
                return true;
            }

            phonemeTimelineTrack = null;
            return false;
        }
    }
}
