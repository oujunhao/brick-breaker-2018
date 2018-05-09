using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    public class Powerups
    {
        //Constants
        Random randGen = new Random();
        const int LONG_PADDLE_GAIN = 40, CAP_SPEED = 1;
        public int CAP_HEIGHT = 30, CAP_WIDTH = 60;

        //Varriables
        public string capType;
        public int x = 0, y = 0;

        //Paddle sent from the game screen
        Paddle paddle;

        /// <summary>
        /// Makes a new capsule appear on screen and adds it to the list of screen capsules 
        /// </summary>
        /// <param name="brickPosition">Spawns the capsule at the position of the brick</param>
        public Powerups(Rectangle brickPosition)
        {
            //capType = GameScreen.powerupNames[randGen.Next(0, 9)];
            capType = "Catch";

            x = brickPosition.X;
            y = brickPosition.Y;        
        }

        /// <summary>
        /// Moves all capsules down
        /// </summary>
        public void moveCapsule()
        {
            y += CAP_SPEED;
        }

        /// <summary>
        /// Checks to see if the capsule is moving off the screen and removes it
        /// </summary>
        public void checkCapOffScreen()
        {
            if(y + CAP_HEIGHT == GameScreen.screenHeight)
            {
                resetPowerupsList();
            }
        }

        /// <summary>
        /// Checks if there is a collision between any of the capsules on screen and the paddle
        /// </summary>
        /// <param name="currentPad"> The paddle</param>
        public void checkCapCollision(ref Paddle currentPad)
        {
            paddle = currentPad;

            if(y + CAP_HEIGHT >= paddle.y &&
                y <= paddle.y + paddle.height &&
                x + CAP_WIDTH >= paddle.x &&
                x <= paddle.x + paddle.width)
            {
                GameScreen.removePastPowerups();
                paddle.width = GameScreen.paddleStartWidth;

                usePowerUp(ref currentPad);
                resetPowerupsList();
            }
        }

        /// <summary>
        /// Removes current capsule, and fixes list so there are no holes
        /// </summary>
        public void resetPowerupsList()
        {
            //This is the index of the current powerup in the list of powerups
            int capIndex = 0;

            foreach (Powerups p in GameScreen.powerUps)
            {
                //Finds the index based on the positions of all powerups
                if (p.x == x && p.y == y)
                {
                    capIndex = GameScreen.powerUps.IndexOf(p);
                }
            }

            //GameScreen.powerUps.RemoveAt(capIndex);

            //Starting at the current powerup shift all powerups below it on the list up one such that the current
            //powerup is removed (this will mean the final power up will be a duplicate of the second last one)
            for(int i = capIndex; i < GameScreen.powerUps.Count-1; i++)
            {
                GameScreen.powerUps[i] = GameScreen.powerUps[i + 1];
            }

            //Remove the last (duplicate) powerup on the list
            GameScreen.powerUps.RemoveAt(GameScreen.powerUps.Count - 1);
        }

        /// <summary>
        /// This is called when the capsule comes in contact with the paddle
        /// </summary>
        public void usePowerUp(ref Paddle currentPaddle)
        {
            switch (capType)
            {
                case "Long":
                    longPaddle(ref currentPaddle);
                    break;
                case "Bomb":
                    Bomb();
                    break;
                case "Catch":
                    Catch();
                    break;
                case "Flip":
                    flipControls();
                    break;
                case "Life":
                    Life();
                    break;
                case "Laser":
                    Laser();
                    break;
                case "Gun":
                    Laser();
                    break;
                case "Multi":
                    Multi();
                    break;
                case "Bonus":
                    Bonus();
                    break;
                default:
                    break;
            }
        }

        public void longPaddle(ref Paddle currentPad)
        {
            if (paddle.x - LONG_PADDLE_GAIN / 2 < 0)
            {
                paddle.x = 0;
            }
            else if (paddle.x + paddle.width + LONG_PADDLE_GAIN/2 > GameScreen.screenWidth)
            {
                paddle.x = GameScreen.screenWidth - (paddle.width + LONG_PADDLE_GAIN);
            }
            else
            {
                paddle.x -= LONG_PADDLE_GAIN / 2;               
            }

            paddle.width += LONG_PADDLE_GAIN;
            currentPad = paddle;
        }

        public void Bonus()
        {
            GameScreen.bonus++;
        }

        public void Bomb()
        {
            GameScreen.bomb = true;
        }
        
        public void Catch()
        {
            GameScreen.catchBall = true;
        }

        public void flipControls()
        {
            if(GameScreen.flipControls)
            {
                GameScreen.flipControls = false;
            }
            else
            {
                GameScreen.flipControls = true;
            }
        }

        public void Life()
        {
            GameScreen.lives++;
        }

        public void Laser()
        {

        }

        public void Gun()
        {

        }

        public void Multi()
        {

        }
    }
}
