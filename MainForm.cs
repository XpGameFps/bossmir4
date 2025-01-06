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
        //
        // delays padrão
        //
        private int delayMilliseconds = 1000; // Delay padrão de 1 segundo

        //
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
            // Define o ícone da janela (barra de título)
            this.Icon = new Icon("C:\\bossmir4\\img\\icon.ico");
            PopulateWindowList();
            this.FormClosing += MainForm_FormClosing;

        }


        private void PopulateWindowList()
        {
            windowComboBox.Items.Add("Mir4G[0]");
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
            if (cancellationTokenSource == null) // Só inicia se não estiver em execução
            {
                // Tenta trazer a janela para frente
                if (!BringGameWindowToFront())
                {
                    Log("Janela do jogo não encontrada!");
                    return;
                }

                cancellationTokenSource = new CancellationTokenSource();
                isBPressed = false; // Resetando isBPressed para garantir que a tecla 'B' será pressionada novamente
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
            cancellationTokenSource = null; // Redefinir para null após parar o script
            Log("Script parado!");
        }

        private async Task BotLoop(CancellationToken token)
        {
            if (!BringGameWindowToFront())
            {
                Log("Janela do jogo n�o encontrada!");
                return;
            }

            if (!isBPressed)
            {
                PressionarTecla("B");
                Log("Tecla 'B' pressionada para iniciar o combate.");
                isBPressed = true;
            }

            await Task.Delay(100, token); // 100ms de espera

            int bossIndex = 0;

            while (!token.IsCancellationRequested)
            {
                await EsperaAleatoria(minDelayMilliseconds, maxDelayMilliseconds);

                if (token.IsCancellationRequested) break;

                SimularMovimentoAleatorio(token); // Movimentos aleat�rios antes de apertar F10
                await Task.Delay(2000, token); // Pequena pausa ap�s o movimento

                ClicarTecla("F10");
                Log("Tecla 'F10' clicada para abrir a interface de combate.");

                // Coordenada aleat�ria para o boss
                var bossCoordinate = GetRandomizedCoordinateForBoss(bossCoordinates[bossIndex].x, bossCoordinates[bossIndex].y);
                MoveMouse(bossCoordinate.x, bossCoordinate.y);
                await Task.Delay(500, token); // Aguarda 500ms antes de clicar
                ClickMouse(); // Clique com o bot�o esquerdo do mouse
                Log($"Clicou no Boss {bossIndex + 1} na coordenada aleat�ria ({bossCoordinate.x}, {bossCoordinate.y}).");

                if (token.IsCancellationRequested) break;

                await Task.Delay(postBossDelayMilliseconds, token); // Usa o delay configurado após clicar no boss

                // Atraso aleat�rio entre 3 a 5 segundos antes de clicar na coordenada de teletransporte
                await EsperaAleatoria(teleportMinDelayMilliseconds, teleportMaxDelayMilliseconds); // Usa o delay configurado antes do teletransporte

                // Coordenada aleat�ria para o teletransporte
                var teleportCoord = GetRandomizedCoordinateForTeleport(teleportCoordinate.x, teleportCoordinate.y);
                MoveMouse(teleportCoord.x, teleportCoord.y); // Movendo o mouse para as coordenadas de teletransporte aleat�rias
                await Task.Delay(500, token); // Aguarda 500ms antes de clicar
                ClickMouse(); // Clique com o bot�o esquerdo do mouse
                Log("Clicou na coordenada de teleport.");

                if (token.IsCancellationRequested) break;

                await Task.Delay(postTeleportDelayMilliseconds, token); // Usa o delay configurado após o teletransporte

                PressionarTecla("B"); // Pressionar a tecla 'B' ap�s o combate
                bossIndex = (bossIndex + 1) % bossCoordinates.Length;
            }
        }

        private void SimularMovimentoAleatorio(CancellationToken token)
        {
            string[] teclasMovimento = { "W", "A", "S", "D" };
            int movimentos = random.Next(1, 4);

            for (int i = 0; i < movimentos; i++)
            {
                if (token.IsCancellationRequested) return; // Verifica se a execução foi cancelada

                string tecla = teclasMovimento[random.Next(teclasMovimento.Length)];
                PressionarTecla(tecla, true);

                int delay = random.Next(500, 1500);
                int elapsed = 0;

                // Aguarda o tempo configurado para manter a tecla pressionada,
                // verificando constantemente se o token foi cancelado
                while (elapsed < delay)
                {
                    if (token.IsCancellationRequested)
                    {
                        keybd_event(GetVirtualKey(tecla), 0, KEYEVENTF_KEYUP, UIntPtr.Zero); // Solta a tecla se cancelado
                        Log($"Tecla '{tecla.ToUpper()}' solta devido ao cancelamento.");
                        return;
                    }

                    Thread.Sleep(100); // Intervalos curtos para verificar o token
                    elapsed += 100;
                }

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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        //
        //Inicio da configuração
        //
        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.MinDelayMilliseconds = minDelayMilliseconds;
            settingsForm.MaxDelayMilliseconds = maxDelayMilliseconds;
            settingsForm.PostBossDelayMilliseconds = postBossDelayMilliseconds;
            settingsForm.TeleportMinDelayMilliseconds = teleportMinDelayMilliseconds;
            settingsForm.TeleportMaxDelayMilliseconds = teleportMaxDelayMilliseconds;
            settingsForm.PostTeleportDelayMilliseconds = postTeleportDelayMilliseconds;
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                minDelayMilliseconds = settingsForm.MinDelayMilliseconds;
                maxDelayMilliseconds = settingsForm.MaxDelayMilliseconds;
                postBossDelayMilliseconds = settingsForm.PostBossDelayMilliseconds;
                teleportMinDelayMilliseconds = settingsForm.TeleportMinDelayMilliseconds;
                teleportMaxDelayMilliseconds = settingsForm.TeleportMaxDelayMilliseconds;
                postTeleportDelayMilliseconds = settingsForm.PostTeleportDelayMilliseconds;
            }
        }

        // tempo que o bot vai fica atacando antes abre o mapa
        private int minDelayMilliseconds = 3000; // Default 3 seconds
        private int maxDelayMilliseconds = 6000; // Default 6 seconds

        // tempo em conjunto pra evita identificação ao click no boss list 
        private int postBossDelayMilliseconds = 1000; // Default 1 seconds

        // tempo pra click nos boss na lista e click em teleporte
        private int teleportMinDelayMilliseconds = 100; // Default 0,1 seconds
        private int teleportMaxDelayMilliseconds = 300; // Default 0,3 seconds

        // tempo de espera para aperta letra B depois de teletransporta  
        private int postTeleportDelayMilliseconds = 5000; // Default 5 seconds

    }
}