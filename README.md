# Nota de Atualização - Projeto Mir4Bot
**Data:** [Insira a data da atualização]

## Resumo das Alterações
Esta atualização marca uma migração significativa do código do projeto Mir4Bot de Python para C#. As mudanças incluem a reestruturação da lógica do bot e a implementação de uma interface gráfica com o Windows Forms, proporcionando uma experiência de usuário mais amigável e interativa.

## Alterações Principais

### Migração de Linguagem
- O projeto foi reescrito de Python para C#, garantindo melhor integração com a plataforma Windows e melhor performance em execução.

### Estrutura do Código
- **Program.cs:** Implementação da inicialização do aplicativo utilizando Windows Forms.
    ```csharp
    using System;
    using System.Windows.Forms;

    namespace Mir4Bot
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
    ```

- **MainForm.Designer.cs:** Definição dos componentes da interface gráfica, incluindo botões para iniciar e parar o script, uma caixa de texto para logs e um combo box para seleção da janela do jogo.
    ```csharp
    private void InitializeComponent()
    {
        // Código gerado para a interface do usuário
    }
    ```

- **MainForm.cs:** Implementação da lógica do bot, que agora inclui:
    - Controle do fluxo de execução do script através de botões.
    - Log de atividades em uma caixa de texto.
    - Seleção dinâmica da janela do jogo através de um combo box.
    - Manipulação de eventos do mouse e envio de teclas para o jogo.

## Funcionalidades Implementadas
- Adição de coordenadas de bosses e teleportação com escalonamento de coordenadas para diferentes resoluções de tela.
- Implementação de um loop de bot que gerencia o combate de forma automática, incluindo comandos de teclado e cliques do mouse.

## Melhorias na Usabilidade
- Interface mais intuitiva para interação com o usuário.
- Mensagens de log para facilitar o acompanhamento da execução do script.

## Considerações Finais
Com essa atualização, esperamos que a automação do jogo MIR4 se torne mais eficaz e fácil de usar. A migração para C# não só melhora a performance do bot, mas também abre portas para futuras melhorias e funcionalidades.
