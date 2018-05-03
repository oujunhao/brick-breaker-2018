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

        public const int angleMultiplier = 5;

        public Ball(int _x, int _y, double _velocity, int _ballSize)
        {
            x = _x;
            y = _y;
            velocity = _velocity;
            size = _ballSize;
            vector = new Vector(-Math.Cos(DegtoRad(30)), Math.Sin(DegtoRad(-30)));

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

        public void PaddleCollision(Paddle paddle)
        {
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(paddle.x, paddle.y, paddle.width, paddle.height);

            if (ballRec.IntersectsWith(paddleRec))
            {
                if ((y + size) > paddle.y) //Is the ball below the level of the paddle
                {
                    bool tooMuchRight = true;
                    bool tooMuchLeft = true;

                    if (x < paddle.x + paddle.width)
                        tooMuchRight = false;
                   
                    if ((x + size) > paddle.x) 
                        tooMuchLeft = false;


                    if (!tooMuchLeft && !tooMuchRight)
                    {
                        int angle = (x + (1 / 2 * size)) - (paddle.x + (1 / 2 * paddle.width));
                        vector = new Vector(Math.Cos(DegtoRad(angle * angleMultiplier)), Math.Sin(DegtoRad(angle * angleMultiplier)));
                    }
                }

                //if (y + size >= p.y)
                //{
                //    // If the ball 
                //    if ((x) < p.x && (y + size) > p.y)
                //    {
                //        vector = new Vector(-0.707, -0.0707);
                //    }
                //    else if (x + size > (p.x + p.width) && (y + size) > p.y)
                //    {
                //        vector = new Vector(0.707, 0.0707);
                //    }
                //    else
                //    {
                //        //velocity *= -1;
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
        public double DegtoRad(int angle )
        {
            return angle * (Math.PI / 180);
        }
    }
}