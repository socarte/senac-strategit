using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    class Mapa:MonoBehaviour
    {
        private Mapa() { }
        public static Mapa Instance => instance ??= new Mapa();
        private static Mapa instance;
       
        public char[,] mapa;
        public int largura = 60;
        public int altura = 30;
       
        public void iniciarMapa()
        {
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
        }
        public void DesenharMapa()
        {
            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Console.Write(mapa[x, y]);
                }
                Console.WriteLine();
            }
        }

        public override void Start()
        {
            iniciarMapa();
        }

        public override void Update()
        {
            DesenharMapa();
            GameManager.Instance.player1.desenhar();
        }


    }
}
