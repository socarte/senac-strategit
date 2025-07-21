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
            menu();
            // Aqui vai entrar o menu de vocês

        }


        public char[,] mapa;
        public int largura = 60;
        public int altura = 30;

        public bool jogando = true;
        public Personagem player1;

        public void menu()
        {
            Console.Clear();
            Console.WriteLine("""
                Bem-vindo ao jogo SNAKE!
                começar(tecla enter)
                créditos(tecla x)
                sair(tecla esc)
                 """);

            var tecla = Console.ReadKey(true).Key;
            switch (tecla)
            {
                case ConsoleKey.Enter:
                    jogar();
                    break;
                case ConsoleKey.X:
                    Console.WriteLine("Créditos: Desenvolvido por [lucas]");
                    Console.ReadKey();
                    menu();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    menu();
                    break;
            } 

        }


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
