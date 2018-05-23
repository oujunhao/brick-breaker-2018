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

        public Color colour;

        public int x, y, hp;
        public string power;

        public Block()
        {
            x = y = hp = 0;
            colour = Color.Pink;
            power = "";
        }

        public int right
        {
            get
            {
                return x + width;
            }
        }
        public int bottom
        {
            get
            {
                return y + height;
            }
        }
    }
}
