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
        Random randGen = new Random();
        int longPaddleGain = 20, capSpeed = 1;
        public static int capHeight = 10, capWidth = 15;
        public List<int> powerupIndexList = new List<int>();
        public static string[] powerupNames = new string[8]
            {
                "Long",
                "Bomb",
                "Catch",
                "Flip",
                "Life",
                "Laser",
                "Gun",
                "Multi"
            };
        public static List<Point> capsulePositions = new List<Point>();
        Paddle currentPaddle;

        /// <summary>
        /// Makes a new capsule appear on screen and adds it to the list of screen capsules 
        /// </summary>
        /// <param name="brickPosition">Spawns the capsule at the position of the brick</param>
        public Powerups(Rectangle brickPosition)
        {

            //Random rand = new Random();
            //int randCheck = rand.Next(1, 11);
            //if(randCheck == 1)
            //{

            powerupIndexList.Add(randGen.Next(1, 9));
            capsulePositions.Add(new Point(brickPosition.X, brickPosition.Y));

            //}

            //draw capsule
            //draw powerupNames[powerupIndexList.Last()];         
        }

        /// <summary>
        /// Moves all capsules down
        /// </summary>
        public void moveCapsule()
        {
            for(int i = 0; i < capsulePositions.Count(); i++)
            {
                capsulePositions[i] = new Point(capsulePositions[i].X, capsulePositions[i].Y+capSpeed);
            }
        }

        /// <summary>
        /// Checks if there is a collision between any of the capsules on screen and the paddle
        /// </summary>
        /// <param name="currentPad"> The paddle</param>
        public void capCollision(ref Paddle currentPad)
        {
            currentPaddle = currentPad;

            for (int i = 0; i < capsulePositions.Count(); i++)
            {
                if (capsulePositions[i].Y + capHeight >= currentPaddle.y &&//Check the height
                    capsulePositions[i].X + capWidth >= currentPaddle.x &&//If the right of cap is greater then left of paddle
                    capsulePositions[i].X <= currentPaddle.x + currentPaddle.width)//If the left of cap is less then right of paddle
                {
                    int capIndex = i;
                    usePowerUp(capIndex, ref currentPad);
                }
            }
        }

        /// <summary>
        /// This is called when the capsule comes in contact with the paddle
        /// </summary>
        public void usePowerUp(int capIndex, ref Paddle currentPaddle)
        {
            switch (powerupIndexList[capIndex])
            {
                case 1:
                    longPaddle(ref currentPaddle);
                    break;
                case 2:
                    Bomb();
                    break;
                case 3:
                    Catch();
                    break;
                case 4:
                    flipControls();
                    break;
                case 5:
                    Life();
                    break;
                case 6:
                    //Laser
                    break;
                case 7:
                    //Gun
                    break;
                case 8:
                    //Multi
                    break;
                default:
                    break;
            }

            //Removes the powerup that was just used
            powerupIndexList.RemoveAt(capIndex);

            //Remove capsule from screen
        }

        public void longPaddle(ref Paddle currentPad)
        {
            currentPaddle.x -= longPaddleGain/2;
            currentPaddle.width += longPaddleGain/2;
            currentPad = currentPaddle;
        }

        public void Bomb()
        {

        }
        
        public void Catch()
        {

        }

        public void flipControls()
        {

        }

        public void Life()
        {
            GameScreen.lives++;
        }
    }
}
