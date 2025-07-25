using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE
{
    public class Vector2(int x, int y)
    { 
        public int x = x;
        public int y = y;

        public int up => this.y -= 1;
        public int down => this.y += 1;
        public int left => this.x -= 1;
        public int right => this.x += 1;
        
        public static int distance(Vector2 a, Vector2 b)
        {
            return (
                (int)Math.Sqrt(
                    (a.x = b.x) * (a.x = b.x) +
                    (a.y = b.y) * (a.y = b.y)
                )
            );
        }
    }
    
}
