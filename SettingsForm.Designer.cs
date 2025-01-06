namespace Mir4Bot
{
    partial class SettingsForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.NumericUpDown minDelayNumericUpDown;
        private System.Windows.Forms.NumericUpDown maxDelayNumericUpDown;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label minDelayLabel;
        private System.Windows.Forms.Label maxDelayLabel;
        private System.Windows.Forms.NumericUpDown postBossDelayNumericUpDown;
        private System.Windows.Forms.Label postBossDelayLabel;
        private System.Windows.Forms.NumericUpDown teleportMinDelayNumericUpDown;
        private System.Windows.Forms.NumericUpDown teleportMaxDelayNumericUpDown;
        private System.Windows.Forms.Label teleportMinDelayLabel;
        private System.Windows.Forms.Label teleportMaxDelayLabel;
        private System.Windows.Forms.NumericUpDown postTeleportDelayNumericUpDown;
        private System.Windows.Forms.Label postTeleportDelayLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            minDelayNumericUpDown = new NumericUpDown();
            maxDelayNumericUpDown = new NumericUpDown();
            postBossDelayNumericUpDown = new NumericUpDown();
            teleportMinDelayNumericUpDown = new NumericUpDown();
            teleportMaxDelayNumericUpDown = new NumericUpDown();
            postTeleportDelayNumericUpDown = new NumericUpDown();
            okButton = new Button();
            cancelButton = new Button();
            minDelayLabel = new Label();
            maxDelayLabel = new Label();
            postBossDelayLabel = new Label();
            teleportMinDelayLabel = new Label();
            teleportMaxDelayLabel = new Label();
            postTeleportDelayLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)minDelayNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxDelayNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)postBossDelayNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teleportMinDelayNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teleportMaxDelayNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)postTeleportDelayNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // minDelayNumericUpDown
            // 
            minDelayNumericUpDown.Location = new Point(20, 40);
            minDelayNumericUpDown.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            minDelayNumericUpDown.Name = "minDelayNumericUpDown";
            minDelayNumericUpDown.Size = new Size(140, 23);
            minDelayNumericUpDown.TabIndex = 0;
            minDelayNumericUpDown.Value = new decimal(new int[] { 3000, 0, 0, 0 });
            // 
            // maxDelayNumericUpDown
            // 
            maxDelayNumericUpDown.Location = new Point(20, 100);
            maxDelayNumericUpDown.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            maxDelayNumericUpDown.Name = "maxDelayNumericUpDown";
            maxDelayNumericUpDown.Size = new Size(140, 23);
            maxDelayNumericUpDown.TabIndex = 1;
            maxDelayNumericUpDown.Value = new decimal(new int[] { 6000, 0, 0, 0 });
            maxDelayNumericUpDown.ValueChanged += maxDelayNumericUpDown_ValueChanged;
            // 
            // postBossDelayNumericUpDown
            // 
            postBossDelayNumericUpDown.Location = new Point(350, 100);
            postBossDelayNumericUpDown.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            postBossDelayNumericUpDown.Name = "postBossDelayNumericUpDown";
            postBossDelayNumericUpDown.Size = new Size(140, 23);
            postBossDelayNumericUpDown.TabIndex = 2;
            postBossDelayNumericUpDown.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            postBossDelayNumericUpDown.ValueChanged += postBossDelayNumericUpDown_ValueChanged;
            // 
            // teleportMinDelayNumericUpDown
            // 
            teleportMinDelayNumericUpDown.Location = new Point(20, 160);
            teleportMinDelayNumericUpDown.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            teleportMinDelayNumericUpDown.Name = "teleportMinDelayNumericUpDown";
            teleportMinDelayNumericUpDown.Size = new Size(140, 23);
            teleportMinDelayNumericUpDown.TabIndex = 5;
            teleportMinDelayNumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // teleportMaxDelayNumericUpDown
            // 
            teleportMaxDelayNumericUpDown.Location = new Point(20, 220);
            teleportMaxDelayNumericUpDown.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            teleportMaxDelayNumericUpDown.Name = "teleportMaxDelayNumericUpDown";
            teleportMaxDelayNumericUpDown.Size = new Size(140, 23);
            teleportMaxDelayNumericUpDown.TabIndex = 6;
            teleportMaxDelayNumericUpDown.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // postTeleportDelayNumericUpDown
            // 
            postTeleportDelayNumericUpDown.Location = new Point(350, 220);
            postTeleportDelayNumericUpDown.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            postTeleportDelayNumericUpDown.Name = "postTeleportDelayNumericUpDown";
            postTeleportDelayNumericUpDown.Size = new Size(140, 23);
            postTeleportDelayNumericUpDown.TabIndex = 7;
            postTeleportDelayNumericUpDown.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // okButton
            // 
            okButton.Location = new Point(180, 300);
            okButton.Name = "okButton";
            okButton.Size = new Size(90, 30);
            okButton.TabIndex = 2;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(300, 300);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(90, 30);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancelar";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // minDelayLabel
            // 
            minDelayLabel.Location = new Point(20, 20);
            minDelayLabel.Name = "minDelayLabel";
            minDelayLabel.Size = new Size(200, 16);
            minDelayLabel.TabIndex = 0;
            minDelayLabel.Text = "Delay Mínimo para atacar (ms):";
            // 
            // maxDelayLabel
            // 
            maxDelayLabel.Location = new Point(20, 80);
            maxDelayLabel.Name = "maxDelayLabel";
            maxDelayLabel.Size = new Size(200, 16);
            maxDelayLabel.TabIndex = 1;
            maxDelayLabel.Text = "Delay Máximo para atacar (ms):";
            maxDelayLabel.Click += maxDelayLabel_Click;
            // 
            // postBossDelayLabel
            // 
            postBossDelayLabel.Location = new Point(320, 80);
            postBossDelayLabel.Name = "postBossDelayLabel";
            postBossDelayLabel.Size = new Size(250, 16);
            postBossDelayLabel.TabIndex = 2;
            postBossDelayLabel.Text = "Delay Entre Boss e teletransporte (ms):";
            postBossDelayLabel.Click += postBossDelayLabel_Click;
            // 
            // teleportMinDelayLabel
            // 
            teleportMinDelayLabel.Location = new Point(20, 140);
            teleportMinDelayLabel.Name = "teleportMinDelayLabel";
            teleportMinDelayLabel.Size = new Size(200, 16);
            teleportMinDelayLabel.TabIndex = 0;
            teleportMinDelayLabel.Text = "Delay Mín. Teleport (ms):";
            // 
            // teleportMaxDelayLabel
            // 
            teleportMaxDelayLabel.Location = new Point(20, 200);
            teleportMaxDelayLabel.Name = "teleportMaxDelayLabel";
            teleportMaxDelayLabel.Size = new Size(200, 16);
            teleportMaxDelayLabel.TabIndex = 6;
            teleportMaxDelayLabel.Text = "Delay Máx. Teleport (ms):";
            // 
            // postTeleportDelayLabel
            // 
            postTeleportDelayLabel.Location = new Point(350, 200);
            postTeleportDelayLabel.Name = "postTeleportDelayLabel";
            postTeleportDelayLabel.Size = new Size(200, 16);
            postTeleportDelayLabel.TabIndex = 7;
            postTeleportDelayLabel.Text = "Delay Pós-Teleport (ms):";
            postTeleportDelayLabel.Click += postTeleportDelayLabel_Click;
            // 
            // SettingsForm
            // 
            ClientSize = new Size(529, 337);
            Controls.Add(teleportMinDelayLabel);
            Controls.Add(teleportMinDelayNumericUpDown);
            Controls.Add(teleportMaxDelayLabel);
            Controls.Add(teleportMaxDelayNumericUpDown);
            Controls.Add(minDelayLabel);
            Controls.Add(minDelayNumericUpDown);
            Controls.Add(maxDelayLabel);
            Controls.Add(maxDelayNumericUpDown);
            Controls.Add(postBossDelayLabel);
            Controls.Add(postBossDelayNumericUpDown);
            Controls.Add(postTeleportDelayLabel);
            Controls.Add(postTeleportDelayNumericUpDown);
            Controls.Add(okButton);
            Controls.Add(cancelButton);
            Name = "SettingsForm";
            Text = "Configurações";
            ((System.ComponentModel.ISupportInitialize)minDelayNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxDelayNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)postBossDelayNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)teleportMinDelayNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)teleportMaxDelayNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)postTeleportDelayNumericUpDown).EndInit();
            ResumeLayout(false);
        }
    }
}
