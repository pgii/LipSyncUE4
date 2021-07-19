using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LipSyncTimeLineControl.Models;

namespace LipSyncTimeLineControl.Controls
{
    public sealed partial class PopupContextContainer : ToolStripDropDown
    {
        private Control _popupContainer;

        public PopupContextContainer(Control popupControl)
        {
            InitializeComponent();

            _popupContainer = popupControl ?? throw new ArgumentNullException(nameof(popupControl));

            ToolStripControlHost controlHost = new ToolStripControlHost(popupControl) {AutoSize = false};

            Padding = Margin = controlHost.Padding = controlHost.Margin = Padding.Empty;

            popupControl.Location = Point.Empty;

            Items.Add(controlHost);

            popupControl.Disposed += delegate
            {
                popupControl = null;
                Dispose(true);
            };
        }

        public void Show(Control control, TimelineTrackBase focusedTrack, PointF point)
        {
            if (focusedTrack == null)
                throw new ArgumentNullException(nameof(focusedTrack));

            Show(control, new Point((int) point.X, (int) point.Y), ToolStripDropDownDirection.BelowRight);
        }

        protected override void OnOpening(CancelEventArgs e)
        {
            if (_popupContainer.IsDisposed || _popupContainer.Disposing)
            {
                e.Cancel = true;
                return;
            }

            base.OnOpening(e);
        }

        protected override void OnOpened(EventArgs e)
        {
            _popupContainer.Focus();
            base.OnOpened(e);
        }
    }
}
