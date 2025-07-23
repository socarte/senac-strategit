using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE

{
    class Personagem : MonoBehaviour
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

            if (! (tempX>0 && tempX<Mapa.Instance.largura && tempY>0 && tempY<Mapa.Instance.altura))
            {
                pos.x = tempX;
                pos.y = tempY;
            }
        }

        public void desenhar()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(CABECA);
        }

        public override void Update()
        {
            var tecla = Console.ReadKey(true).Key;
            movimentar(tecla);
        }

    }
}
