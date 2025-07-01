using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE

{
    class Personagem
    {
        private const char CABECA = '@';
        private const char CORPO = 'O';
        public int playerX = 1;
        public int playerY = 1;

        char[,] mapa;

        public Personagem(char[,] mapa) { 
            this.mapa = mapa;
        }

        public void movimentar(ConsoleKey tecla)
        {
            int tempX = playerX;
            int tempY = playerY;

            switch (tecla)
            {
                case ConsoleKey.A:
                    tempX--;
                    break;
                case ConsoleKey.D:
                    tempX++;
                    break;
                case ConsoleKey.W:
                    tempY--;
                    break;
                case ConsoleKey.S:
                    tempY++;
                    break;
            }

            if (mapa[tempX, tempY] != '#')
            {
                mapa[playerX, playerY] = ' ';
                mapa[tempX, tempY] = '@';
                playerX = tempX;
                playerY = tempY;
            }

        }
    }
}
