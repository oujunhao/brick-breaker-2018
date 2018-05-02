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

        public int x, y, hp, colour;
        public string power;

        public Block()
        {
            x = y = hp = colour = 0;
            power = "";
        }
    }
}
