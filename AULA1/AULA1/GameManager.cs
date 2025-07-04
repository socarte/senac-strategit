using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    internal class GameManager
    { private GameManager () { }
        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
        public void StartGame()
        {
            // Lógica para iniciar o jogo
            Console.WriteLine("Jogo iniciado!");
        }
        public void EndGame()
        {
            // Lógica para encerrar o jogo
            Console.WriteLine("Jogo encerrado!");
        }
    }
}
