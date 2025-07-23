using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    public class Cauda
    {
        private Vector2 pos;
        private Cauda proximo;
        private const char CORPO = 'O';

        public Cauda(Vector2 pos)
        {
            this.pos = pos;
            
           
        }

        public  void atualiza(Vector2 pos)
        {
            if (proximo!= null)
            {
                proximo.atualiza(this.pos);
            }
            this.pos = pos;
            desenhar();
        }

        public void desenhar()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(CORPO);
        }
    }
}
