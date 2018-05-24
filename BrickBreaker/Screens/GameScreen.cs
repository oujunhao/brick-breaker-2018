using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Xml;
using System.Threading;


namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        SoundPlayer LaserPlayer = new SoundPlayer(BrickBreaker.Properties.Resources.Laser);
        SoundPlayer BreakPlayer = new SoundPlayer(BrickBreaker.Properties.Resources.Exit);
        SoundPlayer WinPlayer = new SoundPlayer(BrickBreaker.Properties.Resources.Win);
        #region global values

        //player1 button control keys - DO NOT CHANGE
       public static Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceDown, escDown;
        public static bool flipControls, catchBall, catchBallShoot, bomb, startShoot, laser, gunShot, gunPaddle, updateChange;

        //sounds
        SoundPlayer BlockPlayer = new SoundPlayer(BrickBreaker.Properties.Resources.Brick);

        // Scoring
        public static int score;
        // Game values
        public static int lives, screenWidth, screenHeight, blockSpacing = 3, blockHeightSpacing = 15, bonus = 1,
            paddleStartWidth = 80, bombFlipCounter = 0, bombFlipFrequency = 20, gunHeight = 50,
            gunWidth = 20, gunCount = 0, catchRadious = 100, catchDegree = 30, catchTimer = 200, sizeBall = 20;

        // Paddle and Ball objects
        Paddle paddle;
        //public static Ball ball;
        public static List<Ball> balls = new List<Ball>();
        public static Random randGen = new Random();
        public static Font scoreFont = new Font("Roboto", 30);

        public static List<Level> levels = new List<Level>();
        public static int currentLevel = 0;

        //list of all capsules on screen
        public static List<Powerups> powerUps = new List<Powerups>();
        public static string[] powerupNames = new string[9]
            {
                "Long",
                "Bomb",
                "Catch",
                "Flip",
                "Life",
                "Laser",
                "Gun",
                "Multi",
                "Bonus"
            };

        public static PointF catchPaddlePoint, catchMovePoint;
        public static List<Rectangle> lasers = new List<Rectangle>();
        public static Rectangle gun = new Rectangle();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        public static SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);
        public static SolidBrush capBrush = new SolidBrush(Color.FromArgb(255, 0, 102));

        public static Image[] powerImages = new[]
        {
        Properties.Resources.Long,
        Properties.Resources.bomb1,
        Properties.Resources._catch,
        Properties.Resources.Flip,
        Properties.Resources.health,
        Properties.Resources.laser1,
        Properties.Resources.Gun,
        Properties.Resources.Multi,
        Properties.Resources.Bonus
        };

        Color[] blockColors = new[] {
            Color.FromArgb(43, 134, 194),//1 HP
            Color.FromArgb(37, 117, 170),//2 HP
            Color.FromArgb(31, 96, 139),//3 HP
            Color.FromArgb(19, 60, 86),//4 HP
            Color.FromArgb(12, 39, 56)//5 HP
            };
        Color[] blockBoarders = new[] {
            Color.FromArgb(49, 152, 220),//1 HP
            Color.FromArgb(31, 98, 142),//2 HP
            Color.FromArgb(26, 80, 116),//3 HP
            Color.FromArgb(23, 71, 102),//4 HP
            Color.FromArgb(17, 54, 78)//5 HP
            };
        #endregion

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {
            // Load level
            GetLevels();
            //Scoring
            // SERVICE IS THROWING JSON ERROR
            //Form1.service.startGame();
            score = 0;

            //set life counter
            lives = 3;

            gameResetPowerup();
            powerUps.Clear();

            screenWidth = this.Width;
            screenHeight = this.Height;

            //set all button presses to false.
            leftArrowDown = downArrowDown = rightArrowDown = upArrowDown = false;

            // setup starting paddle values and create paddle object
            int paddleHeight = 20;
            int paddleX = ((this.Width / 2) - (paddleStartWidth / 2));
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddleMaxSpeed = 10;
            int paddleWidth = 80;
            int paddleAccel = 3;
            double paddleFriction = 1.2;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleAccel, paddleFriction, paddleMaxSpeed, Color.White);

            // setup starting ball values
            int ballX = ((this.Width / 2) - 10);
            int ballY = (this.Height - paddle.height) - 80;

            // Creates a new ball
            double ballVelocity = 0;
            int ballSize = sizeBall;
            balls.Add(new Ball(ballX, ballY, ballVelocity, ballSize));

            UpdateBlockColors();

            catchPaddlePoint = new PointF(balls[0].x + balls[0].size / 2, balls[0].y + balls[0].size / 2);
            catchBallShoot = true;
            startShoot = true;

            // start the game engine loop
            gameTimer.Enabled = true;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rc, Color.FromArgb(255, 55, 64, 105), Color.FromArgb(255, 32, 14, 48), 90F))
            {
                e.Graphics.FillRectangle(brush, rc);
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (catchBallShoot)
                    {
                        if (catchDegree < 150)
                            catchDegree += 10;
                    }
                    else
                    {
                        if (flipControls)
                        {
                            rightArrowDown = true;
                        }
                        else
                        {
                            leftArrowDown = true;
                        }
                    }
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    if (catchBallShoot)
                    {
                        if (catchDegree > 30)
                            catchDegree -= 10;
                    }
                    else
                    {
                        if (flipControls)
                        {
                            leftArrowDown = true;
                        }
                        else
                        {
                            rightArrowDown = true;
                        }
                    }
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    if (startShoot)
                    {
                        balls[0].velocity = 7;
                        startShoot = false;
                        catchTimer = 200;
                    }
                    if (catchBallShoot)
                    {
                        balls[0].angle = catchDegree;
                        balls[0].setAngle(catchDegree);
                        catchBallShoot = false;
                        catchTimer = 200;
                    }
                    if (laser)
                    {
                        AddLaserShots();
                    }
                    if (gunPaddle && gunCount < 3 && gunShot == false)
                    {
                        setGun();
                        gunShot = true;
                        gunCount++;
                    }
                    break;
                case Keys.Escape:
                    escDown = true;

                    if (gameTimer.Enabled)
                    {
                        gameTimer.Stop();
                        rightArrowDown = leftArrowDown = false;
                        DialogResult result = PauseForm.Show();
                        if (result == DialogResult.Cancel)
                        {
                            gameTimer.Enabled = true;
                        }

                        else if (result == DialogResult.Abort)
                        {
                            Application.Exit();
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        public void AddLaserShots()
        {
            if (lasers.Count < 3)
            {
                lasers.Add(new Rectangle(paddle.x + paddle.width * 1 / 4, paddle.y, 4, paddle.height * 2));
                LaserPlayer.Play();
                lasers.Add(new Rectangle(paddle.x + paddle.width * 3 / 4, paddle.y, 4, paddle.height * 2));
                LaserPlayer.Play();
            }
        }

        public void setGun()
        {
            gun = new Rectangle(paddle.x + paddle.width / 2 - gunWidth / 2, paddle.y, gunWidth, gunHeight);
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (flipControls)
                    {
                        rightArrowDown = false;
                    }
                    else
                    {
                        leftArrowDown = false;
                    }
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    if (flipControls)
                    {
                        leftArrowDown = false;
                    }
                    else
                    {
                        rightArrowDown = false;
                    }
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                case Keys.Escape:
                    escDown = false;
                    break;
                default:
                    break;
            }
        }

        public void findCatchPoints()
        {
            double rad = catchDegree * (Math.PI / 180);

            catchMovePoint = new PointF(
                Convert.ToInt32(catchPaddlePoint.X + (Math.Cos(rad)) * catchRadious),
                Convert.ToInt32(catchPaddlePoint.Y - (Math.Sin(rad) * catchRadious))
                );
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (catchBallShoot == false)
            {
                // Move the paddle
                if (leftArrowDown) paddle.Accel("x", -1);
                if (rightArrowDown) paddle.Accel("x", 1);
                paddle.Move();
                paddle.WallCollision(this);
            }

            if(startShoot || catchBallShoot)
            {
                catchTimer--;
                if (catchTimer == 0)
                {
                    balls[0].angle = catchDegree;
                    balls[0].setAngle(catchDegree);
                    balls[0].velocity = 7;
                    catchBallShoot = false;
                    startShoot = false;
                    catchTimer = 200;
                }
            }

            for (int i = 0; i < balls.Count(); i++)
            {
                // Moves ball
                balls[i].Update(paddle, this);

                // Check if ball has collided with any blocks
                BlockCollision(balls[i]);

                // Check for ball hitting bottom of screen
                if (balls[i].BottomCollision(this) && balls.Count() == 1)
                {
                    lives--;
                    gameResetPowerup();
                    paddle.width = paddleStartWidth;
                    UpdateFormImage();

                    balls.RemoveAt(i);

                    // Moves the ball back to origin
                    paddle.x = (this.Width / 2 - paddle.width / 2);
                    balls.Add(new Ball(paddle.x - sizeBall / 2 + paddle.width / 2,
                        paddle.y - sizeBall, 0, sizeBall));

                    catchPaddlePoint = new PointF(balls[0].x + sizeBall / 2, balls[0].y + sizeBall / 2);
                    findCatchPoints();
                    startShoot = true;
                    catchBallShoot = true;

                    if (lives == 0)
                    {
                        gameTimer.Enabled = false;

                        OnEnd();
                    }
                }
                else if (balls[i].BottomCollision(this))
                {
                    balls.RemoveAt(i);
                }
            }

            if (catchBallShoot)
            {
                findCatchPoints();
            }

            for (int i = 0; i < lasers.Count; i++)
            {
                lasers[i] = new Rectangle(lasers[i].X, lasers[i].Y - 7, lasers[i].Width, lasers[i].Height);
                LaserBlockCheck(lasers[i], i);
            }

            if (gunShot)
            {
                foreach (Block b in levels[currentLevel].blocks.Reverse<Block>())
                {
                    Rectangle block = new Rectangle(b.x, b.y, b.width, b.height);

                    if (gun.IntersectsWith(block))
                    {
                        b.hp = 0;
                        DestroyBlock(b);
                        score += 50 * bonus;
                        setGun();
                        gunShot = false;
                        UpdateFormImage();
                    }
                }

                if (gun.Y + gun.Height <= 0)
                {
                    setGun();
                    gunShot = false;
                }

                if (gunShot)
                {
                    gun = new Rectangle(gun.X, gun.Y - 8, gunWidth, gunHeight);
                }
            }

            if (bomb)
            {
                if (bombFlipCounter == bombFlipFrequency)
                {
                    bombFlipCounter = 0;
                    if (ballBrush.Color == Color.White)
                    {
                        ballBrush.Color = capBrush.Color;
                    }
                    else
                    {
                        ballBrush.Color = Color.White;
                    }
                }
                else
                {
                    bombFlipCounter++;
                }
            }

            //Move each capsule and
            for (int i = 0; i < powerUps.Count; i++)
            {
                powerUps[i].moveCapsule();
                powerUps[i].checkCapCollision(ref paddle);

                if (powerUps.Count > 0)
                {
                    try { powerUps[i].checkCapOffScreen(); }
                    catch { powerUps[0].checkCapOffScreen(); }
                }
            }

            if(updateChange)
            {
                UpdateFormImage();
                updateChange = false;
            }

            //redraw the screen
            Refresh();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
        }

        public static void capResetPowerup()
        {
            catchBall = false;
            catchBallShoot = false;
            balls[0].velocity = 7;
            flipControls = false;
            ballBrush.Color = Color.White;
            laser = false;
            bonus = 1;
            gunCount = 0;
            gunPaddle = false;
        }

        public static void gameResetPowerup()
        {
            catchBall = false;
            flipControls = false;
            ballBrush.Color = Color.White;
            laser = false;
            bonus = 1;
            gunCount = 0;
            gunPaddle = false;
            bomb = false;
        }

        public void LaserBlockCheck(Rectangle laser, int index)
        {
            foreach (Block b in levels[currentLevel].blocks.Reverse<Block>())
            {
                if (laser.X >= b.x && laser.X <= b.x + b.width
                    && laser.Y <= b.y + b.height && b.hp != 100)
                {
                    b.hp -= 1;
                    if (b.hp <= 0) DestroyBlock(b);
                    score += 50 * bonus;
                    UpdateFormImage();
                    lasers.RemoveAt(index);
                    break;
                }
            }
            UpdateBlockColors();

            lasers.RemoveAll(b => b.Y <= 0);
        }

        public void OnEnd()
        {
            // End scoring
            //Form1.service.endGame(score);


            //Game end sound
            var endPlayer = new System.Windows.Media.MediaPlayer();
            endPlayer.Open(new Uri(Application.StartupPath + "/Resources/End.wav"));
            endPlayer.Play();

            // instance of game over
            GameOver go = new GameOver();

            //close game screen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            // centre screen
            go.Location = new Point((f.Width - go.Width) / 2, (f.Height - go.Height) / 2);

            //open game over
            f.Controls.Add(go);
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws paddle
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            //Draw score
            //e.Graphics.DrawString(score.ToString(), new Font("Calibri", 12), capBrush, 10, this.Height - 20);

            if (catchBallShoot)
            {
                e.Graphics.DrawLine(Pens.White, catchPaddlePoint, catchMovePoint);
            }

            if (gunShot)
            {
                e.Graphics.FillRectangle(capBrush, gun);
                e.Graphics.DrawRectangle(Pens.Red, gun);
            }

            if (gunPaddle)
            {
                e.Graphics.FillRectangle(capBrush, paddle.x + paddle.width / 2 - gunWidth / 2, paddle.y, gunWidth, paddle.height);
            }

            if (laser)
            {
                e.Graphics.FillRectangle(Brushes.Red, paddle.x + paddle.width / 4 - 2, paddle.y, 4, paddle.height);
                e.Graphics.FillRectangle(Brushes.Red, paddle.x + paddle.width * 3 / 4 - 2, paddle.y, 4, paddle.height);
            }

            // Draws blocks
            foreach (Block b in levels[currentLevel].blocks)
            {
                blockBrush.Color = b.outlineColor;
                e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
                //change colour of brush depending on block
                blockBrush.Color = b.colour;
                e.Graphics.FillRectangle(blockBrush, b.x + 3, b.y + 3, b.width - 6, b.height - 6);
            }

            foreach (Rectangle beam in lasers)
            {
                e.Graphics.FillRectangle(capBrush, beam);
                e.Graphics.DrawRectangle(Pens.Red, beam);
            }

            foreach (Powerups p in powerUps)
            {
                e.Graphics.DrawImage(p.drawIcon, p.x, p.y, p.CAP_SIZE, p.CAP_SIZE);
                //e.Graphics.DrawString(p.capType, new Font("Calibri", 12), capBrush, p.x, p.y - 15);
                //e.Graphics.FillEllipse(new SolidBrush(p.drawColor), p.x, p.y, p.CAP_SIZE, p.CAP_SIZE);
            }

            foreach (Ball ball in balls)
            {
                // Draws balls
                e.Graphics.FillEllipse(ballBrush, ball.x, ball.y, ball.size, ball.size);
            }
        }


        public Color getBrickColour(int hp)
        {
            switch (hp)
            {
                case 1:
                    return Color.FromArgb(255, 43, 134, 194);
                case 2:
                    return Color.FromArgb(255, 37, 117, 170);
                case 3:
                    return Color.FromArgb(255, 31, 96, 139);
                case 4:
                    return Color.FromArgb(255, 31, 96, 139);
                case 5:
                    return Color.FromArgb(255, 31, 96, 139);
                default:
                    return Color.FromArgb(255, 255, 255, 255);
            }
        }

        public void GetLevels()
        {
            using (XmlReader reader = XmlReader.Create("Resources/BBLevels.xml"))
            {
                int levelIndex = 0;
                levels.Add(new Level());
                reader.ReadToFollowing("level");

                while (reader.Read())
                {
                    if (reader.Name != "level")
                    {
                        if (reader.NodeType == XmlNodeType.Text)
                        {
                            Block b = new Block();

                            b.x = Convert.ToInt16(reader.ReadString());

                            reader.ReadToNextSibling("y");
                            b.y = Convert.ToInt16(reader.ReadString());

                            reader.ReadToNextSibling("hp");
                            b.hp = Convert.ToInt32(reader.ReadString());

                            reader.ReadToNextSibling("power");
                            b.power = reader.ReadString();

                            levels[levelIndex].blocks.Add(b);
                        }
                    }
                    else
                    {
                        levelIndex++;
                        levels.Add(new Level());
                        reader.ReadToFollowing("level");
                    }
                }
            }
        }

        //TODO: Add update score method and change update block colors to include all blocks
        public void UpdateFormImage()
        {
            Form f = FindForm();
            Graphics g = f.CreateGraphics();
            int barHeight = 50, lifeSpacing = 10, lifeDiameter = 30;

            string drawScore = score.ToString();
            float scoreWordLength = g.MeasureString("SCORE: ", scoreFont).Width;
            float scoreNumberLength = g.MeasureString(drawScore, scoreFont).Width;

            Rectangle backRect2 = new Rectangle(this.Location.X, this.Location.Y - barHeight, this.Width, barHeight);

            g.FillRectangle(Brushes.Black, backRect2);
            g.DrawString("SCORE:", scoreFont, Brushes.White, this.Location.X + this.Width - scoreWordLength - scoreNumberLength - 10, this.Location.Y - barHeight);
            g.DrawString(drawScore, scoreFont, capBrush, this.Location.X + this.Width - scoreNumberLength - 10, this.Location.Y - barHeight);

            for (int i = 0; i < lives; i++)
            {
                g.FillEllipse(capBrush, this.Location.X + (i * lifeDiameter) + (i * lifeSpacing) + lifeSpacing, this.Location.Y - barHeight / 2 - lifeDiameter / 2, lifeDiameter, lifeDiameter);
            }
        }

        public void UpdateBlockColors()
        {
            foreach (Block b in levels[currentLevel].blocks.Reverse<Block>())
            {
                int index = Convert.ToInt32(b.hp);

                if (b.hp > 0 && b.hp < 6)
                {
                    b.colour = blockColors[index - 1];
                    b.outlineColor = blockBoarders[index - 1];
                }
                else
                {
                    b.colour = Color.Gray;
                    b.outlineColor = Color.Silver;
                }
            }
        }

        public void BlockCollision(Ball ball)
        {
            foreach (Block b in levels[currentLevel].blocks.Reverse<Block>())
            {
                if (ball.BlockCollision(b))
                {
                    BlockPlayer.Play();
                    if (b.hp > 0 && b.hp != 100)
                    {
                        b.hp--;
                    }
                    if (b.hp <= 0)
                    {
                        DestroyBlock(b);
                        score += 100 * bonus;
                        UpdateFormImage();
                    }
                }
            }
            UpdateBlockColors();
        }
        public void DestroyBlock(Block block)
        {
            levels[currentLevel].blocks.RemoveAll(b => b.hp == 0);
            if (levels[currentLevel].blocks.Count < 1)
            {
                currentLevel++;
                gameResetPowerup();
                powerUps.Clear();
                //reset positions of ball and paddle
                balls[0].x = ((this.Width / 2) - 10);
                balls[0].y = (this.Height - paddle.height) - 80;
                paddle.x = ((this.Width / 2) - (paddleStartWidth / 2));
                paddle.y = (this.Height - 20) - 60;
                BreakPlayer.Play();
                UpdateBlockColors();
                this.Refresh();
                //display new level message
                Font f = new Font("Arial", 40, FontStyle.Bold);
                Graphics a = this.CreateGraphics();
                a.DrawString("Level " + (currentLevel + 1), f, capBrush, 300, 240);
                Thread.Sleep(2000);
                balls[0].velocity = 0;
                catchPaddlePoint = new PointF(balls[0].x + balls[0].size / 2, balls[0].y + balls[0].size / 2);
                catchBallShoot = true;
                startShoot = true;
                WinPlayer.Play();

                this.Refresh();


                if (currentLevel == levels.Count - 1)
                {
                    gameTimer.Enabled = false;
                    OnEnd();
                }
            }

            //set focus
            this.Focus();
        }
    }
}