using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public int x, y, size;
        public double velocity;
        public Vector vector;
        public Color colour;

        public Ball(int _x, int _y, double _velocity, int _ballSize)
        {
            x = _x;
            y = _y;
            velocity = _velocity;
            size = _ballSize;
            vector = new Vector(-1, -1);
        }

        public void Update(Paddle paddle, UserControl UC)
        {
            ChangePosition();
            ResolveCollisions(paddle, UC);
        }

        public void ChangePosition()
        {
            x += Convert.ToInt32(velocity * vector.x);
            y += Convert.ToInt32(velocity * vector.y);
        }

        public void ResolveCollisions(Paddle paddle, UserControl UC)
        {
            PaddleCollision(paddle);
            WallCollision(UC);
        }

        public bool BlockCollision(Block block)
        {
            Rectangle blockRec = new Rectangle(block.x, block.y, block.width, block.height);
            Rectangle ballRec = new Rectangle(x, y, size, size);

            if (blockRec.IntersectsWith(ballRec))
            {
                if (blockRec.IntersectsWith(ballRec))
                {
                    if (x <= (block.x + block.width))
                        vector.x = Math.Abs(vector.x);

                    if ((x + size) >= block.x)
                        vector.x = -Math.Abs(vector.x);

                    if (y <= (block.y + block.height))
                        vector.y = -vector.y;
                }
            }

            return blockRec.IntersectsWith(ballRec);
        }

        public void PaddleCollision(Paddle p)
        {
            if (y + size < p.y + p.height)
                return; // Ball won't collide with paddle

            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (ballRec.IntersectsWith(paddleRec))
            {
                //if (y + size >= p.y)
                //{
                //    // If the ball 
                //    if ((x) < p.x && (y + size) > p.y)
                //    {
                //        xSpeed = -Math.Abs(xSpeed);
                //        ySpeed = Math.Abs(ySpeed);
                //    }
                //    else if (x + size > (p.x + p.width) && (y + size) > p.y)
                //    {
                //        xSpeed = Math.Abs(xSpeed);
                //        ySpeed = -Math.Abs(ySpeed);
                //    }
                //    else
                //    {
                //        ySpeed *= -1;
                //    }
                //}
            }
        }

        public void WallCollision(UserControl UC)
        {
            // Collision with left wall
            if (x <= 0)
            {
                x = Math.Abs(0 - x);
                vector.Multiply(new Vector(-1, 1));
            }

            // Collision with right wall
            int rightBound = (UC.Width - size);
            if (x >= rightBound)
            {
                x = Math.Abs(rightBound - (x - rightBound));
                vector.Multiply(new Vector(-1, 1));
            }

            // Collision with top wall
            if (y <= 0)
            {
                y = Math.Abs(0 - y);
                vector.Multiply(new Vector(1, -1));
            }
        }

        public bool BottomCollision(UserControl UC)
        {
            Boolean didCollide = y >= UC.Height;
            return didCollide;
        }

    }
}
