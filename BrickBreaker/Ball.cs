using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace BrickBreaker
{
    public class Ball
    {
        public int x, y, size;
        public double velocity;
        public Vector vector;
        public Color colour;
        public int bound = 70;

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
                    //Ball hits Brick
                    var brickPlayer = new System.Windows.Media.MediaPlayer();
                    brickPlayer.Open(new Uri(Application.StartupPath + "/Resources/brick.wav"));
                    brickPlayer.Play();

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
                    //Ball hits paddle
                    var paddlePlayer = new System.Windows.Media.MediaPlayer();
                    paddlePlayer.Open(new Uri(Application.StartupPath + "/Resources.resx/Paddle.wav"));
                    paddlePlayer.Play();

                    bool tooMuchRight = true;
                    bool tooMuchLeft = true;

                    if (x < paddle.x + paddle.width)
                        tooMuchRight = false;
                   
                    if ((x + size) > paddle.x) 
                        tooMuchLeft = false;


                    if (!tooMuchLeft && !tooMuchRight)
                    {
                        int offset = (x + (size)) - paddle.x;
                        int angle = Map(offset, 90+bound, 90-bound, paddle.width+size);
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

                //Ball hits wall
                var wallPlayer = new System.Windows.Media.MediaPlayer();
                wallPlayer.Open(new Uri(Application.StartupPath + "/Resources.resx/Wall.wav"));
                wallPlayer.Play();
                wallPlayer.Stop();
               
            }

            // Collision with right wall
            int rightBound = (UC.Width - size);
            if (x >= rightBound)
            {
                x = Math.Abs(rightBound - (x - rightBound));
                vector.Multiply(new Vector(-1, 1));

                //Ball hits wall
                var wallPlayer = new System.Windows.Media.MediaPlayer();
                wallPlayer.Open(new Uri(Application.StartupPath + "/Resources.resx/Wall.wav"));
                wallPlayer.Play();
               
            }

            // Collision with top wall
            if (y <= 0)
            {
                y = Math.Abs(0 - y);
                vector.Multiply(new Vector(1, -1));

                //Ball hits wall
                var wallPlayer = new System.Windows.Media.MediaPlayer();
                wallPlayer.Open(new Uri(Application.StartupPath + "/Resources.resx/Wall.wav"));
                wallPlayer.Play();
                
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
        public static int Map(int offset, int largestAngle, int smallestAngle, int paddleW)
        {
            return Convert.ToInt32( ( ( (smallestAngle - largestAngle) / paddleW) * offset) + largestAngle);
        }
    }
}