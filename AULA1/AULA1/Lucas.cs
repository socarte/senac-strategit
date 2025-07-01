using System;

namespace SNAKE
{
    class Lucas
    {
        static char[,] mapa;
        static int largura = 60;
        static int altura = 30;
       
        static bool jogando = true;
        static Personagem player1;

        static void Main()
        {
            Console.Clear();

            // Aqui vai entrar o menu de vocês
            jogar();
        }

        static void jogar()
        {
            iniciarMapa();

            

            while (jogando)
            {
                Console.SetCursorPosition(0,0);
                DesenharMapa();

                var tecla = Console.ReadKey(true).Key;

                player1.movimentar(tecla);
            }
        }

        static void iniciarMapa()
        {
            mapa = new char[largura, altura];
            
            player1 = new Personagem(mapa);

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    //ultima posição do vetor é tamanho - 1
                    if (x == 0 || y == 0 || x == largura - 1 || y == altura - 1)
                    {
                        mapa[x, y] = '#';
                    }
                    else
                    {
                        mapa[x, y] = ' ';
                    }
                }
            }

            mapa[player1.playerX , player1.playerY] = '@';
        }


        static void DesenharMapa()
        {
            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Console.Write(mapa[x, y]);
                }
                Console.WriteLine();
            }
        }

      



    }
}
