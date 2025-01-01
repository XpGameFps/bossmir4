namespace Mir4Bot
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
            startButton = new Button();
            stopButton = new Button();
            logTextBox = new TextBox();
            windowComboBox = new ComboBox();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Location = new Point(14, 14);
            startButton.Margin = new Padding(4, 3, 4, 3);
            startButton.Name = "startButton";
            startButton.Size = new Size(88, 27);
            startButton.TabIndex = 0;
            startButton.Text = "Iniciar";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(14, 47);
            stopButton.Margin = new Padding(4, 3, 4, 3);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(88, 27);
            stopButton.TabIndex = 1;
            stopButton.Text = "Parar";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // logTextBox
            // 
            logTextBox.Location = new Point(14, 122);
            logTextBox.Margin = new Padding(4, 3, 4, 3);
            logTextBox.Multiline = true;
            logTextBox.Name = "logTextBox";
            logTextBox.ReadOnly = true;
            logTextBox.ScrollBars = ScrollBars.Vertical;
            logTextBox.Size = new Size(468, 239);
            logTextBox.TabIndex = 2;
            // 
            // windowComboBox
            // 
            windowComboBox.FormattingEnabled = true;
            windowComboBox.Location = new Point(110, 34);
            windowComboBox.Margin = new Padding(4, 3, 4, 3);
            windowComboBox.Name = "windowComboBox";
            windowComboBox.Size = new Size(114, 23);
            windowComboBox.TabIndex = 3;
            windowComboBox.SelectedIndexChanged += windowComboBox_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 375);
            Controls.Add(windowComboBox);
            Controls.Add(logTextBox);
            Controls.Add(stopButton);
            Controls.Add(startButton);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mir4 Bot";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.ComboBox windowComboBox;
    }
}
