using System;
using System.Windows.Forms;

namespace Mir4Bot
{
    public partial class SettingsForm : Form
    {
        public int MinDelayMilliseconds
        {
            get { return (int)minDelayNumericUpDown.Value; }
            set { minDelayNumericUpDown.Value = value; }
        }

        public int MaxDelayMilliseconds
        {
            get { return (int)maxDelayNumericUpDown.Value; }
            set { maxDelayNumericUpDown.Value = value; }
        }
        public int PostBossDelayMilliseconds
        {
            get { return (int)postBossDelayNumericUpDown.Value; }
            set { postBossDelayNumericUpDown.Value = value; }
        }
        public int TeleportMinDelayMilliseconds
        {
            get { return (int)teleportMinDelayNumericUpDown.Value; }
            set { teleportMinDelayNumericUpDown.Value = value; }
        }

        public int TeleportMaxDelayMilliseconds
        {
            get { return (int)teleportMaxDelayNumericUpDown.Value; }
            set { teleportMaxDelayNumericUpDown.Value = value; }
        }
        public int PostTeleportDelayMilliseconds
        {
            get { return (int)postTeleportDelayNumericUpDown.Value; }
            set { postTeleportDelayNumericUpDown.Value = value; }
        }


        public SettingsForm()
        {
            InitializeComponent();

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void maxDelayNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void maxDelayLabel_Click(object sender, EventArgs e)
        {

        }

        private void postBossDelayNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void teleportMinDelayLabel_Click(object sender, EventArgs e)
        {

        }

        private void postTeleportDelayLabel_Click(object sender, EventArgs e)
        {

        }

        private void postBossDelayLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
