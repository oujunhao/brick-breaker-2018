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
        public int width = 70;
        public int height = 25;

        public Color colour;

        public int x, y, hp;
        public string power;

        public Block()
        {
            colour = Color.Pink;
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
