using System.Collections.Generic;
using LipSyncTimeLineControl.Helper;
using LipSyncTimeLineControl.Models;

namespace LipSyncTimeLineControl.Template
{
    public static class ExpressionTemplate
    {
        public static Dictionary<string, ExpressionTimelineTrack> ExpressionTrackTemplateDictionary => SettingsHelper.LoadExpressionTemplate();

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
