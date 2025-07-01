using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SNAKE
{
    class Program
    {
        // Constantes para o tamanho do campo de jogo
        private const int LARGURA = 24;
        private const int ALTURA = 12;

        // Constantes para os caracteres usados no jogo
        private const char PAREDE = 'X';
        private const char COMIDA = '+';
        private const char CABECA = 'O';
        private const char CORPO = 'O';

        // Direções possíveis para a cobra
        private enum Direcao { Cima, Baixo, Esquerda, Direita }

        // Posição no campo (linha, coluna)
        private struct Posicao
        {
            public int Linha;
            public int Coluna;

            public Posicao(int linha, int coluna)
            {
                Linha = linha;
                Coluna = coluna;
            }
        }

        static void Main(string[] args)
        {
            // Exibe o menu inicial
            MostrarMenu();
        }

        /// <summary>
        /// Exibe o menu inicial com opções e instruções
        /// </summary>
        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=== COBRINHA DO LUCAS ===");
            Console.WriteLine("\nMENU PRINCIPAL");
            Console.WriteLine("1 - Iniciar Jogo");
            Console.WriteLine("2 - Como Jogar");
            Console.WriteLine("3 - Ver Recordes");
            Console.WriteLine("4 - Sair");

            // Lê a opção do usuário
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    IniciarJogo();
                    break;
                case "2":
                    MostrarComoJogar();
                    break;
                case "3":
                    MostrarRecordes();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    MostrarMenu();
                    break;
            }
        }

        /// <summary>
        /// Exibe as instruções do jogo
        /// </summary>
        static void MostrarComoJogar()
        {
            Console.Clear();
            Console.WriteLine("=== COMO JOGAR ===");
            Console.WriteLine("\nCONTROLES:");
            Console.WriteLine("W - Movimenta para CIMA");
            Console.WriteLine("S - Movimenta para BAIXO");
            Console.WriteLine("A - Movimenta para ESQUERDA");
            Console.WriteLine("D - Movimenta para DIREITA");
            Console.WriteLine("\nREGRAS:");
            Console.WriteLine("- Colete os itens '+' para ganhar pontos");
            Console.WriteLine("- Cada item coletado vale 10 pontos");
            Console.WriteLine("- Não bata nas paredes ou no próprio corpo");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            MostrarMenu();
        }

        /// <summary>
        /// Exibe os 5 maiores recordes salvos
        /// </summary>
        static void MostrarRecordes()
        {
            Console.Clear();
            Console.WriteLine("=== TOP 5 RECORDES ===");

            var recordes = CarregarRecordes();

            if (recordes.Count == 0)
            {
                Console.WriteLine("\nNenhum recorde registrado ainda!");
            }
            else
            {
                for (int i = 0; i < recordes.Count && i < 5; i++)
                {
                    Console.WriteLine($"{i + 1}º lugar: {recordes[i]} pontos");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            MostrarMenu();
        }

        /// <summary>
        /// Inicia o jogo principal
        /// </summary>
        static void IniciarJogo()
        {
            Console.Clear();

            // Inicializa a cobra com 3 partes, começando na posição (3,3)
            var cobra = new List<Posicao>
            {
                new Posicao(3, 3),
                new Posicao(3, 2),
                new Posicao(3, 1)
            };

            Direcao direcaoAtual = Direcao.Direita;
            int pontuacao = 0;
            Posicao comida = GerarComida(cobra);
            bool gameOver = false;

            // Loop principal do jogo
            while (!gameOver)
            {
                // Limpa o console e desenha o campo
                Console.Clear();
                DesenharCampo(cobra, comida, pontuacao);

                // Verifica se há entrada do teclado
                if (Console.KeyAvailable)
                {
                    var tecla = Console.ReadKey(true).KeyChar;

                    // Atualiza a direção conforme a tecla pressionada
                    switch (char.ToLower(tecla))
                    {
                        case 'w':
                            if (direcaoAtual != Direcao.Baixo)
                                direcaoAtual = Direcao.Cima;
                            break;
                        case 's':
                            if (direcaoAtual != Direcao.Cima)
                                direcaoAtual = Direcao.Baixo;
                            break;
                        case 'a':
                            if (direcaoAtual != Direcao.Direita)
                                direcaoAtual = Direcao.Esquerda;
                            break;
                        case 'd':
                            if (direcaoAtual != Direcao.Esquerda)
                                direcaoAtual = Direcao.Direita;
                            break;
                    }
                }

                // Move a cobra
                var cabeca = cobra[0];
                Posicao novaCabeca;

                switch (direcaoAtual)
                {
                    case Direcao.Cima:
                        novaCabeca = new Posicao(cabeca.Linha - 1, cabeca.Coluna);
                        break;
                    case Direcao.Baixo:
                        novaCabeca = new Posicao(cabeca.Linha + 1, cabeca.Coluna);
                        break;
                    case Direcao.Esquerda:
                        novaCabeca = new Posicao(cabeca.Linha, cabeca.Coluna - 1);
                        break;
                    case Direcao.Direita:
                        novaCabeca = new Posicao(cabeca.Linha, cabeca.Coluna + 1);
                        break;
                    default:
                        novaCabeca = cabeca;
                        break;
                }

                // Verifica colisões
                if (ColisaoParede(novaCabeca) || ColisaoCorpo(novaCabeca, cobra))
                {
                    gameOver = true;
                    break;
                }

                // Insere a nova cabeça
                cobra.Insert(0, novaCabeca);

                // Verifica se comeu a comida
                if (novaCabeca.Linha == comida.Linha && novaCabeca.Coluna == comida.Coluna)
                {
                    pontuacao += 10;
                    comida = GerarComida(cobra);
                }
                else
                {
                    // Remove a cauda se não comeu
                    cobra.RemoveAt(cobra.Count - 1);
                }

                // Pequeno delay para o jogo não ficar muito rápido - (1000 = 1 segundo)2BCCA2
                System.Threading.Thread.Sleep(250);
            }

            // Game over - mostra pontuação e verifica recordes
            Console.Clear();
            Console.WriteLine("=== GAME OVER ===");
            Console.WriteLine($"\nPontuação final: {pontuacao} pontos");

            var recordes = CarregarRecordes();
            if (recordes.Count < 5 || pontuacao > recordes.Last())
            {
                Console.WriteLine("\nNOVO RECORDE! Parabéns!");
                recordes.Add(pontuacao);
                recordes = recordes.OrderByDescending(r => r).Take(5).ToList();
                SalvarRecordes(recordes);
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            MostrarMenu();
        }

        /// <summary>
        /// Desenha o campo de jogo com paredes, cobra e comida
        /// </summary>
        static void DesenharCampo(List<Posicao> cobra, Posicao comida, int pontuacao)
        {
            // Desenha a pontuação
            Console.WriteLine($"Pontuação: {pontuacao}");
            Console.WriteLine();

            // Desenha o campo
            for (int linha = 0; linha < ALTURA; linha++)
            {
                for (int coluna = 0; coluna < LARGURA; coluna++)
                {
                    // Verifica se é parede (borda)
                    if (linha == 0 || linha == ALTURA - 1 || coluna == 0 || coluna == LARGURA - 1)
                    {
                        Console.Write(PAREDE);
                    }
                    // Verifica se é a comida
                    else if (linha == comida.Linha && coluna == comida.Coluna)
                    {
                        Console.Write(COMIDA);
                    }
                    // Verifica se é parte da cobra
                    else
                    {
                        bool parteDaCobra = false;
                        for (int i = 0; i < cobra.Count; i++)
                        {
                            if (cobra[i].Linha == linha && cobra[i].Coluna == coluna)
                            {
                                Console.Write(i == 0 ? CABECA : CORPO);
                                parteDaCobra = true;
                                break;
                            }
                        }

                        if (!parteDaCobra)
                        {
                            Console.Write(' ');
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Gera uma nova posição para a comida que não colida com a cobra ou paredes
        /// </summary>
        static Posicao GerarComida(List<Posicao> cobra)
        {
            Random random = new Random();
            Posicao comida;

            do
            {
                comida = new Posicao(
                    random.Next(1, ALTURA - 1),
                    random.Next(1, LARGURA - 1)
                );
            }
            while (cobra.Any(p => p.Linha == comida.Linha && p.Coluna == comida.Coluna));

            return comida;
        }

        /// <summary>
        /// Verifica se a posição colide com as paredes
        /// </summary>
        static bool ColisaoParede(Posicao posicao)
        {
            return posicao.Linha <= 0 || posicao.Linha >= ALTURA - 1 ||
                   posicao.Coluna <= 0 || posicao.Coluna >= LARGURA - 1;
        }

        /// <summary>
        /// Verifica se a posição colide com o corpo da cobra
        /// </summary>
        static bool ColisaoCorpo(Posicao posicao, List<Posicao> cobra)
        {
            // Ignora a cabeça (primeiro elemento)
            for (int i = 1; i < cobra.Count; i++)
            {
                if (cobra[i].Linha == posicao.Linha && cobra[i].Coluna == posicao.Coluna)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Carrega os recordes do arquivo
        /// </summary>
        static List<int> CarregarRecordes()
        {
            var caminho = ObterCaminhoRecordes();
            var recordes = new List<int>();

            if (File.Exists(caminho))
            {
                try
                {
                    var linhas = File.ReadAllLines(caminho);
                    foreach (var linha in linhas)
                    {
                        if (int.TryParse(linha, out int pontos))
                        {
                            recordes.Add(pontos);
                        }
                    }
                }
                catch
                {
                    // Se houver erro ao ler, retorna lista vazia
                }
            }

            return recordes.OrderByDescending(r => r).Take(5).ToList();
        }

        /// <summary>
        /// Salva os recordes no arquivo
        /// </summary>
        static void SalvarRecordes(List<int> recordes)
        {
            var caminho = ObterCaminhoRecordes();
            var diretorio = Path.GetDirectoryName(caminho);

            try
            {
                // Cria o diretório se não existir
                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                // Salva apenas os 5 maiores recordes
                var recordesOrdenados = recordes.OrderByDescending(r => r).Take(5);
                File.WriteAllLines(caminho, recordesOrdenados.Select(r => r.ToString()));
            }
            catch
            {
                // Se houver erro ao salvar, simplesmente ignora
            }
        }

        /// <summary>
        /// Obtém o caminho completo para o arquivo de recordes
        /// </summary>
        static string ObterCaminhoRecordes()
        {
            var documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(documentos, "CobrinhaDoLucas", "TamanhoDaCobra.txt");
        }
    }
}