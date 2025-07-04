using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE

{
    class Personagem
    {
        private const char CABECA= '@';
        private const char CORPO = 'O';
        public int playerX;
        public int playerY;


        public Personagem() {
            this.playerX = 1;
            this.playerY = 1;
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

            if (tempX>0 && tempX<60 && tempY>0 && tempY<30)
            {
                playerX = tempX;
                playerY = tempY;
            }
        }

        public void desenhar()
        {
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(CABECA);
        }
    }
}
