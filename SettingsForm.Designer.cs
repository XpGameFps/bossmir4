namespace Mir4Bot
{
    partial class SettingsForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown postBossDelayNumericUpDown;
        private System.Windows.Forms.Label postBossDelayLabel;
        private System.Windows.Forms.NumericUpDown postTeleportDelayNumericUpDown;
        private System.Windows.Forms.Label postTeleportDelayLabel;
        private System.Windows.Forms.NumericUpDown numericUpDownDelayMapLoad;
        private System.Windows.Forms.Label labelDelayMapLoad;
        private System.Windows.Forms.NumericUpDown tempoEsperaAposBNumericUpDown;
        private System.Windows.Forms.Label tempoEsperaAposBLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;

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
            postBossDelayNumericUpDown = new NumericUpDown();
            postTeleportDelayNumericUpDown = new NumericUpDown();
            okButton = new Button();
            cancelButton = new Button();
            postBossDelayLabel = new Label();
            postTeleportDelayLabel = new Label();
            numericUpDownDelayMapLoad = new NumericUpDown();
            labelDelayMapLoad = new Label();
            tempoEsperaAposBNumericUpDown = new NumericUpDown();
            tempoEsperaAposBLabel = new Label();
            tableLayoutPanel = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)postBossDelayNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)postTeleportDelayNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDelayMapLoad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tempoEsperaAposBNumericUpDown).BeginInit();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // postBossDelayNumericUpDown
            // 
            postBossDelayNumericUpDown.Dock = DockStyle.Fill;
            postBossDelayNumericUpDown.Location = new Point(203, 3);
            postBossDelayNumericUpDown.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            postBossDelayNumericUpDown.Name = "postBossDelayNumericUpDown";
            postBossDelayNumericUpDown.Size = new Size(194, 23);
            postBossDelayNumericUpDown.TabIndex = 2;
            postBossDelayNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // postTeleportDelayNumericUpDown
            // 
            postTeleportDelayNumericUpDown.Dock = DockStyle.Fill;
            postTeleportDelayNumericUpDown.Location = new Point(203, 43);
            postTeleportDelayNumericUpDown.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            postTeleportDelayNumericUpDown.Name = "postTeleportDelayNumericUpDown";
            postTeleportDelayNumericUpDown.Size = new Size(194, 23);
            postTeleportDelayNumericUpDown.TabIndex = 7;
            postTeleportDelayNumericUpDown.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // okButton
            // 
            okButton.Dock = DockStyle.Fill;
            okButton.Location = new Point(3, 163);
            okButton.Name = "okButton";
            okButton.Size = new Size(194, 34);
            okButton.TabIndex = 2;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Dock = DockStyle.Fill;
            cancelButton.Location = new Point(203, 163);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(194, 34);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancelar";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // postBossDelayLabel
            // 
            postBossDelayLabel.Dock = DockStyle.Fill;
            postBossDelayLabel.Location = new Point(3, 0);
            postBossDelayLabel.Name = "postBossDelayLabel";
            postBossDelayLabel.Size = new Size(194, 40);
            postBossDelayLabel.TabIndex = 2;
            postBossDelayLabel.Text = "Delay Entre Boss e teletransporte (s):";
            // 
            // postTeleportDelayLabel
            // 
            postTeleportDelayLabel.Dock = DockStyle.Fill;
            postTeleportDelayLabel.Location = new Point(3, 40);
            postTeleportDelayLabel.Name = "postTeleportDelayLabel";
            postTeleportDelayLabel.Size = new Size(194, 40);
            postTeleportDelayLabel.TabIndex = 7;
            postTeleportDelayLabel.Text = "Delay Pós-Teleport (s):";
            // 
            // numericUpDownDelayMapLoad
            // 
            numericUpDownDelayMapLoad.Dock = DockStyle.Fill;
            numericUpDownDelayMapLoad.Location = new Point(203, 123);
            numericUpDownDelayMapLoad.Maximum = new decimal(new int[] { 20000, 0, 0, 0 });
            numericUpDownDelayMapLoad.Name = "numericUpDownDelayMapLoad";
            numericUpDownDelayMapLoad.Size = new Size(194, 23);
            numericUpDownDelayMapLoad.TabIndex = 10;
            numericUpDownDelayMapLoad.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // labelDelayMapLoad
            // 
            labelDelayMapLoad.AutoSize = true;
            labelDelayMapLoad.Dock = DockStyle.Fill;
            labelDelayMapLoad.Location = new Point(3, 120);
            labelDelayMapLoad.Name = "labelDelayMapLoad";
            labelDelayMapLoad.Size = new Size(194, 40);
            labelDelayMapLoad.TabIndex = 11;
            labelDelayMapLoad.Text = "Delay para o mapa carregar (s):";
            // 
            // tempoEsperaAposBNumericUpDown
            // 
            tempoEsperaAposBNumericUpDown.Dock = DockStyle.Fill;
            tempoEsperaAposBNumericUpDown.Location = new Point(203, 83);
            tempoEsperaAposBNumericUpDown.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            tempoEsperaAposBNumericUpDown.Name = "tempoEsperaAposBNumericUpDown";
            tempoEsperaAposBNumericUpDown.Size = new Size(194, 23);
            tempoEsperaAposBNumericUpDown.TabIndex = 12;
            tempoEsperaAposBNumericUpDown.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // tempoEsperaAposBLabel
            // 
            tempoEsperaAposBLabel.Dock = DockStyle.Fill;
            tempoEsperaAposBLabel.Location = new Point(3, 80);
            tempoEsperaAposBLabel.Name = "tempoEsperaAposBLabel";
            tempoEsperaAposBLabel.Size = new Size(194, 40);
            tempoEsperaAposBLabel.TabIndex = 13;
            tempoEsperaAposBLabel.Text = "Tempo de Espera após 'B' (s):";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Controls.Add(postBossDelayLabel, 0, 0);
            tableLayoutPanel.Controls.Add(postBossDelayNumericUpDown, 1, 0);
            tableLayoutPanel.Controls.Add(postTeleportDelayLabel, 0, 1);
            tableLayoutPanel.Controls.Add(postTeleportDelayNumericUpDown, 1, 1);
            tableLayoutPanel.Controls.Add(tempoEsperaAposBLabel, 0, 2);
            tableLayoutPanel.Controls.Add(tempoEsperaAposBNumericUpDown, 1, 2);
            tableLayoutPanel.Controls.Add(labelDelayMapLoad, 0, 3);
            tableLayoutPanel.Controls.Add(numericUpDownDelayMapLoad, 1, 3);
            tableLayoutPanel.Controls.Add(okButton, 0, 4);
            tableLayoutPanel.Controls.Add(cancelButton, 1, 4);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel.Size = new Size(400, 200);
            tableLayoutPanel.TabIndex = 0;
            // 
            // SettingsForm
            // 
            ClientSize = new Size(400, 200);
            Controls.Add(tableLayoutPanel);
            Name = "SettingsForm";
            Text = "Configurações";
            ((System.ComponentModel.ISupportInitialize)postBossDelayNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)postTeleportDelayNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDelayMapLoad).EndInit();
            ((System.ComponentModel.ISupportInitialize)tempoEsperaAposBNumericUpDown).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}