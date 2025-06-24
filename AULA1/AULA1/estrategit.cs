using System;


namespace AULA1
{
    class estrategit
    {
        static char[,] mapa;
        static int largura = 20;
        static int altura = 10;
        static int playerX = 1;
        static int playerY = 1;
        static bool jogando = true;

        public static void Main()
        {

            //TODO menu
            jogar();

        }

        public static void jogar()
        {
            while (jogando)
            {
                Console.Clear();
                desenhaMapa();

                var tecla = Console.ReadKey(true).Key;

                atualizarPosicao(tecla);

            }
        }
        static void iniciarmapa()
        {
            mapa = new char[largura, altura];

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
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

            mapa[playerX, playerY] = '@';
        }

        static void desenhaMapa()
        {
            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Console.Write(mapa[x,y]  );
                }
                Console.WriteLine();
            }
        }

        static void atualizarPosicao(ConsoleKey tecla)
        {
            int tempx = playerX;
            int tempy = playerY;

            switch (tecla) {
                case ConsoleKey.A:
                    tempx--;
                    break;
                case ConsoleKey.D:
                    tempx++;
                    break;
                case ConsoleKey.W:
                    tempy--;
                    break;
                case ConsoleKey.S:
                    tempy++;
                    break;
            }

            if (mapa[tempx,tempy] != '#') { 
            }


        }
        

    }
    
}