using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace BrickBreaker
{
    public class Ball
    {
        SoundPlayer BallPlayer = new SoundPlayer(BrickBreaker.Properties.Resources.Ball);
        SoundPlayer WallPlayer = new SoundPlayer(BrickBreaker.Properties.Resources.Wall);
        public int x, y, size, angle;
        public double velocity;
        public Vector vector;
        public Color colour;
        public int bound = 60;

        const int angleMultiplier = 5;

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

        public void setAngle(int catchAngle)
        {
            vector = new Vector(Math.Cos(DegtoRad(catchAngle)), -Math.Sin(DegtoRad(catchAngle)));
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
                Random rand = new Random();
                int randCheck = rand.Next(1, 5);
                if (randCheck == 1 && block.hp != 100)
                {
                    Powerups newPowerUp = new Powerups(ballRec);
                    GameScreen.powerUps.Add(newPowerUp);
                }

                if (GameScreen.bomb)
                {
                    foreach (Block b in GameScreen.levels[GameScreen.currentLevel].blocks)
                    {
                        if (block.x == b.x + b.width + GameScreen.blockSpacing && block.y == b.y || //Block to the right
                           block.x == b.x - b.width - GameScreen.blockSpacing && block.y == b.y ||// || //Block to the left
                           block.y == b.y + b.height + GameScreen.blockHeightSpacing && block.x == b.x || //Block below
                           block.y == b.y - b.height - GameScreen.blockHeightSpacing && block.x == b.x)//Block above
                        {
                            b.hp--;
                        }
                    }
                    block.hp = 0;
                    GameScreen.bomb = false;
                    GameScreen.ballBrush.Color = Color.White;
                }
                //Sound for ballhits Brick
                BallPlayer.Play();

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
                if (this.y >= block.y && !comingFromBelow)
                {
                    vector.y = Math.Abs(vector.y);
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
                if (GameScreen.catchBall)
                {
                    vector.x = 0;
                    vector.y = 0;
                    GameScreen.balls[0].y = paddle.y - GameScreen.balls[0].size;
                    GameScreen.catchBallShoot = true;
                    GameScreen.catchPaddlePoint.X = x + size / 2;
                    GameScreen.catchPaddlePoint.Y = y + size / 2;

                    paddle.velocity = 0;
                }

                if (this.bottom > paddle.y) //Is the ball below the level of the paddle
                {
                    //Ball hits paddle
                    BallPlayer.Play();

                    if (this.bottom >= paddle.y) //Is the ball below the level of the paddle

                    {
                        bool tooMuchRight = x > paddle.right;
                        bool tooMuchLeft = this.right < paddle.x;

                        if (!tooMuchLeft && !tooMuchRight)
                        {
                            int offset = (x - (size / 2)) - paddle.x;
                            angle = Map(offset, 110, 30, paddle.width);
                            setAngle(angle);
                        }
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
                vector.x *= -1;

                //Ball hits wall
                WallPlayer.Play();

            }

            // Collision with right wall
            int rightBound = (UC.Width - size);
            if (x >= rightBound)
            {
                x = Math.Abs(rightBound - (x - rightBound));
                vector.x *= -1;

                //Ball hits wall
                WallPlayer.Play();

            }

            // Collision with top wall
            if (y <= 0)
            {
                y = Math.Abs(0 - y);
                vector.Multiply(new Vector(1, -1));

                //Ball hits wall
                WallPlayer.Play();

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