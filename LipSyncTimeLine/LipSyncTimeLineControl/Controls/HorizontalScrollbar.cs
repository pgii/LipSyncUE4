using System;
using System.Drawing;
using System.Windows.Forms;

namespace LipSyncTimeLineControl.Controls
{
    public sealed partial class HorizontalScrollbar : AbstractScrollbar
    {
        public HorizontalScrollbar() : base(ScrollOrientation.HorizontalScroll)
        {
            InitializeComponent();
        }

        protected override void Redraw()
        {
            RecalculateThumbBounds();

            GraphicsContainer.Clear(BackgroundColor);
            float thumbCenter = ValueToPosition(Value);
            ThumbBounds.X = (int) (thumbCenter - ThumbBounds.Width / 2f);
            int margin = Height - ThumbBounds.Height;
            Rectangle visibleBounds = ThumbBounds;
            visibleBounds.X += margin / 2;
            visibleBounds.Width -= margin;

            GraphicsContainer.FillRectangle(ForegroundBrush, visibleBounds);
        }

        private int ValueToPosition(int value)
        {
            int range = Max - Min;

            if (0 == range) 
                return 0;

            float relativeValue = (float) value / range;
            float centerOffset = relativeValue - 0.5f;
            float halfWidth = Width / 2f;
            float thumbCenter = halfWidth + centerOffset * (Width - ThumbBounds.Width);

            return (int) thumbCenter;
        }

        private int PositionToValue(int position)
        {
            int constrainedWidth = Width - ThumbBounds.Width;
            int halfThumbWidth = ThumbBounds.Width / 2;
            float relativePosition = (float) (position - halfThumbWidth) / constrainedWidth;
            int assumedValue = (int) (relativePosition * (Max - Min));
            int limitedValue = Math.Max(Min, Math.Min(Max, assumedValue));

            return limitedValue;
        }

        private void RecalculateThumbBounds()
        {
            float minWidth = Math.Max(MinThumbExtent, Width * 0.1f);
            float naiveWidth = (float) Width - (Max - Min);
            ThumbBounds.Width = (int) Math.Max(minWidth, naiveWidth);
            ThumbBounds.Height = (int) (Height * 0.8f);
            ThumbBounds.Y = (int) (Height * 0.1f);
        }

        private void HorizontalScrollbarLoad(object sender, EventArgs e)
        {
            Redraw();
            Refresh();
        }

        private void HorizontalScrollbarMouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                int delta = e.X - ScrollDeltaOrigin;
                int oldValue = Value;
                Value = PositionToValue(ScrollOrigin + delta);
                InvokeScrollEvent(new ScrollEventArgs(ScrollEventType.ThumbTrack, oldValue, Value, ScrollOrientation.HorizontalScroll));
                Redraw();
                Refresh();
            }
        }

        private void HorizontalScrollbarMouseDown(object sender, MouseEventArgs e)
        {
            ScrollDeltaOrigin = e.X;
            ScrollOrigin = ValueToPosition(Value);
        }
    }
}