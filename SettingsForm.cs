using System;
using System.Windows.Forms;

namespace Mir4Bot
{
    public partial class SettingsForm : Form
    {
        public int PostBossDelaySeconds
        {
            get { return (int)postBossDelayNumericUpDown.Value; }
            set { postBossDelayNumericUpDown.Value = value; }
        }

        public int PostTeleportDelaySeconds
        {
            get { return (int)postTeleportDelayNumericUpDown.Value; }
            set { postTeleportDelayNumericUpDown.Value = value; }
        }

        public int TempoEsperaAposBSeconds
        {
            get { return (int)tempoEsperaAposBNumericUpDown.Value; }
            set { tempoEsperaAposBNumericUpDown.Value = value; }
        }

        public int DelayMapLoad
        {
            get { return (int)numericUpDownDelayMapLoad.Value; }
            set { numericUpDownDelayMapLoad.Value = value; }
        }

        public SettingsForm()
        {
            InitializeComponent();
            // Defina valores padrão para os delays
            PostBossDelaySeconds = 1;
            PostTeleportDelaySeconds = 5;
            TempoEsperaAposBSeconds = 5;
            DelayMapLoad = 8;

            // Inicialize os valores dos campos
            postBossDelayNumericUpDown.Value = PostBossDelaySeconds;
            postTeleportDelayNumericUpDown.Value = PostTeleportDelaySeconds;
            tempoEsperaAposBNumericUpDown.Value = TempoEsperaAposBSeconds;
            numericUpDownDelayMapLoad.Value = DelayMapLoad;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Atualize os valores das propriedades
            PostBossDelaySeconds = (int)postBossDelayNumericUpDown.Value;
            PostTeleportDelaySeconds = (int)postTeleportDelayNumericUpDown.Value;
            TempoEsperaAposBSeconds = (int)tempoEsperaAposBNumericUpDown.Value;
            DelayMapLoad = (int)numericUpDownDelayMapLoad.Value;

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

        private void minDelayLabel_Click(object sender, EventArgs e)
        {

        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            // Atualize os valores das propriedades
            DelayMapLoad = (int)numericUpDownDelayMapLoad.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void labelDelayMapLoad_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDownDelayMapLoad_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
