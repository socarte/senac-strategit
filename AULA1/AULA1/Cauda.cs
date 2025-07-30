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
        public void Draw()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.Write(CORPO);
            if (proximo != null)
            {
                proximo.Draw();
            }
        }
       

        public void atualiza(Vector2 novapos)
        {
            if (proximo != null)
            {
                proximo.atualiza(this.pos);
            }

            this.pos = novapos;
        }

        public void Crescer(Vector2 novapos)
        {
            if (proximo == null)
            {
                proximo = new Cauda(this.pos); // adiciona novo segmento
            }
            else
            {
                proximo.Crescer(this.pos); // vai até o final e adiciona
            }

            this.pos = novapos;
        }

        public bool Colidir(Vector2 novapos)
        {
            if (this.pos.x == novapos.x && this.pos.y == novapos.y)
            {
                return true; // colidiu com a cauda
            }
            if (proximo != null)
            {
                return proximo.Colidir(novapos); // verifica na próxima cauda
            }
            return false; // não colidiu
        }
    }
}