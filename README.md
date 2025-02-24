Nota de Atualização - Projeto Mir4Bot
Data: [24/02/2025]
Principais Mudanças e Melhorias
1.	Carregamento de Notícias:
•	Adicionada funcionalidade para carregar notícias de um arquivo JSON hospedado no GitHub e exibi-las em um RichTextBox na interface do usuário.
•	Implementação de um serviço NoticiasService para buscar e exibir as notícias.
2.	Novo Delay Após Pressionar 'B':
•	Adicionado um novo delay configurável tempoEsperaAposB de 5 segundos após pressionar a tecla 'B' para iniciar o combate.
3.	Ajustes na Interface de Configuração:
•	A interface de configurações (SettingsForm) foi atualizada para incluir o novo delay tempoEsperaAposB.
•	Permite ao usuário ajustar diversos parâmetros de delay, como:
•	minDelayMilliseconds (delay mínimo entre ações)
•	maxDelayMilliseconds (delay máximo entre ações)
•	postBossDelayMilliseconds (delay após clicar no boss)
•	teleportMinDelayMilliseconds e teleportMaxDelayMilliseconds (delays antes de teletransportar)
•	postTeleportDelayMilliseconds (delay após teletransporte)
•	delayMapLoad (delay para carregar o mapa)
4.	Melhorias no Loop do Bot:
•	O loop principal do bot (BotLoop) foi aprimorado para incluir a nova lógica de delays e movimentos aleatórios.
•	Implementação de movimentos aleatórios com teclas W, A, S, D para simular um comportamento mais natural.
5.	Ajustes de Coordenadas Aleatórias:
•	As coordenadas de ataque aos bosses e de teletransporte são agora aleatórias, ajustadas de acordo com a resolução da tela para evitar padrões repetitivos e tornar a execução mais difícil de ser detectada pelo sistema do jogo.
6.	Sistema de Log Aprimorado:
•	O sistema de log foi expandido para registrar detalhes sobre as ações do bot, como pressionamento de teclas, movimento do mouse, cliques, interações com bosses e teletransporte.
•	O log é exibido em tempo real na interface gráfica com rolagem automática, facilitando o acompanhamento das atividades do bot.
7.	Controle de Teclas e Ações:
•	As teclas agora podem ser pressionadas e mantidas pressionadas durante os movimentos, com um tempo de espera configurável entre as ações.
•	O código também verifica se a execução do bot foi cancelada durante os movimentos, garantindo que o script possa ser interrompido de forma segura e eficiente.
8.	Comportamento Dinâmico:
•	O bot é mais dinâmico agora, com a implementação de um comportamento que simula ações mais naturais, como intervalos aleatórios entre ataques, cliques e teletransportes, além de movimentos aleatórios durante a execução.
