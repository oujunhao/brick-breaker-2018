using System.Drawing;

namespace BrickBreaker
{
    public class Paddle
    {
        public int x, y, width, height, speed;
        public Color colour;

        public Paddle(int _x, int _y, int _width, int _height, int _speed, Color _colour)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            speed = _speed;
            colour = _colour;
        }

        public void Move(string direction)
        {
            if (direction == "left")
            {
                x -= speed;
            }
            if (direction == "right")
            {
                x += speed;
            }
        }
    }
}
