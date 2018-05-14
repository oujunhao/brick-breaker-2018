﻿using System;
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

namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys - DO NOT CHANGE
        public static Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceDown;
        public static bool flipControls, catchBall, bomb;

        // Scoring
        int score;
        // Game values
        public static int lives, screenWidth, screenHeight, blockSpacing = 3, bonus = 1;
        public static int paddleStartWidth = 80, bombFlipCounter = 0, bombFlipFrequency = 20;

        // Paddle and Ball objects
        Paddle paddle;
        Ball ball;
        List<Region> capRegions = new List<Region>();
        // GraphicsPath capShape;

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
        int catchRadious = 100, catchDegree = 90;

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        public static SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);
        SolidBrush capBrush = new SolidBrush(Color.Green);

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
            //Form1.service.startGame();
            score = 0;

            //set life counter
            lives = 30;

            removePastPowerups();
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
            int paddleAccel = 3;
            int paddleWidth = 80;
            double paddleFriction = 1.2;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleAccel, paddleFriction, paddleMaxSpeed, Color.White);

            // setup starting ball values
            int ballX = ((this.Width / 2) - 10);
            int ballY = (this.Height - paddle.height) - 80;

            // Creates a new ball
            double ballVelocity = 7;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, ballVelocity, ballSize);

            catchPaddlePoint = new PointF(paddle.x + paddle.width / 2, paddle.y);

            // start the game engine loop
            gameTimer.Enabled = true;
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (catchBall)
                    {
                        if (catchDegree < 150)
                            catchDegree += 5;
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
                    if (catchBall)
                    {
                        if (catchDegree > 30)
                            catchDegree -= 5;
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
                    if (catchBall)
                    {
                        //shoot
                        //use deflection physics with current catchDegree
                    }
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
                default:
                    break;
            }
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
                default:
                    break;
            }
        }

        public void findCatchPoints()
        {
            //this will removed so that the line will come from the ball

            catchPaddlePoint = new PointF(paddle.x + paddle.width / 2, paddle.y);

            double rad = catchDegree * (Math.PI / 180);

            catchMovePoint = new PointF(
                Convert.ToInt32(catchPaddlePoint.X + (Math.Cos(rad)) * catchRadious),
                Convert.ToInt32(catchPaddlePoint.Y - (Math.Sin(rad) * catchRadious))
                );
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Move the paddle
            if (leftArrowDown) paddle.Accel("x", -1);
            if (rightArrowDown) paddle.Accel("x", 1);
            paddle.Move();
            paddle.WallCollision(this);

            // Moves ball
            ball.Update(paddle, this);

            // Check if ball has collided with any blocks
            BlockCollision();


            // Check for ball hitting bottom of screen
            if (ball.BottomCollision(this))
            {
                lives--;
                removePastPowerups();
                paddle.width = paddleStartWidth;

                // Moves the ball back to origin
                ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                ball.y = (this.Height - paddle.height) - 85;

                if (lives == 0)
                {
                    gameTimer.Enabled = false;

                    OnEnd();
                }
            }

            if (catchBall)
            {
                findCatchPoints();
            }

            if (bomb)
            {
                if (bombFlipCounter == bombFlipFrequency)
                {
                    bombFlipCounter = 0;
                    if (ballBrush.Color == Color.White)
                    {
                        ballBrush.Color = Color.FromArgb(255, 0, 102);
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
                    powerUps[i].checkCapOffScreen();
                }
            }

            UpdateRegions();

            //redraw the screen
            Refresh();
        }

        public void UpdateRegions()
        {
            int cornerCutSquare = 30;
            capRegions.Clear();
            foreach (Powerups p in powerUps)
            {
                //Rectangle rect = new Rectangle(p.x, p.y, p.CAP_WIDTH, p.CAP_HEIGHT);
                GraphicsPath drawPath = new GraphicsPath();
                drawPath.AddArc(p.x, p.y, cornerCutSquare, cornerCutSquare, 90, 90);//top left
                drawPath.AddArc(p.x, p.y + p.CAP_HEIGHT - cornerCutSquare,
                    cornerCutSquare, cornerCutSquare, 180, 90);//bottom left
                drawPath.AddArc(p.x + p.CAP_WIDTH - cornerCutSquare, p.y + p.CAP_HEIGHT - cornerCutSquare,
                    cornerCutSquare, cornerCutSquare, 270, 90);//bottom right
                drawPath.AddArc(p.x + p.CAP_WIDTH - cornerCutSquare, p.y,
                    cornerCutSquare, cornerCutSquare, 0, 90);//top right

                capRegions.Add(new Region(drawPath));
            }
        }

        public static void removePastPowerups()
        {
            catchBall = false;
            flipControls = false;
            bomb = false;
            ballBrush.Color = Color.White;
        }

        public void OnEnd()
        {
            // End scoring
            //            Form1.service.endGame(score);

            // Goes to the game over screen
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();

            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);

            form.Controls.Add(ps);
            form.Controls.Remove(this);
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws paddle
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            if (catchBall)
            {
                e.Graphics.DrawLine(Pens.White, catchPaddlePoint, catchMovePoint);
            }

            // Draws blocks
            foreach (Block b in levels[currentLevel].blocks)
            {
                //change colour of brush depending on block
                blockBrush.Color = b.colour;
                e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
            }


            //Draws capsules
            //foreach(Powerups p in powerUps)
            //{
            //    e.Graphics.FillRectangle(Brushes.Green, p.x, p.y, p.CAP_WIDTH, p.CAP_HEIGHT);
            //}

            foreach (Region capRegion in capRegions)
            {
                e.Graphics.FillRegion(Brushes.Green, capRegion);
            }

            // Draws balls
            e.Graphics.FillEllipse(ballBrush, ball.x, ball.y, ball.size, ball.size);
        }

        public void GetLevels()
        {
            using (XmlReader reader = XmlReader.Create("BBLevels.xml"))
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

        public void BlockCollision()
        {
            foreach (Block b in levels[currentLevel].blocks)
            {
                if (ball.BlockCollision(b))
                {
                    if (b.hp > 0)
                    {
                        b.hp--;
                    }
                    else if (b.hp == 0)
                    {
                        levels[currentLevel].blocks.Remove(b);

                        if (levels[currentLevel].blocks.Count < 1)
                        {
                            currentLevel++;

                            if (currentLevel == levels.Count - 1)
                            {
                                gameTimer.Enabled = false;
                                OnEnd();
                            }
                        }
                        break;
                    }
                }
            }
        }
    }
}