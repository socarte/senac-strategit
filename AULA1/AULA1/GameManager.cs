using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    class GameManager:MonoBehaviour
    { 
        private GameManager () { }
        private static GameManager instance;
        public static GameManager Instance => instance ??= new GameManager();

        public override void Start()
        {
            menu();
            // Aqui vai entrar o menu de vocês

        }


        public char[,] mapa;
        public int largura = 60;
        public int altura = 30;

        public bool jogando = false;
        public Personagem player1;

        public void menu()
        {
            Console.Clear();
            Console.WriteLine("Bem-vindo ao jogo SNAKE! \n começar(tecla enter) \n créditos(tecla x) \n sair(tecla esc)");

            var tecla = Console.ReadKey(true).Key;
            switch (tecla)
            {
                case ConsoleKey.Enter:
                    jogar();
                    break;
                case ConsoleKey.X:
                    Console.WriteLine("Créditos: Desenvolvido por [lucas]");
                    Console.ReadKey();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            } 

        }

        public override void Update()
        {
            if (jogando) {
                
               
                var tecla = Console.ReadKey(true).Key;
                player1.direcao = tecla;
            }
            else
            {
                menu();
            }
        }


        public void jogar()
        {
            Console.Clear();
            jogando = true;
            Mapa m = Mapa.Instance;

            player1 = new Personagem();
        }
     

    }
}
