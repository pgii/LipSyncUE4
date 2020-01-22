using LipSyncTimeLineControl.Models;

namespace LipSyncTimeLineControl.Popup
{
    public partial class PopupContextTrackText : PopupContextControl
    {
        private readonly TimelineTrackBase _selectedTrack;

        public PopupContextTrackText(TimelineTrackBase selectedTrack)
        {
            InitializeComponent();

            _selectedTrack = selectedTrack;
            tbName.Text = selectedTrack.Name;
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            _selectedTrack.Name = tbName.Text;
        }
    }
}
