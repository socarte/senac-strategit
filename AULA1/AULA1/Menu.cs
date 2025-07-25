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
        public static Menu Instance => instance ??= new Menu();

        private static Menu instance;

        public void Update()
        {
            var tecla = Console.ReadKey(true).Key;
            switch (tecla)
            {
                case ConsoleKey.Enter:
                    GameManager.Instance.map.visible = true;
                    GameManager.Instance.player1.visible = true;
                    GameManager.Instance.player1.Input = true;
                    GameManager.Instance.mobi.Input = false;
                    GameManager.Instance.mobi.visible = false;
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
