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
        public ConsoleKey direcao = ConsoleKey.D;

        public Personagem() {
            Run();
        }

        public void movimentar()
        {
            int tempX = pos.x;
            int tempY = pos.y;
            int x = pos.x;
            int y = pos.y;

            switch (direcao)
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
                GameManager.Instance.jogando = false;
                Mapa.Instance.Stop();
                Stop();

            }else if (Mapa.Instance.mapa[x, y] == '*')
            {
                Mapa.Instance.mapa[x, y] = ' ';
                Mapa.Instance.gerarComida();
            }

        }

        public void desenhar()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(CABECA);
        }

        public override void Update()
        {
           
            movimentar();
            Mapa.Instance.DesenharMapa();
            desenhar();
        }

    }
}
