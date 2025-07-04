using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    class GameManager
    { 
        private GameManager () { }
        private static GameManager instance;
        public static GameManager Instance => instance ??= new GameManager();

        public void StartGame()
        {
            // Aqui vai entrar o menu de vocês
            jogar();
        }


        public char[,] mapa;
        public int largura = 60;
        public int altura = 30;

        public bool jogando = true;
        public Personagem player1;


        public void jogar()
        {
            
            iniciarMapa();

            player1 = new Personagem();
            player1.desenhar();

            while (jogando)
            {
                Console.Clear();

                DesenharMapa();

                player1.desenhar();

                var tecla = Console.ReadKey(true).Key;

                player1.movimentar(tecla);
            }
        }

        public void iniciarMapa()
        {
            mapa = new char[largura, altura];

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
        }


        public void DesenharMapa()
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
