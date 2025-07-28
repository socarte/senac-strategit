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

        private cauda cauda;

        public Personagem()
        {
            Run();
            cauda = new cauda(pos); // inicia com um pedaço de cauda na posição da cabeça
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
               /** voltar o menu */

            }else if (Mapa.Instance.mapa[x, y] == '*')
            {
                Mapa.Instance.mapa[x, y] = ' ';
                Mapa.Instance.gerarComida();
                cauda = new cauda(pos);
          
            }

        }

        public override void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(CABECA);
            movimentar();
            if (cauda != null)
            {
                cauda.atualiza(pos);
            }
        }

        public override void Update()
        {
           
            movimentar();
            
            if (cauda != null)
            {
                cauda.atualiza(pos);
            }
        }

    }
}
