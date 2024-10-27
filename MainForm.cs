using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Mir4Bot
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        private string selectedWindow = "Mir4G[1]";
        private readonly (int x, int y)[] bossCoordinates = new (int x, int y)[]
        {
            (1579, 498), (1597, 574), (1606, 650), (1603, 726), (1617, 785)
        };
        private readonly (int x, int y) teleportCoordinate = (1548, 971);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        public MainForm()
        {
            InitializeComponent();
            PopulateWindowList();
            this.FormClosing += MainForm_FormClosing;
        }

        private void PopulateWindowList()
        {
            windowComboBox.Items.Add("Mir4G[1]");
            windowComboBox.Items.Add("Mir4G[2]");
            windowComboBox.SelectedIndex = 0;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource == null)
            {
                cancellationTokenSource = new CancellationTokenSource();
                Task.Run(() => BotLoop(cancellationTokenSource.Token));
                Log("Script iniciado!");
            }
            else
            {
                Log("O script já está em execução.");
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
            Log("Script parado!");
        }

        private async Task BotLoop(CancellationToken token)
        {
            if (!BringGameWindowToFront())
            {
                Log("Janela do jogo não encontrada!");
                return;
            }

            int bossIndex = 0;
            SendKeys.SendWait("b");
            Log("Tecla 'B' pressionada para iniciar o combate.");

            while (!token.IsCancellationRequested)
            {
                await Task.Delay(30000); // Aguardar 30 segundos

                if (token.IsCancellationRequested) break;

                SendKeys.SendWait("{F10}");
                Log("Tecla 'F10' pressionada para abrir a interface de combate.");
                await Task.Delay(2000); // Aguardar a interface abrir

                // Chamada para escalar as coordenadas antes de mover o mouse
                var bossCoordinate = ScaleCoordinates(bossCoordinates[bossIndex].x, bossCoordinates[bossIndex].y);
                MoveMouse(bossCoordinate.x, bossCoordinate.y);
                ClickMouse();
                Log($"Clicou no Boss {bossIndex + 1} na coordenada ({bossCoordinate.x}, {bossCoordinate.y}).");

                if (token.IsCancellationRequested) break;

                await Task.Delay(5000); // Aguardar um tempo após o clique

                // Escalando a coordenada de teleport
                var teleportCoord = ScaleCoordinates(teleportCoordinate.x, teleportCoordinate.y);
                MoveMouse(teleportCoord.x, teleportCoord.y);
                ClickMouse();
                Log("Clicou na coordenada de teleport.");

                if (token.IsCancellationRequested) break;

                await Task.Delay(5000); // Aguardar 5 segundos após o teleport

                SendKeys.SendWait("b");
                Log("Tecla 'B' pressionada após teleportar.");

                bossIndex = (bossIndex + 1) % bossCoordinates.Length; // Passa para o próximo boss
            }
        }

        private bool BringGameWindowToFront()
        {
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.MainWindowTitle.Contains(selectedWindow))
                {
                    SetForegroundWindow(proc.MainWindowHandle);
                    Log($"Janela '{selectedWindow}' trazida para frente.");
                    return true;
                }
            }
            return false;
        }

        private void MoveMouse(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            Thread.Sleep(500);
        }

        private void ClickMouse()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
        }

        private void Log(string message)
        {
            if (logTextBox.InvokeRequired)
            {
                logTextBox.Invoke(new Action<string>(Log), message);
            }
            else
            {
                logTextBox.AppendText($"{DateTime.Now}: {message}{Environment.NewLine}");
                logTextBox.ScrollToCaret();
            }
        }

        // Função para escalar as coordenadas
        private (int x, int y) ScaleCoordinates(int originalX, int originalY)
        {
            // Obtendo o monitor ativo
            var screen = GetActiveScreen();
            float scaleX = (float)screen.Bounds.Width / 1920f;
            float scaleY = (float)screen.Bounds.Height / 1080f;

            int scaledX = (int)(originalX * scaleX);
            int scaledY = (int)(originalY * scaleY);
            return (scaledX, scaledY);
        }

        // Função para obter o monitor ativo
        private Screen GetActiveScreen()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Contains(Cursor.Position))
                {
                    return screen;
                }
            }
            return Screen.PrimaryScreen; // Retorna o monitor principal se não encontrar
        }

        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Finaliza o script suavemente ao fechar o aplicativo
            cancellationTokenSource?.Cancel();
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Token.WaitHandle.WaitOne(1000); // Aguarda até 1 segundo para finalizar
            }
        }

        private void windowComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedWindow = windowComboBox.SelectedItem.ToString();
            Log($"Tela selecionada: {selectedWindow}");
        }
    }
}
