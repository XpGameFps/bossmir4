using System;
using System.Collections.Generic;
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
        private LabirintoMap labirintoMap;
        private Random random = new Random();
        private bool isBPressed = false;
        private string subMapaAtual = "1F";
        private int bossIndex = 1;
        private bool noticiasCarregadas = false;

        // Delays padrão
        private int minDelayMilliseconds = 2000; // 2 segundos por padrão
        private int maxDelayMilliseconds = 4000; // 4 segundos por padrão
        private int postBossDelayMilliseconds = 1000; // 1 segundo por padrão
        private int teleportMinDelayMilliseconds = 100; // 0,1 segundos por padrão
        private int teleportMaxDelayMilliseconds = 300; // 0,3 segundos por padrão
        private int postTeleportDelayMilliseconds = 5000; // 5 segundos por padrão

        // Delays personalizáveis (em milissegundos)
        private int delayAfterSubMapaClick = 1000; // Delay após clicar no submapa
        private int delayAfterBoss1Click = 1000;   // Delay após clicar no Boss 1
        private int delayAfterTeleportClick = 1000; // Delay após clicar no teletransporte
        private int delayMapLoad = 8000;           // Delay de 8 segundos para o mapa carregar

        // Novo delay: tempo de espera após pressionar 'B'
        private int tempoEsperaAposB = 5000; // 5 segundos (ajuste conforme necessário)

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
            this.Icon = new Icon("C:\\bossmir4\\img\\icon.ico");
            PopulateWindowList();
            PopulateMapList();
            this.FormClosing += MainForm_FormClosing;
            this.Load += MainForm_Load; // Adiciona o evento Load
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            if (noticiasCarregadas)
                return; // Impede chamadas duplicadas

            noticiasCarregadas = true;

            try
            {
                // Limpa o RichTextBox antes de adicionar novas notícias
                txtNoticias.Clear();

                string urlNoticias = "https://raw.githubusercontent.com/XpGameFps/bossmir4/main/noticias.json";
                NoticiasService noticiasService = new NoticiasService();

                // Busca as notícias
                List<Noticia> noticias = await noticiasService.BuscarNoticiasAsync(urlNoticias);

                // Exibe as notícias no RichTextBox
                if (noticias != null && noticias.Count > 0)
                {
                    foreach (var noticia in noticias)
                    {
                        txtNoticias.AppendText($"Notícia: {noticia.Titulo}\r\n");
                    }
                }
                else
                {
                    txtNoticias.AppendText("Nenhuma notícia encontrada.\r\n");
                }

                // Ajusta o tamanho do RichTextBox para caber o texto
                AjustarTamanhoTxtNoticias();
            }
            catch (Exception ex)
            {
                // Exibe o erro no RichTextBox
                txtNoticias.AppendText($"Erro ao carregar notícias: {ex.Message}\r\n");
            }
        }

        // Método para formatar a data (opcional)
        private string FormatarData(string data)
        {
            if (DateTime.TryParse(data, out DateTime dataFormatada))
            {
                return dataFormatada.ToString("dd/MM/yyyy"); // Formata a data como "dd/MM/yyyy"
            }
            return data; // Retorna a data original se não for possível formatar
        }

        private void AjustarTamanhoTxtNoticias()
        {
            // Ajusta a altura do RichTextBox para caber o texto
            int numLines = txtNoticias.GetLineFromCharIndex(txtNoticias.TextLength) + 1;
            int border = txtNoticias.Height - txtNoticias.ClientSize.Height;
            int newHeight = txtNoticias.Font.Height * numLines + border + 5; // Adiciona 5 pixels de margem
            txtNoticias.Height = newHeight;
        }

        private void txtNoticias_TextChanged(object sender, EventArgs e)
        {
            AjustarTamanhoTxtNoticias();
        }

        private void PopulateWindowList()
        {
            windowComboBox.Items.Add("Mir4G[0]");
            windowComboBox.Items.Add("Mir4G[1]");
            windowComboBox.Items.Add("Mir4G[2]");
            windowComboBox.SelectedIndex = 0;
            selectedWindow = windowComboBox.SelectedItem.ToString();
        }

        private void PopulateMapList()
        {
            mapComboBox.Items.Add("Labirinto");
            mapComboBox.Items.Add("Outro Mapa");
            mapComboBox.SelectedIndex = 0;
            LoadMap();
        }
        private void windowComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedWindow = windowComboBox.SelectedItem.ToString();
            Log($"Janela selecionada: {selectedWindow}");
        }


        private void LoadMap()
        {
            switch (mapComboBox.SelectedItem.ToString())
            {
                case "Labirinto":
                    labirintoMap = new LabirintoMap();
                    break;
            }
        }

        private void mapComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMap();
        }

        private async Task BotLoop(CancellationToken token)
        {
            // Verifica e traz a janela do jogo para frente
            if (!BringGameWindowToFront())
            {
                Log("Janela do jogo não encontrada!");
                return;
            }

            while (!token.IsCancellationRequested)
            {
                var subMapa = labirintoMap.SubMapas[subMapaAtual];

                // Lógica para matar os bosses do submapa atual
                for (bossIndex = 1; bossIndex < subMapa.BossCoordinates.Count; bossIndex++) // Inicia no Boss 2
                {
                    if (token.IsCancellationRequested) break;

                    // 1. Pressiona 'B' para iniciar o combate (APENAS UMA VEZ)
                    if (!isBPressed)
                    {
                        PressionarTecla("B");
                        Log("Tecla 'B' pressionada para iniciar o combate.");
                        isBPressed = true;
                    }

                    // 2. Espera o tempo para matar o boss
                    Log($"Aguardando {tempoEsperaAposB / 1000} segundos para matar o boss...");
                    await Task.Delay(tempoEsperaAposB, token);

                    // 3. Movimento aleatório com teclas W, A, S, D
                    SimularMovimentoAleatorio(token);

                    // 4. Espera aleatória entre 3 e 6 segundos antes de abrir o mapa
                    int delay = random.Next(minDelayMilliseconds, maxDelayMilliseconds);
                    Log($"Aguardando {delay / 1000} segundos antes de abrir o mapa...");
                    await Task.Delay(delay, token);

                    // 5. Aperta "F10" para abrir a interface de combate
                    ClicarTecla("F10");
                    await Task.Delay(500, token);

                    // 6. Clica no boss atual com randomização
                    var bossCoordinate = GetRandomizedCoordinateForBoss(
                        subMapa.BossCoordinates[bossIndex].x,
                        subMapa.BossCoordinates[bossIndex].y
                    );
                    MoveMouse(bossCoordinate.x, bossCoordinate.y);
                    await Task.Delay(500, token);
                    ClickMouse();
                    Log($"Clicou no Boss {bossIndex + 1} do {subMapaAtual}.");

                    // 7. Espera após atacar o boss
                    Log($"Aguardando {postBossDelayMilliseconds / 1000} segundos após atacar o boss...");
                    await Task.Delay(postBossDelayMilliseconds, token);

                    // 8. Clica no teleporte com randomização
                    var teleportCoord = GetRandomizedCoordinateForTeleport(
                        subMapa.TeleportCoordinate.x,
                        subMapa.TeleportCoordinate.y
                    );
                    MoveMouse(teleportCoord.x, teleportCoord.y);
                    await Task.Delay(500, token);
                    ClickMouse();
                    Log("Teleportou para próximo boss.");

                    // 9. Espera o delay pós-teleporte
                    Log($"Aguardando {postTeleportDelayMilliseconds / 1000} segundos após o teletransporte...");
                    await Task.Delay(postTeleportDelayMilliseconds, token);

                    // Redefine isBPressed para garantir que a tecla 'B' seja pressionada novamente para o próximo boss
                    isBPressed = false;

                    // 10. Pressiona 'B' para iniciar o combate após o teletransporte
                    if (!isBPressed)
                    {
                        PressionarTecla("B");
                        Log("Tecla 'B' pressionada para iniciar o combate.");
                        isBPressed = true;
                    }

                    // 11. Espera o tempo para matar o boss após o teletransporte
                    Log($"Aguardando {tempoEsperaAposB / 1000} segundos para matar o boss...");
                    await Task.Delay(tempoEsperaAposB, token);

                    // 12. Verifica se é o último boss do submapa atual
                    if (bossIndex == subMapa.BossCoordinates.Count - 1)
                    {
                        // 13. Troca de submapa após o último boss
                        AvancarSubMapa();

                        // 14. Abre o mapa pressionando F10
                        ClicarTecla("F10");
                        await Task.Delay(500, token);

                        // 15. Clica na coordenada do novo submapa
                        var subMapaCoord = labirintoMap.SubMapas[subMapaAtual].SubMapaCoordinate;
                        MoveMouse(subMapaCoord.x, subMapaCoord.y);
                        await Task.Delay(500, token);
                        ClickMouse();
                        Log($"Clicou no submapa {subMapaAtual}.");

                        // 16. Delay após clicar no submapa
                        Log($"Aguardando {delayAfterSubMapaClick / 1000} segundos após clicar no submapa...");
                        await Task.Delay(delayAfterSubMapaClick, token);

                        // 17. Vai até o Boss 1 do novo submapa
                        var boss1Coord = labirintoMap.SubMapas[subMapaAtual].BossCoordinates[0];
                        MoveMouse(boss1Coord.x, boss1Coord.y);
                        await Task.Delay(500, token);
                        ClickMouse();
                        Log($"Clicou no Boss 1 do {subMapaAtual}.");

                        // 18. Delay após clicar no Boss 1
                        Log($"Aguardando {delayAfterBoss1Click / 1000} segundos após clicar no Boss 1...");
                        await Task.Delay(delayAfterBoss1Click, token);

                        // 19. Clica no teleporte do novo submapa
                        var teleportCoordNewMap = labirintoMap.SubMapas[subMapaAtual].TeleportCoordinate;
                        MoveMouse(teleportCoordNewMap.x, teleportCoordNewMap.y);
                        await Task.Delay(500, token);
                        ClickMouse();
                        Log("Teleportou para próximo boss.");

                        // 20. Delay após clicar no teletransporte
                        Log($"Aguardando {delayAfterTeleportClick / 1000} segundos após clicar no teletransporte...");
                        await Task.Delay(delayAfterTeleportClick, token);

                        // 21. Delay de 8 segundos para o mapa carregar
                        Log($"Aguardando {delayMapLoad / 1000} segundos para o mapa carregar...");
                        await Task.Delay(delayMapLoad, token);
                        Log("Mapa carregado. Iniciando combate...");

                        // 22. Pressiona 'B' para iniciar o combate no novo submapa (APENAS UMA VEZ)
                        PressionarTecla("B");
                        Log("Tecla 'B' pressionada para iniciar o combate.");
                        isBPressed = true;

                        // 23. Espera o tempo para matar o boss
                        Log($"Aguardando {tempoEsperaAposB / 1000} segundos para matar o boss...");
                        await Task.Delay(tempoEsperaAposB, token);

                        // 24. Reinicia o índice dos bosses
                        bossIndex = -1;
                        break;
                    }
                }
            }
        }

        // Adicionar este método para substituir o IsGameWindowVisible
        private bool IsGameWindowVisible()
        {
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.MainWindowTitle.Equals(selectedWindow))
                {
                    return true;
                }
            }
            return false;
        }


        private void SimularMovimentoAleatorio(CancellationToken token)
        {
            string[] teclasMovimento = { "W", "A", "S", "D" };
            // Garantir que pelo menos duas teclas sejam pressionadas
            List<string> teclasSelecionadas = new List<string>();

            // Selecionar pelo menos duas teclas diferentes
            while (teclasSelecionadas.Count < 2)
            {
                string tecla = teclasMovimento[random.Next(teclasMovimento.Length)];
                if (!teclasSelecionadas.Contains(tecla))
                {
                    teclasSelecionadas.Add(tecla);
                }
            }

            // Agora, pressionar as teclas selecionadas aleatoriamente
            foreach (var tecla in teclasSelecionadas)
            {
                if (token.IsCancellationRequested) return;

                PressionarTecla(tecla, true); // Pressiona a tecla

                int delay = random.Next(500, 1500); // Delay aleatório entre 500ms e 1500ms
                int elapsed = 0;

                // Mantém pressionada por um tempo aleatório
                while (elapsed < delay)
                {
                    if (token.IsCancellationRequested)
                    {
                        keybd_event(GetVirtualKey(tecla), 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                        Log($"Tecla '{tecla.ToUpper()}' solta devido ao cancelamento.");
                        return;
                    }

                    Thread.Sleep(100);
                    elapsed += 100;
                }

                // Solta a tecla após o delay
                keybd_event(GetVirtualKey(tecla), 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                Log($"Tecla '{tecla.ToUpper()}' solta.");
            }
        }


        private void AvancarSubMapa()
        {
            switch (subMapaAtual)
            {
                case "1F":
                    subMapaAtual = "2F"; // Após o 1F, vai para o 2F
                    break;
                case "2F":
                    subMapaAtual = "3F"; // Após o 2F, vai para o 3F
                    break;
                case "3F":
                    subMapaAtual = "1F"; // Após o 3F, volta para o 1F
                    break;
            }
            Log($"Submapa alterado para: {subMapaAtual}");
        }

        private void ClickSubMapa((int x, int y) coordinate)
        {
            int offsetX = random.Next(-10, 10);
            int offsetY = random.Next(-10, 10);
            int newX = coordinate.x + offsetX;
            int newY = coordinate.y + offsetY;

            MoveMouse(newX, newY);
            ClickMouse();
            Log($"Clicou no submapa: {subMapaAtual} (X: {newX}, Y: {newY})");
        }

        private (int x, int y) GetRandomizedCoordinateForBoss(int x, int y)
        {
            int offsetX = random.Next(-160, 195); // Para bosses
            int offsetY = random.Next(-18, 18); // Para bosses
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int newX = (int)(x + offsetX * (float)screenWidth / 1920);
            int newY = (int)(y + offsetY * (float)screenHeight / 1080);
            return (newX, newY);
        }

        private (int x, int y) GetRandomizedCoordinateForTeleport(int x, int y)
        {
            int offsetX = random.Next(-105, 105); // Para teletransporte
            int offsetY = random.Next(-20, 20); // Para teletransporte
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int newX = (int)(x + offsetX * (float)screenWidth / 1920);
            int newY = (int)(y + offsetY * (float)screenHeight / 1080);
            return (newX, newY);
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
                Log($"Tecla '{tecla}' não reconhecida.");
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
                Log($"Tecla '{tecla}' não reconhecida.");
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
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
            Thread.Sleep(random.Next(100, 150));
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
            Log("Clique do mouse realizado.");
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
                logTextBox.SelectionStart = logTextBox.Text.Length;
                logTextBox.ScrollToCaret();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.PostBossDelaySeconds = postBossDelayMilliseconds / 1000;
            settingsForm.PostTeleportDelaySeconds = postTeleportDelayMilliseconds / 1000;
            settingsForm.TempoEsperaAposBSeconds = tempoEsperaAposB / 1000;
            settingsForm.DelayMapLoad = delayMapLoad / 1000;

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                postBossDelayMilliseconds = settingsForm.PostBossDelaySeconds * 1000;
                postTeleportDelayMilliseconds = settingsForm.PostTeleportDelaySeconds * 1000;
                tempoEsperaAposB = settingsForm.TempoEsperaAposBSeconds * 1000;
                delayMapLoad = settingsForm.DelayMapLoad * 1000;
            }
        }



        private void startButton_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource == null)
            {
                if (!BringGameWindowToFront())
                {
                    Log("Janela do jogo não encontrada!");
                    return;
                }

                cancellationTokenSource = new CancellationTokenSource();
                isBPressed = false;

                // Converta os valores de segundos para milissegundos
                int minDelayMilliseconds = this.minDelayMilliseconds;
                int maxDelayMilliseconds = this.maxDelayMilliseconds;
                int postBossDelayMilliseconds = this.postBossDelayMilliseconds;
                int teleportMinDelayMilliseconds = this.teleportMinDelayMilliseconds;
                int teleportMaxDelayMilliseconds = this.teleportMaxDelayMilliseconds;
                int postTeleportDelayMilliseconds = this.postTeleportDelayMilliseconds;
                int delayMapLoadMilliseconds = this.delayMapLoad;

                // Inicia o bot sem pressionar a tecla 'B' aqui
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
            cancellationTokenSource = null;
            Log("Script interrompido.");
        }
    }
}