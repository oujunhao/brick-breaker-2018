using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public int x, y, xSpeed, ySpeed, size;
        public Color colour;

        public static Random rand = new Random();

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed, int _ballSize)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            size = _ballSize;
               
        }

        public void Move()
        {
            x = x + xSpeed;
            y = y + ySpeed;
        }

        public bool BlockCollision(Block b)
        {
            Rectangle blockRec = new Rectangle(b.x, b.y, b.width, b.height);
            Rectangle ballRec = new Rectangle(x, y, size, size);

            if (blockRec.IntersectsWith(ballRec))
            {
                if (x <= (b.x + b.width))
                    xSpeed = Math.Abs(xSpeed);

                if ((x + size) >= b.x)
                    xSpeed = -Math.Abs(xSpeed);

                if (y <= (b.y + b.height))
                    ySpeed = -ySpeed;


                //int randCheck = rand.Next(1, 11);
                //if (randCheck == 1)
                //{
                    Powerups newPowerUp = new Powerups(ballRec);
                    GameScreen.powerUps.Add(newPowerUp);
                //}               
            }

            return blockRec.IntersectsWith(ballRec);         
        }

        public void PaddleCollision(Paddle p, bool pMovingLeft, bool pMovingRight)
        {
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (ballRec.IntersectsWith(paddleRec))
            {
                if (y + size >= p.y)
                {
                    // If the ball 
                    if ((x) < p.x && (y + size) > p.y)
                    {
                        xSpeed = -Math.Abs(xSpeed);
                        ySpeed = Math.Abs(ySpeed);
                    }
                    else if (x + size > (p.x + p.width) && (y + size) > p.y)
                    {
                        xSpeed = Math.Abs(xSpeed);
                        ySpeed = -Math.Abs(ySpeed);
                    }
                    else
                    {
                        ySpeed *= -1;
                    }
                }

                if (pMovingLeft)
                    xSpeed = -Math.Abs(xSpeed);
                else if (pMovingRight)
                    xSpeed = Math.Abs(xSpeed);
            }
        }

        public void WallCollision(UserControl UC)
        {
            // Collision with left wall
            if (x <= 0)
            {
                xSpeed *= -1;
            }
            // Collision with right wall
            if (x >= (UC.Width - size))
            {
                xSpeed *= -1;
            }
            // Collision with top wall
            if (y <= 2)
            {
                ySpeed *= -1;
            }
        }

        public bool BottomCollision(UserControl UC)
        {
            Boolean didCollide = false;

            if (y >= UC.Height)
            {
                didCollide = true;
            }

            return didCollide;
        }
    }
}
