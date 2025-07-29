using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    class Mapa:MonoBehaviour
    {
        private Mapa() {
            Run();
        }
        public static Mapa Instance => instance ??= new Mapa();
        private static Mapa instance;
       
        public char[,] mapa;
        public int largura = 60;
        public int altura = 30;
       


        public override void Start(){
            mapa = new char[largura, altura];
            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    if (x == 0 || x == largura - 1 || y == 0 || y == altura - 1)
                    {
                        mapa[x, y] = '#'; // Paredes
                    }
                    else
                    {
                        mapa[x, y] = ' '; // Espaço vazio
                    }
                }
            }

            gerarComida();
        }


        public override void Draw()
        {
            
            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Console.Write(mapa[x, y]);
                }
                Console.WriteLine();
            }
        }

        
        public void gerarComida()
        {
            Random r = new Random();
            int x = r.Next(1, largura - 1);
            int y = r.Next(1, altura - 1);
            mapa[x, y] = '*'; // Comida
        }

    }
}
