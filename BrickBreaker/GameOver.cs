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
        public GameOver()
        {
            InitializeComponent();
        }

        private void quitGameButton_Click(object sender, EventArgs e)
        {
            //exits game
            Application.Exit();
        }

        private void returnbutton_Click(object sender, EventArgs e)
        {
            // f is the form that this control is on - ("this" is the current User Control)
            Form f = this.FindForm();
            f.Controls.Remove(this);

            //created instance of main screen
            MenuScreen ms = new MenuScreen();

            //close mainscreen
            Form x = this.FindForm();
            f.Controls.Remove(this);

            // centre screen
            ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);

            //add menu screen
            f.Controls.Add(ms);
        }

        private void quitGameButton_Enter(object sender, EventArgs e)
        {
            //makes quit button red and return button white
            quitGameButton.BackColor = Color.Red;
            returnbutton.BackColor = Color.White;
            highScoreButton.BackColor = Color.White;
        }

        private void returnbutton_Enter(object sender, EventArgs e)
        {
            //makes quit button white and return button green
            quitGameButton.BackColor = Color.White;
            returnbutton.BackColor = Color.Green;
            highScoreButton.BackColor = Color.White;
        }

        private void highScoreButton_Enter(object sender, EventArgs e)
        {
            highScoreButton.BackColor = Color.Blue;
            quitGameButton.BackColor = Color.White;
            returnbutton.BackColor = Color.White;
        }

        private void highScoreButton_Click(object sender, EventArgs e)
        {
            //Form form = this.FindForm();
            //Screens.HighscoreScreen hs = new Screens.HighscoreScreen();

            //form.Controls.Add(hs);
            //form.Controls.Remove(this);
        }
    }
}
