# Nota de Atualização - Projeto Mir4Bot
**Data:** [06/01/2025]

### Principais Mudanças e Melhorias

1. **Seleção e Controle da Janela**:
   - Implementação de um sistema de seleção de janela, permitindo ao usuário escolher entre diferentes instâncias do jogo (`Mir4G[0]`, `Mir4G[1]`, etc.) através de um `ComboBox`.
   - A janela escolhida é trazida para frente usando a função `BringGameWindowToFront`, garantindo que o bot interaja com a instância correta do jogo.

2. **Cancelamento do Script**:
   - Implementação de um controle de cancelamento via `CancellationTokenSource`, permitindo ao usuário iniciar, pausar e parar o bot de forma controlada.
   - O bot pode ser interrompido a qualquer momento, garantindo que o script não continue a rodar indefinidamente.

3. **Movimentos Aleatórios**:
   - O bot agora simula movimentos aleatórios utilizando as teclas `W`, `A`, `S`, e `D` com intervalos de tempo configuráveis.
   - Esses movimentos são realizados com variações de tempo aleatórias, ajudando a evitar que o bot siga um padrão repetitivo e facilitando a detecção.

4. **Interação com Bosses e Teletransporte**:
   - A interação com os bosses foi aprimorada, agora utilizando coordenadas aleatórias baseadas na resolução da tela.
   - O bot clica nas coordenadas dos bosses e realiza o teletransporte para locais aleatórios, evitando movimentos previsíveis.
   - As coordenadas de teletransporte também foram ajustadas aleatoriamente, com a implementação de um pequeno intervalo de tempo antes de realizar o teletransporte.

5. **Delays Dinâmicos e Aleatórios**:
   - O bot agora permite a configuração de delays dinâmicos e aleatórios entre suas ações, com diferentes intervalos para ataques, cliques nos bosses, teletransporte e outros comportamentos.
   - O intervalo de tempo pode ser ajustado para cada ação através da interface de configurações, proporcionando maior flexibilidade e controle sobre o tempo de execução do bot.

6. **Interface de Configuração (SettingsForm)**:
   - Foi adicionada uma interface de configurações que permite ao usuário ajustar diversos parâmetros de delay, como:
     - `minDelayMilliseconds` (delay mínimo entre ações)
     - `maxDelayMilliseconds` (delay máximo entre ações)
     - `postBossDelayMilliseconds` (delay após clicar no boss)
     - `teleportMinDelayMilliseconds` e `teleportMaxDelayMilliseconds` (delays antes de teletransportar)
     - `postTeleportDelayMilliseconds` (delay após teletransporte)
   - Isso permite ao usuário personalizar o comportamento do bot conforme as necessidades do jogo e do ambiente.

7. **Sistema de Log Aprimorado**:
   - O sistema de log foi expandido para registrar detalhes sobre as ações do bot, como pressionamento de teclas, movimento do mouse, cliques, interações com bosses e teletransporte.
   - O log é exibido em tempo real na interface gráfica com rolagem automática, facilitando o acompanhamento das atividades do bot.

8. **Controle de Teclas e Ações**:
   - As teclas agora podem ser pressionadas e mantidas pressionadas durante os movimentos, com um tempo de espera configurável entre as ações.
   - O código também verifica se a execução do bot foi cancelada durante os movimentos, garantindo que o script possa ser interrompido de forma segura e eficiente.

9. **Ajustes de Coordenadas Aleatórias**:
   - As coordenadas de ataque aos bosses e de teletransporte são agora aleatórias, ajustadas de acordo com a resolução da tela para evitar padrões repetitivos e tornar a execução mais difícil de ser detectada pelo sistema do jogo.

10. **Comportamento Dinâmico**:
    - O bot é mais dinâmico agora, com a implementação de um comportamento que simula ações mais naturais, como intervalos aleatórios entre ataques, cliques e teletransportes, além de movimentos aleatórios durante a execução.
