using System;
using System.Drawing;
using System.Windows.Forms;

namespace LipSyncTimeLineControl.Scrollbar
{
    public sealed partial class VerticalScrollbar : AbstractScrollbar
    {
        public VerticalScrollbar() : base(ScrollOrientation.VerticalScroll)
        {
            InitializeComponent();
        }

        protected override void Redraw()
        {
            RecalculateThumbBounds();

            GraphicsContainer.Clear(BackgroundColor);
            float thumbCenter = ValueToPosition(Value);
            ThumbBounds.Y = (int) (thumbCenter - ThumbBounds.Height / 2f);
            int margin = Width - ThumbBounds.Width;
            Rectangle visibleBounds = ThumbBounds;
            visibleBounds.Y += margin / 2;
            visibleBounds.Height -= margin;

            GraphicsContainer.FillRectangle(ForegroundBrush, visibleBounds);
        }

        private int ValueToPosition(int value)
        {
            int range = Max - Min;

            if (0 == range) 
                return 0;

            float relativeValue = (float) value / (Max - Min);
            float centerOffset = relativeValue - 0.5f;
            float halfHeight = Height / 2f;
            float thumbCenter = halfHeight + centerOffset * (Height - ThumbBounds.Height);

            return (int) thumbCenter;
        }

        private int PositionToValue(int position)
        {
            int constrainedHeight = Height - ThumbBounds.Height;
            int halfThumbHeight = ThumbBounds.Height / 2;
            float relativePosition = (float) (position - halfThumbHeight) / constrainedHeight;
            int assumedValue = (int) (relativePosition * (Max - Min));
            int limitedValue = Math.Max(Min, Math.Min(Max, assumedValue));

            return limitedValue;
        }

        private void RecalculateThumbBounds()
        {
            float minHeight = Math.Max(MinThumbExtent, Height * 0.1f);
            float naiveHeight = (float) Height - (Max - Min);
            ThumbBounds.Height = (int) Math.Max(minHeight, naiveHeight);
            ThumbBounds.Width = (int) (Width * 0.8f);
            ThumbBounds.X = (int) (Width * 0.1f);
        }

        private void VerticalScrollbarLoad(object sender, EventArgs e)
        {
            Redraw();
            Refresh();
        }

        private void VerticalScrollbarMouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != 0)
            {
                int delta = e.Y - ScrollDeltaOrigin;
                int oldValue = Value;
                Value = PositionToValue(ScrollOrigin + delta);
                InvokeScrollEvent(new ScrollEventArgs(ScrollEventType.ThumbTrack, oldValue, Value, ScrollOrientation.VerticalScroll));
                Redraw();
                Refresh();
            }
        }

        private void VerticalScrollbarMouseDown(object sender, MouseEventArgs e)
        {
            ScrollDeltaOrigin = e.Y;
            ScrollOrigin = ValueToPosition(Value);
        }
    }
}