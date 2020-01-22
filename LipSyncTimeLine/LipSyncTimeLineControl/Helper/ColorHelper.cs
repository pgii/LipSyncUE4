using System;
using System.Collections.Generic;
using System.Drawing;

namespace LipSyncTimeLineControl.Helper
{
    internal static class ColorHelper
    {
        public static List<Color> GetRandomColors(int count)
        {
            double step = 360.0 / count;
            List<Color> colors = new List<Color>();
            for (uint i = 0; i < count; ++i)
            {
                double value = i * step;
                colors.Add(ColorFromHSV(value, 0.6, 0.8));
            }

            return colors;
        }

        private static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = max == 0 ? 0 : 1d - 1d * min / max;
            value = max / 255d;
        }

        private static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value *= 255;
            int v = Convert.ToInt32(value).Clamp(0, 255);
            int p = Convert.ToInt32(value * (1 - saturation)).Clamp(0, 255);
            int q = Convert.ToInt32(value * (1 - f * saturation)).Clamp(0, 255);
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation)).Clamp(0, 255);

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            return Color.FromArgb(255, v, p, q);
        }

        public static Color AdjustColor(Color color, double hue, double saturation, double value)
        {
            ColorToHSV(color, out double oldHue, out double oldSaturation, out double oldValue);

            double newHue = oldHue + hue;
            double newSaturation = oldSaturation + saturation;
            double newValue = oldValue + value;

            return ColorFromHSV(newHue, newSaturation, newValue);
        }
    }
}
