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

            if (blockRec.IntersectsWith(ballRec))
            {
                //int randCheck = rand.Next(1, 11);
                //if (randCheck == 1)
                //{
                Powerups newPowerUp = new Powerups(ballRec);
                GameScreen.powerUps.Add(newPowerUp);
                //}

                if (GameScreen.bomb)
                {
                    /*
                    foreach (Block block in GameScreen.blocks)
                    {
                        if(block.x == b.x + b.width + GameScreen.blockSpacing && block.y == b.y || //Block to the right
                           block.x == b.x - b.width - GameScreen.blockSpacing && block.y == b.y || //Block to the left
                           block.y == b.y + b.height + GameScreen.blockSpacing && block.x == b.x || //Block below
                           block.y == b.y - b.height - GameScreen.blockSpacing && block.x == b.x)//Block above
                        {
                            block.hp--;
                        }
                    }
                    */
                    GameScreen.bomb = false;
                    GameScreen.ballBrush.Color = Color.White;
                }
              
                if (x <= block.right)
                    vector.x = Math.Abs(vector.x);

                if (this.right >= block.x)
                    vector.x = -Math.Abs(vector.x);

                if (y <= block.bottom)
                    vector.y *= -1;
                // Test which vector(s) we need to flip
                bool flipX = (this.right >= block.x || this.x <= block.right);
                bool flipY = (this.y <= block.bottom || this.bottom >= block.y);

                //if (flipX)
                //    vector.x *= -1;
                //else if (flipY)
                //    vector.y *= -1;
            }
            return blockRec.IntersectsWith(ballRec);
        }

        public void PaddleCollision(Paddle paddle)
        {
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(paddle.x, paddle.y, paddle.width, paddle.height);

            if (ballRec.IntersectsWith(paddleRec))
            {
                if(GameScreen.catchBall)
                {
                    //ball x vector = 0
                    //ball y vector = 0
                    //GameScreen.catchPaddlePoint.X = x + size / 2;
                    //GameScreen.catchPaddlePoint.Y = y + size / 2;
                }

                if (this.bottom >= paddle.y) //Is the ball below the level of the paddle

                {
                    bool tooMuchRight = (x > paddle.right);
                    bool tooMuchLeft = (this.right < paddle.x);

                    if (!tooMuchLeft && !tooMuchRight)
                    {
                        int offset = (x - (size / 2)) - paddle.x;
                        int angle = Map(offset, 110, 30, paddle.width);
                        vector = new Vector(Math.Cos(DegtoRad(angle)), -Math.Sin(DegtoRad(angle)));
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