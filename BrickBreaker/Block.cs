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

        public int x, y, hp, r, g, b;
        public string power;

        public Block()
        {
            x = y = hp = r = g = b = 0;
            power = "";
        }
    }
}
