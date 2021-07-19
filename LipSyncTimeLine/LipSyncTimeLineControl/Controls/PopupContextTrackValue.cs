using LipSyncTimeLineControl.Models;

namespace LipSyncTimeLineControl.Controls
{
    public partial class PopupContextTrackValue : PopupContextControl
    {
        private float Value
        {
            set
            {
                tbTrackValue.Value = (int) (value * 10);
                lblValue.Text = value.ToString("N1");
            }
        }

        private readonly TimelineTrackBase _selectedTrack;

        public PopupContextTrackValue(float value, TimelineTrackBase selectedTrack)
        {
            InitializeComponent();

            Value = value;
            _selectedTrack = selectedTrack;
        }

        private void tbTrackValue_Scroll(object sender, System.EventArgs e)
        {
            Value = (float) tbTrackValue.Value / 10;
            _selectedTrack.Value = (float) tbTrackValue.Value / 10;
        }
    }
}
