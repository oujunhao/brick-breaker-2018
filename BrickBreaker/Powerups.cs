using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Powerups
    {
        Random randGen = new Random();
        public int powerupIndex;

        public Powerups()
        {
            powerupIndex = randGen.Next(1, 9);

            switch(powerupIndex)
            {
                case 1:
                    longPaddle();               
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
                default:
                    break;
            }
        }

        public void longPaddle()
        {

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
    }
}
