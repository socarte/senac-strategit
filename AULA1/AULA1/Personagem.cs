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
        public vector2 pos = new vector2(1, 1);

        public Personagem() {
           
        }

        public void movimentar(ConsoleKey tecla)
        {
            int tempX = pos.x;
            int tempY = pos.y;
            int x = pos.x;
            int y = pos.y;

            switch (tecla)
            {
                case ConsoleKey.A:
                    x = pos.left;
                    break;
                case ConsoleKey.D:
                    x = pos.right;
                    break;
                case ConsoleKey.W:
                    y = pos.up;
                    break;
                case ConsoleKey.S:
                    y = pos.down;
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
