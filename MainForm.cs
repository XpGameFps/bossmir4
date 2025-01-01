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
        private string selectedWindow;
        private readonly (int x, int y)[] bossCoordinates = new (int x, int y)[]
        {
            (1579, 498), (1597, 574), (1606, 650), (1603, 726), (1617, 785)
        };
        private readonly (int x, int y) teleportCoordinate = (1548, 971);
        private Random random = new Random();
        private bool isBPressed = false;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private const int KEYEVENTF_KEYUP = 0x0002;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;

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
            selectedWindow = windowComboBox.SelectedItem.ToString();
        }

        private void windowComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedWindow = windowComboBox.SelectedItem.ToString();
            Log($"Janela selecionada: {selectedWindow}");
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
                Log("O script j� est� em execu��o.");
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
                Log("Janela do jogo n�o encontrada!");
                return;
            }

            await Task.Delay(100); // 100ms de espera

            if (!isBPressed)
            {
                PressionarTecla("B");
                Log("Tecla 'B' pressionada para iniciar o combate.");
                isBPressed = true;
            }

            int bossIndex = 0;

            while (!token.IsCancellationRequested)
            {
                await EsperaAleatoria(1000, 3000); // Espera aleat�ria entre 20 e 30 segundos

                if (token.IsCancellationRequested) break;

                SimularMovimentoAleatorio(); // Movimentos aleat�rios antes de apertar F10
                await Task.Delay(2000); // Pequena pausa ap�s o movimento

                ClicarTecla("F10");
                Log("Tecla 'F10' clicada para abrir a interface de combate.");

                // Coordenada aleat�ria para o boss
                var bossCoordinate = GetRandomizedCoordinateForBoss(bossCoordinates[bossIndex].x, bossCoordinates[bossIndex].y);
                MoveMouse(bossCoordinate.x, bossCoordinate.y);
                await Task.Delay(500); // Aguarda 500ms antes de clicar
                ClickMouse(); // Clique com o bot�o esquerdo do mouse
                Log($"Clicou no Boss {bossIndex + 1} na coordenada aleat�ria ({bossCoordinate.x}, {bossCoordinate.y}).");

                if (token.IsCancellationRequested) break;

                await Task.Delay(5000); // Espera ap�s clicar no boss

                // Atraso aleat�rio entre 3 a 5 segundos antes de clicar na coordenada de teletransporte
                await EsperaAleatoria(3000, 5000);

                // Coordenada aleat�ria para o teletransporte
                var teleportCoord = GetRandomizedCoordinateForTeleport(teleportCoordinate.x, teleportCoordinate.y);
                MoveMouse(teleportCoord.x, teleportCoord.y); // Movendo o mouse para as coordenadas de teletransporte aleat�rias
                await Task.Delay(500); // Aguarda 500ms antes de clicar
                ClickMouse(); // Clique com o bot�o esquerdo do mouse
                Log("Clicou na coordenada de teleport.");

                if (token.IsCancellationRequested) break;

                await Task.Delay(5000); // Espera ap�s teleportar

                PressionarTecla("B"); // Pressionar a tecla 'B' ap�s o combate
                bossIndex = (bossIndex + 1) % bossCoordinates.Length;
            }
        }

        private void SimularMovimentoAleatorio()
        {
            string[] teclasMovimento = { "W", "A", "S", "D" };
            int movimentos = random.Next(1, 4);

            for (int i = 0; i < movimentos; i++)
            {
                string tecla = teclasMovimento[random.Next(teclasMovimento.Length)];
                PressionarTecla(tecla, true);
                Thread.Sleep(random.Next(500, 1500));
                keybd_event(GetVirtualKey(tecla), 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Log($"Tecla '{tecla.ToUpper()}' solta.");
            }
        }

        private void PressionarTecla(string tecla, bool manterPressionada = false)
        {
            int esperaAntes = random.Next(80, 200);
            Thread.Sleep(esperaAntes);

            byte virtualKey = GetVirtualKey(tecla);
            if (virtualKey != 0)
            {
                if (manterPressionada)
                {
                    keybd_event(virtualKey, 0, 0, UIntPtr.Zero);
                    Log($"Tecla '{tecla.ToUpper()}' pressionada.");
                }
                else
                {
                    keybd_event(virtualKey, 0, 0, UIntPtr.Zero);
                    Log($"Tecla '{tecla.ToUpper()}' clicada.");
                    Thread.Sleep(50);
                    keybd_event(virtualKey, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                    Log($"Tecla '{tecla.ToUpper()}' solta.");
                }
            }
            else
            {
                Log($"Tecla '{tecla}' n�o reconhecida.");
            }
        }

        private void ClicarTecla(string tecla)
        {
            byte virtualKey = GetVirtualKey(tecla);
            if (virtualKey != 0)
            {
                keybd_event(virtualKey, 0, 0, UIntPtr.Zero);
                Log($"Tecla '{tecla.ToUpper()}' clicada.");
                keybd_event(virtualKey, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Log($"Tecla '{tecla.ToUpper()}' solta.");
            }
            else
            {
                Log($"Tecla '{tecla}' n�o reconhecida.");
            }
        }

        private byte GetVirtualKey(string tecla)
        {
            return tecla.ToUpper() switch
            {
                "W" => 0x57,
                "A" => 0x41,
                "S" => 0x53,
                "D" => 0x44,
                "B" => 0x42,
                "F10" => 0x79,
                _ => 0,
            };
        }

        private bool BringGameWindowToFront()
        {
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.MainWindowTitle.Equals(selectedWindow))
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
            Log($"Mouse movido para a coordenada ({x}, {y}).");
        }

        private void ClickMouse()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero); // Pressiona o bot�o esquerdo do mouse
            Thread.Sleep(random.Next(100, 150)); // Aguarda um pequeno intervalo
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero); // Solta o bot�o esquerdo do mouse
            Log("Clique do mouse realizado.");
        }

        private (int x, int y) GetRandomizedCoordinateForBoss(int x, int y)
        {
            // Ajusta para a resolu��o da tela
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            int offsetX = random.Next(-160, 195); // Para bosses
            int offsetY = random.Next(-18, 18); // Para bosses

            // Ajusta a coordenada baseada na resolu��o da tela
            int scaledX = (int)(x + offsetX * (float)screenWidth / 1920);
            int scaledY = (int)(y + offsetY * (float)screenHeight / 1080);

            return (scaledX, scaledY);
        }

        private (int x, int y) GetRandomizedCoordinateForTeleport(int x, int y)
        {
            // Ajusta para a resolu��o da tela
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            int offsetX = random.Next(-105, 105); // Para teletransporte
            int offsetY = random.Next(-20, 20); // Para teletransporte

            // Ajusta a coordenada baseada na resolu��o da tela
            int scaledX = (int)(x + offsetX * (float)screenWidth / 1920);
            int scaledY = (int)(y + offsetY * (float)screenHeight / 1080);

            return (scaledX, scaledY);
        }

        private async Task EsperaAleatoria(int min, int max)
        {
            int delay = random.Next(min, max);
            await Task.Delay(delay);
        }

        private void Log(string message)
        {
            if (logTextBox.InvokeRequired)
            {
                logTextBox.Invoke(new Action<string>(Log), message);
            }
            else
            {
                logTextBox.AppendText($"{DateTime.Now:dd/MM/yyyy HH:mm:ss}: {message}{Environment.NewLine}");
                logTextBox.SelectionStart = logTextBox.Text.Length; // Rola para o final
                logTextBox.ScrollToCaret();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }

        private void mapComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}