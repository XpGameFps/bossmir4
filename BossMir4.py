import tkinter as tk
import threading
import ctypes  # Para esconder o terminal
import keyboard  # Para detectar as teclas pressionadas
import pygetwindow as gw  # Para manipular janelas
import time
import pyautogui  # Para clicar nas coordenadas
import random  # Para a variação do clique

# Variáveis globais
is_running = False  # Para rastrear se o script está rodando

# Coordenadas dos bosses e teleport
boss_coordinates = [
    (1579, 498),  # Boss 1
    (1597, 574),  # Boss 2
    (1606, 650),  # Boss 3
    (1603, 726),  # Boss 4
    (1617, 785)   # Boss 5
]
teleport_coordinate = (1548, 971)  # Nova coordenada padrão para teleportar

# Funções para iniciar e parar o script
def start_script():
    global is_running
    if not is_running:
        is_running = True
        selected_window = window_var.get()
        log_message(f"Iniciando o script na janela: {selected_window}")

        # Ativa a janela selecionada
        try:
            window = gw.getWindowsWithTitle(selected_window)[0]
            window.activate()
            time.sleep(0.2)  # Aguarda a ativação da janela
        except IndexError:
            log_message(f"Janela '{selected_window}' não encontrada.")
            return

        # Executa o loop do script
        threading.Thread(target=script_loop, args=(selected_window,), daemon=True).start()
    else:
        log_message("O script já está em execução.")

def script_loop(selected_window):
    global is_running
    boss_index = 0  # Começa pelo Boss 1 (índice 0)

    # Pressiona a tecla B para iniciar o combate apenas uma vez ao iniciar o bot
    keyboard.press_and_release('b')
    log_message("Pressionando a tecla 'B' para iniciar o combate.")

    while is_running:
        # Espera 30 segundos
        time.sleep(30)
        if not is_running:  # Verifica se o script ainda está rodando
            break
        
        # Pressiona F10 antes de clicar no boss
        keyboard.press_and_release('F10')
        log_message("Pressionando a tecla 'F10' para abrir o mapa.")

        # Move o mouse para a coordenada do boss atual com variação
        offset_x = random.randint(-5, 5)  # Variação aleatória no eixo X
        offset_y = random.randint(-5, 5)  # Variação aleatória no eixo Y
        boss_coordinate = (boss_coordinates[boss_index][0] + offset_x, boss_coordinates[boss_index][1] + offset_y)
        
        pyautogui.moveTo(boss_coordinate, duration=0.5)  # Mover suavemente
        log_message(f"Mover para o Boss {boss_index + 1} na coordenada {boss_coordinate}.")

        # Clica na coordenada do boss atual
        pyautogui.click(boss_coordinate)
        log_message(f"Clicando no Boss {boss_index + 1}.")

        # Delay para observar a ação
        time.sleep(5)  # Delay de 5 segundos
        
        # Move o mouse para a nova coordenada de teleport com variação
        offset_x = random.randint(-5, 5)  # Variação aleatória no eixo X
        offset_y = random.randint(-5, 5)  # Variação aleatória no eixo Y
        teleport_coordinate_variation = (teleport_coordinate[0] + offset_x, teleport_coordinate[1] + offset_y)

        pyautogui.moveTo(teleport_coordinate_variation, duration=0.5)  # Mover suavemente
        log_message(f"Mover para a nova coordenada de teleport {teleport_coordinate_variation}.")

        # Clica na nova coordenada de teleport
        pyautogui.click(teleport_coordinate_variation)
        log_message(f"Clicando na nova coordenada de teleport.")

        # Pressiona a tecla B após o teletransporte
        keyboard.press_and_release('b')
        log_message("Pressionando a tecla 'B' após o teletransporte.")

        # Espera um pouco para permitir que o teletransporte ocorra e o mapa carregue
        time.sleep(5)  # Ajuste o tempo conforme necessário

        # Atualiza o índice do boss para o próximo
        boss_index = (boss_index + 1) % len(boss_coordinates)  # Ciclo pelos bosses

    log_message("O script foi parado.")

def stop_script():
    global is_running
    if is_running:
        log_message("Parando o script")
        is_running = False
    else:
        log_message("O script já está parado.")

def close_app():
    """Fecha o aplicativo e para o bot."""
    stop_script()  # Para o bot se estiver em execução
    root.destroy()  # Fecha a janela

def log_message(message):
    """Adiciona uma mensagem à área de texto de depuração.""" 
    debug_text.insert(tk.END, message + '\n') 
    debug_text.see(tk.END)  # Rola para a última linha

def on_selection_change(*args):
    selected_window = window_var.get()
    log_message(f"Selecionada a janela: {selected_window}")

def monitor_keys():
    while True:
        if keyboard.is_pressed('up'):  # Iniciar com tecla para cima
            start_script()
        elif keyboard.is_pressed('down'):  # Parar com tecla para baixo
            stop_script()
        elif keyboard.is_pressed('alt') and keyboard.is_pressed('caps lock'):  # Fecha o aplicativo com Alt + Caps Lock
            close_app()
            break
        time.sleep(0.1)  # Pequeno delay para evitar uso excessivo da CPU

# Esconder a janela do terminal
ctypes.windll.user32.ShowWindow(ctypes.windll.kernel32.GetConsoleWindow(), 0)

# Criar a janela principal
root = tk.Tk()
root.title("Controle de Script MIR4")

# Variável para armazenar a seleção da janela
window_var = tk.StringVar(value="Mir4G[1]")
window_var.trace("w", on_selection_change)  # Adiciona rastreio para mudanças na seleção

# Organizando os botões de seleção da janela
frame = tk.Frame(root)
frame.pack(pady=10)

rb1 = tk.Radiobutton(frame, text="Mir4G[1]", variable=window_var, value="Mir4G[1]")
rb2 = tk.Radiobutton(frame, text="Mir4G[2]", variable=window_var, value="Mir4G[2]")
rb1.pack(side=tk.LEFT, padx=5)
rb2.pack(side=tk.LEFT, padx=5)

# Botões para iniciar e parar o script
button_frame = tk.Frame(root)
button_frame.pack(pady=10)

start_button = tk.Button(button_frame, text="Iniciar Script", command=start_script)
start_button.pack(side=tk.LEFT, padx=5)

stop_button = tk.Button(button_frame, text="Parar Script", command=stop_script)
stop_button.pack(side=tk.LEFT, padx=5)

# Área de texto para depuração
debug_text = tk.Text(root, height=10, width=50)
debug_text.pack(pady=10)

# Inicia o monitoramento das teclas em um thread separado
threading.Thread(target=monitor_keys, daemon=True).start()

# Iniciar o loop da interface
root.mainloop()
