# Mir4Bot - Atualização 24/02/2025

### 🆕 Principais Mudanças e Melhorias

📰 **Carregamento de Notícias**  
- Implementado sistema para carregar notícias de um arquivo JSON hospedado no GitHub e exibi-las em um **RichTextBox**.  
- Novo serviço `NoticiasService` para buscar e exibir as notícias.  

⏳ **Novo Delay Após Pressionar 'B'**  
- Adicionado **delay configurável** (`tempoEsperaAposB`) de **5 segundos** após pressionar a tecla **'B'** antes de iniciar o combate.  

⚙️ **Ajustes na Interface de Configuração**  
- Atualizado o **SettingsForm** para incluir o novo delay `tempoEsperaAposB`.  
- Agora é possível configurar vários parâmetros de delay:  
  - `minDelayMilliseconds` (delay mínimo entre ações)  
  - `maxDelayMilliseconds` (delay máximo entre ações)  
  - `postBossDelayMilliseconds` (delay após clicar no boss)  
  - `teleportMinDelayMilliseconds` e `teleportMaxDelayMilliseconds` (delays antes de teletransportar)  
  - `postTeleportDelayMilliseconds` (delay após teletransporte)  
  - `delayMapLoad` (delay para carregar o mapa)  

🔄 **Melhorias no Loop do Bot**  
- O **loop principal** foi aprimorado para incluir novas lógicas de delay e movimentos aleatórios.  
- Implementação de **movimentos aleatórios** usando **W, A, S, D** para simular um comportamento mais natural.  

📌 **Ajustes de Coordenadas Aleatórias**  
- **Ataques a bosses e teletransportes** agora utilizam coordenadas **aleatórias**.  
- Ajustadas conforme a **resolução da tela**, evitando padrões repetitivos para **reduzir o risco de detecção** pelo sistema do jogo.  

🗃️ **Sistema de Log Aprimorado**  
- **Expansão do sistema de logs**, registrando ações detalhadas:  
  - Pressionamento de teclas  
  - Movimentos do mouse  
  - Cliques  
  - Interações com bosses  
  - Teletransportes  
- **Exibição em tempo real** na interface gráfica, com **rolagem automática**.  

🎮 **Controle de Teclas e Ações**  
- Agora as teclas podem ser **pressionadas e mantidas** durante os movimentos.  
- Implementado **tempo de espera configurável** entre as ações.  
- Verificação contínua para **cancelamento seguro** da execução do bot.  

🏃 **Comportamento Dinâmico**  
- Simulação de ações **mais naturais**, com:  
  - **Intervalos aleatórios** entre ataques, cliques e teletransportes.  
  - **Movimentos aleatórios** durante a execução para tornar o comportamento do bot menos previsível.  

💡 Essas melhorias tornam o **Mir4Bot** mais eficiente, discreto e configurável para diferentes estilos de jogo. 🚀
