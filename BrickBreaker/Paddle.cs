using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Paddle
    {
        public int x, y, width, height;
        int accel, maxSpeed;
        double friction;
        public double velocity;
        public Color colour;

        public Paddle(int _x, int _y, int _width, int _height, int _accel, double _friction, int _maxSpeed, Color _colour)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            accel = _accel;
            friction = _friction;
            maxSpeed = _maxSpeed;
            colour = _colour;
            velocity = 0;
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

        public void Accel(string axis, int direction)
        {
            if (axis == "x")
            {
                velocity += accel * direction;
            }
            else if (axis == "y")
            {
                throw new Exception("Not implemented");
            }
        }

        public void Move()
        {
            // Reduce velocity to maxSpeed
            if (Math.Abs(velocity) > maxSpeed)
            {
                if (velocity > 0) velocity = maxSpeed;
                else velocity = -maxSpeed;
            }

            // Move paddle
            x += Convert.ToInt32(velocity);

            // Apply friction
            if (velocity > 0) velocity -= friction;
            if (velocity < 0) velocity += friction;
            if (Math.Abs(velocity) < 1) velocity = 0;
        }

        public void WallCollision(UserControl UC)
        {
            if (x < 0) x = 0;
            if (x > UC.Width - width) x = UC.Width - width;
        }
    }
}