using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class GameOver : UserControl
    {
        //private integer for selected button
        private int buttonSelected;

        public GameOver()
        {
            InitializeComponent();
        }

        // go back to menu screen 
        private void returnbutton_Click(object sender, EventArgs e)
        {
            // f is the form that this control is on - ("this" is the current User Control)
            Form f = this.FindForm();
            if (f != null)
                f.Controls.Remove(this);

            //created instance of main screen
            MenuScreen ms = new MenuScreen();

            //close mainscreen
            Form x = this.FindForm();
            if (f != null)
            f.Controls.Remove(this);

            // centre screen
            if (f != null)
            ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);

            //add menu screen
            if (f != null)
            f.Controls.Add(ms);
        }

        //quit the game
        private void quitGameButton_Click(object sender, EventArgs e)
        {
            //exits game
            Application.Exit();
        }

        //set focus on return button
        private void returnbutton_Enter(object sender, EventArgs e)
        {
            setFocusedButton(0);
        }

        //set focus on high score button
        private void highScoreButton_Enter(object sender, EventArgs e)
        {
            setFocusedButton(1);
        }

        //set focus on quitgame button
        private void quitGameButton_Enter(object sender, EventArgs e)
        {
            setFocusedButton(2);
        }

        // Open the highscore sreen 
        private void highScoreButton_Click(object sender, EventArgs e)
        {
            Form form = this.FindForm();
            Screens.HighscoreScreen hs = new Screens.HighscoreScreen();

            form.Controls.Add(hs);
            form.Controls.Remove(this);
        }

        //  set the colour of the focus button 
        private void setFocusedButton(int buttonIndex)
        {
            buttonSelected = buttonIndex;
            resetAllLabelColours();
            switch (buttonIndex)
            {
                case 0:
                    returnbutton.ForeColor = Color.White;
                    break;
                case 1:
                    highScoreButton.ForeColor = Color.White;
                    break;
                case 2:
                    quitGameButton.ForeColor = Color.White;
                    break;
            }
        }

        // reset all colours to hotpink
        private void resetAllLabelColours()
        {
            Color hotPink = Color.FromArgb(255, 255, 0, 102);
            returnbutton.ForeColor = hotPink;
            highScoreButton.ForeColor = hotPink;
            quitGameButton.ForeColor = hotPink;
        }
    }
}
