using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    public  class Menu : MonoBehaviour
    {
        private Menu()
        {
            Run();
        }
        private static Menu instance;
        public static Menu Instance => instance ??= new Menu();

        

        public  override void Update()
        {
            if (!Input) return;

            var tecla = Console.ReadKey(true).Key;
            switch (tecla)
            {
                case ConsoleKey.Enter:
                    visible = false;
                    Input = false;

                    GameManager.Instance.map = Mapa.Instance;
                    GameManager.Instance.map.visible = true;

                    GameManager.Instance.player1 = new Personagem();
                    GameManager.Instance.player1.visible = true;
                    GameManager.Instance.player1.Input = true;
                   
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
        
        public override void Draw()
        {
            Console.Clear();
            Console.WriteLine("Bem-vindo ao jogo SNAKE! \n começar(tecla enter) \n créditos(tecla x) \n sair(tecla esc)");
        }



        









    }
}
