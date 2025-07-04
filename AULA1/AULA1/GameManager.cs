using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    class GameManager
    { 
        private GameManager () { }
        private static GameManager instance;
        public static GameManager Instance => instance ??= new GameManager();

        public void StartGame()
        {
            // Aqui vai entrar o menu de vocês
            jogar();
        }


        public char[,] mapa;
        public int largura = 60;
        public int altura = 30;

        public bool jogando = true;
        public Personagem player1;


        public void jogar()
        {

            Mapa.Instance.iniciarMapa();

            player1 = new Personagem();
  

            while (jogando)
            {
                Console.SetCursorPosition(0,0);

                Mapa.Instance.DesenharMapa();

                player1.desenhar();

                var tecla = Console.ReadKey(true).Key;

                player1.movimentar(tecla);
            }
        }
     

    }
}
