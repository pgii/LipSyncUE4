using LipSyncTimeLineControl.Enums;
using LipSyncTimeLineControl.Models;
using System.Collections.Generic;

namespace LipSyncTimeLineControl
{
    public static class MorphTemplate
    {
        public static Dictionary<string, MorphTimelineTrack> MorphTemplateDictionary = new Dictionary<string, MorphTimelineTrack>
        {
            {"AI", new MorphTimelineTrack("AI", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_AI)},
            {"E", new MorphTimelineTrack("E", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_E)},
            {"U", new MorphTimelineTrack("U", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_U)},
            {"O", new MorphTimelineTrack("O", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_O)},
            {"TH", new MorphTimelineTrack("TH", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_CDGKNRSThYZ)},
            {"FV", new MorphTimelineTrack("FV", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_FV)},
            {"L", new MorphTimelineTrack("L", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_L)},
            {"MBP", new MorphTimelineTrack("MBP", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_MBP)},
            {"WQ", new MorphTimelineTrack("WQ", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_WQ)},

            {"MouthSmile", new MorphTimelineTrack("MouthSmile", 0, 50, 0.5f, TimelineTrackTypeEnum.Expression)},
            {"SmileFullFace", new MorphTimelineTrack("SmileFullFace", 0, 50, 1, TimelineTrackTypeEnum.Expression)},
            {"BrowUpDown", new MorphTimelineTrack("BrowUpDown", 0, 50, 1, TimelineTrackTypeEnum.Expression)},
            {"Flirting", new MorphTimelineTrack("Flirting", 0, 50, 1, TimelineTrackTypeEnum.Expression)},
            {"Frown", new MorphTimelineTrack("Frown", 0, 50, 1, TimelineTrackTypeEnum.Expression)},
            {"EyesClosed", new MorphTimelineTrack("EyesClosed", 0, 50, 1, TimelineTrackTypeEnum.Expression)},
            {"EyesUpDown", new MorphTimelineTrack("EyesUpDown", 0, 50, 1, TimelineTrackTypeEnum.Expression)},
            {"EyesSideSide", new MorphTimelineTrack("EyesSideSide", 0, 50, 1, TimelineTrackTypeEnum.Expression)}
        };
    }
}
