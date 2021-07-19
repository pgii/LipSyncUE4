using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LipSyncTimeLineControl.Controls
{
    public partial class AbstractScrollbar : UserControl
    {
        protected const int MinThumbExtent = 10;

        [Description("The current value of the scrollbar.")]
        [Category("Value")]
        public int Value
        {
            get => _value;
            set
            {
                int oldValue = _value;
                _value = Math.Max(Min, Math.Min(Max, value));
                InvokeScrollEvent(new ScrollEventArgs(ScrollEventType.ThumbPosition, oldValue, _value, Orientation));

                if (_value == Min)
                {
                    InvokeScrollEvent(new ScrollEventArgs(ScrollEventType.First, oldValue, _value, Orientation));
                }
                else if (_value == Max)
                {
                    InvokeScrollEvent(new ScrollEventArgs(ScrollEventType.Last, oldValue, _value, Orientation));
                }

                Redraw();
            }
        }

        private int _value;

        [Description("The smallest possible value of the scrollbar.")]
        [Category("Value")]
        public int Min
        {
            get => _min;
            set
            {
                _min = value;
                Redraw();
            }
        }

        private int _min;

        [Description("The largest possible value of the scrollbar.")]
        [Category("Value")]
        public int Max
        {
            get => _max;
            set
            {
                _max = value;
                Redraw();
            }
        }

        private int _max = 100;

        private Bitmap PixelMap { get; set; }

        protected Graphics GraphicsContainer { get; set; }

        [Description("The background color of the scrollbar.")]
        [Category("Drawing")]
        public Color BackgroundColor { get; set; } = Color.Black;

        [Description("The foreground color of the scrollbar.")]
        [Category("Drawing")]
        [Browsable(true)]
        public Color ForegroundColor
        {
            get => _foregroundColor;
            set
            {
                _foregroundColor = value;
                ForegroundBrush = new SolidBrush(_foregroundColor);
            }
        }

        private Color _foregroundColor = Color.Gray;

        protected Brush ForegroundBrush = new SolidBrush(Color.Gray);

        protected Rectangle ThumbBounds = new Rectangle(0, 0, 0, 0);

        public ScrollOrientation Orientation { get; }

        protected int ScrollDeltaOrigin;

        protected int ScrollOrigin;

        public new event EventHandler<ScrollEventArgs> Scroll;

        protected void InvokeScrollEvent(ScrollEventArgs eventArgs)
        {
            Scroll?.Invoke(this, eventArgs);
        }

        public AbstractScrollbar()
        {

        }

        protected AbstractScrollbar(ScrollOrientation orientation)
        {
            Orientation = orientation;

            InitializeComponent();
            InitializePixelMap();
        }

        protected virtual void Redraw()
        {
            
        }

        private void InitializePixelMap()
        {
            if (Width <= 0 || Height <= 0)
                return;

            PixelMap = new Bitmap(Width, Height);
            GraphicsContainer = Graphics.FromImage(PixelMap);
            GraphicsContainer.Clear(BackgroundColor);
            Refresh();
        }

        private void AbstractScrollbarResize(object sender, EventArgs e)
        {
            InitializePixelMap();
            Redraw();
            Refresh();
        }

        private void AbstractScrollbarPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(PixelMap, 0, 0);
        }
    }
}