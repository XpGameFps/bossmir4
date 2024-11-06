# Nota de Atualização - Projeto Mir4Bot
**Data:** [06/11/2024]

## Interações Aleatórias e Variáveis

- **Movimento Aleatório**  
  > Implementação de movimentos aleatórios com as teclas "W", "A", "S" e "D" antes de algumas ações, simulando a movimentação humana. Utiliza a nova função `SimularMovimentoAleatorio`.

- **Espera Aleatória**  
  > Introduz um intervalo de espera aleatório entre 20 a 30 segundos antes de algumas ações, variando o tempo entre elas para um comportamento menos previsível (função `EsperaAleatoria`).

- **Coordenadas Aleatórias**  
  > Coordenadas dos pontos de ataque e teletransporte agora têm offsets aleatórios para simular cliques mais naturais. Funções `GetRandomizedCoordinateForBoss` e `GetRandomizedCoordinateForTeleport` adicionam variação nas posições.

## Interação com Teclado

- **Pressionar Teclas Específicas**  
  > A função `PressionarTecla` foi criada para simular o pressionamento de teclas, com a opção de mantê-las pressionadas e variação nos tempos de pressão e liberação.

- **Simulação de Clique de Teclas**  
  > Outra função, `ClicarTecla`, é dedicada ao ato de pressionar e soltar teclas.

## Manejo de Janela Ativa

- **Identificação de Janela**  
  > Mudança na forma como a janela do jogo é identificada, agora utilizando `Equals` ao invés de `Contains`, para garantir uma correspondência exata com o título da janela.

## Log Mais Detalhado

- **Adição de Logs**  
  > Adição de logs mais detalhados em várias etapas do script para rastrear ações como cliques, movimentos e teclas pressionadas, incluindo timestamps no formato `dd/MM/yyyy HH:mm:ss` para melhor acompanhamento.

## Outras Melhorias Menores

- **Ajustes de Delay**  
  > Inclusão de pequenos atrasos adicionais para tornar as interações mais naturais.

- **Novo Mecanismo de Teclas**  
  > Introdução de `keybd_event` para simular o pressionamento de teclas de forma mais avançada e diferenciada de `SendKeys`, proporcionando maior controle.
