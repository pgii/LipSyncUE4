using LipSyncTimeLineControl.Models;
using System.Collections.Generic;
using System.Drawing;

namespace LipSyncTimeLineControl
{
    public static class PhonemeTemplate
    {
        public static readonly Dictionary<string, PhonemeTimelineTrack> PhonemeTrackTemplateDictionary = new Dictionary<string, PhonemeTimelineTrack>
        {
            {"AI", new PhonemeTimelineTrack("AI", 0, 50, 1)},
            {"E", new PhonemeTimelineTrack("E", 0, 50, 1)},
            {"U", new PhonemeTimelineTrack("U", 0, 50, 1)},
            {"O", new PhonemeTimelineTrack("O", 0, 50, 1)},
            {"TH", new PhonemeTimelineTrack("TH", 0, 50, 1)},
            {"FV", new PhonemeTimelineTrack("FV", 0, 50, 1)},
            {"L", new PhonemeTimelineTrack("L", 0, 50, 1)},
            {"MBP", new PhonemeTimelineTrack("MBP", 0, 50, 1)},
            {"WQ", new PhonemeTimelineTrack("WQ", 0, 50, 1)}
        };

        public static bool GetPhonemeTrackFromName(string phonemeName, out PhonemeTimelineTrack phonemeTimelineTrack)
        {
            if (PhonemeTrackTemplateDictionary.ContainsKey(phonemeName))
            {
                phonemeTimelineTrack = (PhonemeTimelineTrack)PhonemeTrackTemplateDictionary[phonemeName].Clone();
                return true;
            }

            phonemeTimelineTrack = null;
            return false;
        }

        public static bool GetPhonemeTrackFromTemplate(string phonemeTemplateName, out PhonemeTimelineTrack phonemeTimelineTrack)
        {
            if (GetPhonemeFromTemplate(phonemeTemplateName, out string phonemeName))
            {
                if (PhonemeTrackTemplateDictionary.ContainsKey(phonemeName))
                {
                    phonemeTimelineTrack = (PhonemeTimelineTrack) PhonemeTrackTemplateDictionary[phonemeName].Clone();
                    return true;
                }

                phonemeTimelineTrack = null;
                return false;
            }

            phonemeTimelineTrack = null;
            return false;
        }

        private static readonly Dictionary<string, string> PhonemeTemplateDictionary = new Dictionary<string, string>
        {
            {"aa", "AI"}, {"aw", "O"}, {"ay", "AI"}, {"b", "MBP"}, {"c", "TH"}, {"d", "TH"}, {"eh", "E"}, {"ey", "E"},
            {"f", "FV"}, {"g", "TH"}, {"h", "TH"}, {"ih", "AI"}, {"iy", "E"}, {"k", "TH"}, {"l", "L"}, {"m", "MBP"},
            {"n", "L"}, {"ng", "L"}, {"ow", "O"}, {"oy", "WQ"}, {"p", "MBP"}, {"r", "TH"}, {"s", "TH"}, {"t", "TH"},
            {"th", "TH"}, {"uh", "U"}, {"uw", "U"}, {"v", "FV"}, {"w", "WQ"}, {"y", "TH"}, {"z", "TH"}
        };

        public static bool GetPhonemeFromTemplate(string phonemeTemplateName, out string phonemeName)
        {
            if (PhonemeTemplateDictionary.ContainsKey(phonemeTemplateName))
            {
                phonemeName = PhonemeTemplateDictionary[phonemeTemplateName];
                return true;
            }

            phonemeName = string.Empty;
            return false;
        }

        private static readonly Dictionary<string, Bitmap> PhonemeImageDictionary = new Dictionary<string, Bitmap>
        {
            {"AI", Properties.Resources.Phoneme_AI}, {"E", Properties.Resources.Phoneme_E}, {"U", Properties.Resources.Phoneme_U},
            {"O", Properties.Resources.Phoneme_O}, {"TH", Properties.Resources.Phoneme_CDGKNRSThYZ}, {"FV", Properties.Resources.Phoneme_FV},
            {"L", Properties.Resources.Phoneme_L}, {"MBP", Properties.Resources.Phoneme_MBP}, {"WQ", Properties.Resources.Phoneme_WQ}
        };

        public static Bitmap GetPhonemeImage(string phonemeName)
        {
            return PhonemeImageDictionary.ContainsKey(phonemeName) ? PhonemeImageDictionary[phonemeName] : null;
        }

        private static readonly Dictionary<string, float> PhonemeDurationDictionary = new Dictionary<string, float>
        {
            {"AI", 5.0f}, {"E", 4.5f}, {"U", 4.0f}, {"O", 4.0f}, {"TH", 2.0f}, {"FV", 2.5f}, {"L", 3.0f}, {"MBP", 1.5f}, {"WQ", 4.0f}
        };

        public static float GetPhonemeDuration(string phonemeName)
        {
            return PhonemeDurationDictionary.ContainsKey(phonemeName) ? PhonemeDurationDictionary[phonemeName] : 1;
        }
    }
}
