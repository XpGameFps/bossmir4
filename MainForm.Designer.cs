namespace Mir4Bot
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.ComboBox windowComboBox;
        private System.Windows.Forms.Button donationButton;
        private System.Windows.Forms.ComboBox mapComboBox;
        private System.Windows.Forms.RichTextBox txtNoticias; // Novo controle para notícias

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
            settingsButton = new Button();
            startButton = new Button();
            stopButton = new Button();
            logTextBox = new TextBox();
            windowComboBox = new ComboBox();
            donationButton = new Button();
            mapComboBox = new ComboBox();
            txtNoticias = new RichTextBox();
            SuspendLayout();
            // 
            // settingsButton
            // 
            settingsButton.Location = new Point(384, 14);
            settingsButton.Margin = new Padding(4, 3, 4, 3);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(98, 27);
            settingsButton.TabIndex = 4;
            settingsButton.Text = "Configurações";
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += settingsButton_Click;
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
            // donationButton
            // 
            donationButton.BackColor = Color.Purple;
            donationButton.ForeColor = Color.White;
            donationButton.Location = new Point(322, 76);
            donationButton.Margin = new Padding(4, 3, 4, 3);
            donationButton.Name = "donationButton";
            donationButton.Size = new Size(160, 40);
            donationButton.TabIndex = 5;
            donationButton.Text = "Doação";
            donationButton.UseVisualStyleBackColor = false;
            donationButton.Click += donationButton_Click;
            // 
            // mapComboBox
            // 
            mapComboBox.FormattingEnabled = true;
            mapComboBox.Location = new Point(110, 60);
            mapComboBox.Name = "mapComboBox";
            mapComboBox.Size = new Size(114, 23);
            mapComboBox.TabIndex = 6;
            mapComboBox.SelectedIndexChanged += mapComboBox_SelectedIndexChanged;
            // 
            // txtNoticias
            // 
            txtNoticias.Location = new Point(14, 367);
            txtNoticias.Margin = new Padding(4, 3, 4, 3);
            txtNoticias.Name = "txtNoticias";
            txtNoticias.ReadOnly = true;
            txtNoticias.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtNoticias.Size = new Size(468, 100);
            txtNoticias.TabIndex = 7;
            txtNoticias.Text = "";
            txtNoticias.TextChanged += txtNoticias_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 454);
            Controls.Add(txtNoticias);
            Controls.Add(mapComboBox);
            Controls.Add(settingsButton);
            Controls.Add(windowComboBox);
            Controls.Add(logTextBox);
            Controls.Add(stopButton);
            Controls.Add(startButton);
            Controls.Add(donationButton);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mir4 Bot";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void donationButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://nubank.com.br/cobrar/12h52y/677c3495-7226-4c16-96d5-a8d9ad033952",
                UseShellExecute = true
            });
        }
    }
}