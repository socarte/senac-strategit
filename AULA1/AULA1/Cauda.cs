using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    public class cauda
    {
        private Vector2 pos;
        private cauda proximo;
        private const char CORPO = 'O';

        public cauda(Vector2 pos)
        {
            this.pos = pos;


        }

        public void atualiza(Vector2 novapos)
        {
            if (proximo != null)
            {
                proximo.atualiza(this.pos);
            }

            this.pos = novapos;
        }

        public void Crescer(Vector2 novaPos)
        {
            if (proximo == null)
            {
                proximo = new cauda(novaPos); // adiciona novo segmento
            }
            else
            {
                proximo.Crescer(novaPos); // vai até o final e adiciona
            }
        }

        public void Desenhar()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(CORPO);
            proximo.Desenhar();
        }
    }
}