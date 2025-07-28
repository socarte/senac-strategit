using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    class GameManager:MonoBehaviour
    {
        private GameManager() 
        {
        }

        private static GameManager? instance;
        public static GameManager Instance => instance ??= new GameManager();


        public bool jogando = false;

        public Personagem player1;
        public Menu mobi;
        public Mapa map;


        public override void Update()
        {
            Draw();
        }
        
        public override void Draw()
        {
            if (map != null && map.visible) map.Draw();
            if (player1 != null && player1.visible) player1.Draw();
            if (mobi != null && mobi.visible) mobi.Draw();
        }

        public override void Start()
        {
            mobi = Menu.Instance;
            mobi.visible = true;
            mobi.Input = true;
        }

    } 
            
}
