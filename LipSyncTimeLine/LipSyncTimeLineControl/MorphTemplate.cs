using LipSyncTimeLineControl.Enums;
using LipSyncTimeLineControl.Models;
using System.Collections.Generic;

namespace LipSyncTimeLineControl
{
    public static class MorphTemplate
    {
        public static List<MorphTimelineTrack> MorphTemplateList = new List<MorphTimelineTrack>()
        {
            new MorphTimelineTrack("AI", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_AI),
            new MorphTimelineTrack("E", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_E),
            new MorphTimelineTrack("U", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_U),
            new MorphTimelineTrack("O", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_O),
            new MorphTimelineTrack("TH", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_CDGKNRSThYZ),
            new MorphTimelineTrack("FV", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_FV),
            new MorphTimelineTrack("L", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_L),
            new MorphTimelineTrack("MBP", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_MBP),
            new MorphTimelineTrack("WQ", 0, 50, 1, TimelineTrackTypeEnum.Phoneme, Properties.Resources.Phoneme_WQ),

            new MorphTimelineTrack("MouthSmile", 0, 50, 0.5f, TimelineTrackTypeEnum.Expression),
            new MorphTimelineTrack("SmileFullFace", 0, 50, 1, TimelineTrackTypeEnum.Expression),
            new MorphTimelineTrack("BrowUpDown", 0, 50, 1, TimelineTrackTypeEnum.Expression),
            new MorphTimelineTrack("Flirting", 0, 50, 1, TimelineTrackTypeEnum.Expression),
            new MorphTimelineTrack("Frown", 0, 50, 1, TimelineTrackTypeEnum.Expression),
            new MorphTimelineTrack("EyesClosed", 0, 50, 1, TimelineTrackTypeEnum.Expression),
            new MorphTimelineTrack("EyesUpDown", 0, 50, 1, TimelineTrackTypeEnum.Expression),
            new MorphTimelineTrack("EyesSideSide", 0, 50, 1, TimelineTrackTypeEnum.Expression)
        };
    }
}
