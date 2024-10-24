import pyautogui
import time
from pynput import mouse

# Lista para armazenar as coordenadas
coordenadas = []

def on_click(x, y, button, pressed):
    if pressed and button == mouse.Button.left:  # Verifica se o botão esquerdo foi pressionado
        coordenadas.append((x, y))  # Adiciona as coordenadas à lista
        print(f"Coordenadas salvas: ({x}, {y})")

# Inicia o listener do mouse
listener = mouse.Listener(on_click=on_click)

try:
    listener.start()  # Inicia o listener
    print("Clique com o botão esquerdo dentro do jogo para salvar as coordenadas.")
    
    while True:
        # Exibe a posição atual do mouse
        x, y = pyautogui.position()  
        print(f"Coordenadas atuais: ({x}, {y})", end='\r')  
        time.sleep(0.5)  # Atualiza a cada meio segundo

except KeyboardInterrupt:
    listener.stop()  # Para o listener do mouse
    print("\nExecução interrompida.")
    print("Coordenadas salvas:", coordenadas)  # Exibe as coordenadas salvas
except Exception as e:
    print(f"Ocorreu um erro: {e}")
    listener.stop()
