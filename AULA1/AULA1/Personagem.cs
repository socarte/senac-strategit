using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE

{
     public class Personagem : MonoBehaviour
    {
        private const char CABECA= '@';
        
        public Vector2 pos = new Vector2(1, 1);
        public ConsoleKey direcao = ConsoleKey.D;

        private Cauda cauda;
        private bool crescer = false;

        public Personagem()
        {
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

            if (crescer)
            {
                crescer = false;

                if (cauda == null)
                {
                    cauda = new Cauda(new Vector2(tempX, tempY));
                }
                else
                {
                    cauda.Crescer(new Vector2(tempX, tempY));
                }
            }
            else
            {
                if (cauda != null)
                {
                    cauda.atualiza(new Vector2(tempX, tempY));
                }
            }

            if (! (tempX>0 && tempX<Mapa.Instance.largura-1 && tempY>0 && tempY<Mapa.Instance.altura-1))
            {
                visible = false;
                Input = false;

                GameManager.Instance.map.visible = false;

                GameManager.Instance.mobi.visible = true;
                GameManager.Instance.mobi.Input = true;

            }
            else if (Mapa.Instance.mapa[x, y] == '*')
            {
                Mapa.Instance.mapa[x, y] = ' ';
                Mapa.Instance.gerarComida();

                crescer = true;
            }
        }

        public override void Draw()
        {
            movimentar();
            
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(CABECA);
            if (cauda != null)
            {
                cauda.Draw();
            }
        }

        public override void Update()
        {
            if (!Input) return;

            direcao = Console.ReadKey(true).Key;
            movimentar();
        }

    }
}
