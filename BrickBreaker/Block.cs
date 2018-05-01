using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    public class Block
    {
        public int width = 50;
        public int height = 25;

        public int x, y, hp;
        public string colour;

        public Block()
        {
            x = y = hp = 0;
            colour = "";
        }
    }
}
