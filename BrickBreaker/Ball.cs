﻿using System;
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
        public int bound = 60;

        public const int angleMultiplier = 5;

        public Ball(int _x, int _y, double _velocity, int _ballSize)
        {
            x = _x;
            y = _y;
            velocity = _velocity;
            size = _ballSize;
            vector = new Vector(Math.Cos(DegtoRad(30)), -Math.Sin(DegtoRad(30)));

        }

        public void setAngle(int newAngle)
        {
            vector = new Vector(Math.Cos(DegtoRad(newAngle)), -Math.Sin(DegtoRad(newAngle)));

        }

        public int right
        {
            get
            {
                return x + size;
            }
        }
        public int bottom
        {
            get
            {
                return y + size;
            }
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

                //make a boolean and nmake it track directions

            if (blockRec.IntersectsWith(ballRec))
            {
                bool comingFromBelow = vector.y < 0;
                bool comingFromRight = vector.x < 0;

                if (x <= block.right && comingFromRight)
                {
                    vector.x = Math.Abs(vector.x);
                }
                else if (this.right >= block.x && !comingFromRight)
                {
                    vector.x = -Math.Abs(vector.x);    
                }
                if (y <= block.bottom && comingFromBelow)
                { 
                    vector.y *= -1;
                    vector.x *= -1;
                }
                if (y >= block.y && !comingFromBelow)
                {
                    vector.y = - Math.Abs(vector.y);
                    vector.x *= -1;
                }
                return true;
            }
            return false;
        }

        public void PaddleCollision(Paddle paddle)
        {
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(paddle.x, paddle.y, paddle.width, paddle.height);

            if (ballRec.IntersectsWith(paddleRec))
            {
                if (this.bottom >= paddle.y) //Is the ball below the level of the paddle
                {
                    bool tooMuchRight = (x > paddle.right);
                    bool tooMuchLeft = (this.right < paddle.x);

                    if (!tooMuchLeft && !tooMuchRight)
                    {
                        int offset = (x - (size / 2)) - paddle.x;
                        int angle = Map(offset, 110, 30, paddle.width);
                        setAngle(angle);
                    }
                }
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
        public double DegtoRad(int angle)
        {
            return angle * (Math.PI / 180);
        }
        public static int Map(int offset, int largestAngle, int smallestAngle, int paddleW)
        {
            return Convert.ToInt32((((smallestAngle - largestAngle) / paddleW) * offset) + largestAngle);
        }
    }
}