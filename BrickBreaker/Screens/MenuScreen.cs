using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using BrickBreaker.Screens;

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceDown;

        int buttonSelected = 0;

        public MenuScreen()
        {
            InitializeComponent();
            onePlayerButton.ForeColor = Color.White;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rc, Color.FromArgb(255, 55, 64, 105), Color.FromArgb(255, 32, 14, 48), 90F))
            {
                e.Graphics.FillRectangle(brush, rc);
            }
        }

        private void playOnePlayerGame()
        {
            // Goes to the game screen
            GameScreen gs = new GameScreen();
            Form form = this.FindForm();

            form.Controls.Add(gs);
            form.Controls.Remove(this);

            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);
        }

        private void showHighscoreMenu()
        {
            // Goes to the highscores menu
            HighscoreScreen hs = new HighscoreScreen();
            Form form = this.FindForm();

            form.Controls.Add(hs);
            form.Controls.Remove(this);

            hs.Location = new Point((form.Width - hs.Width) / 2, (form.Height - hs.Height) / 2);
        }

        #region on_enter
        private void onePlayerButton_Enter(object sender, EventArgs e)
        {
            setFocusedButton(0);
        }

        private void twoPlayerButton_Enter(object sender, EventArgs e)
        {
            setFocusedButton(1);
        }

        private void highScoresButton_Enter(object sender, EventArgs e)
        {
            setFocusedButton(2);
        }



        private void exitGameButton_Enter(object sender, EventArgs e)
        {
            setFocusedButton(3);
        }


        private void setFocusedButton(int buttonIndex)
        {
            buttonSelected = buttonIndex;
            switch (buttonIndex)
            {
                case 0:
                    resetAllLabelColours();
                    onePlayerButton.ForeColor = Color.White;
                    break;
                case 1:
                    resetAllLabelColours();
                    twoPlayerButton.ForeColor = Color.White;
                    break;
                case 2:
                    resetAllLabelColours();
                    highscoresButton.ForeColor = Color.White;
                    break;
                case 3:
                    resetAllLabelColours();
                    exitGameButton.ForeColor = Color.White;
                    break;
            }
        }



        private void resetAllLabelColours()
        {
            Color hotPink = Color.FromArgb(255, 255, 0, 102);
            onePlayerButton.ForeColor = hotPink;
            twoPlayerButton.ForeColor = hotPink;
            highscoresButton.ForeColor = hotPink;
            exitGameButton.ForeColor = hotPink;
        }
        #endregion

        #region click_buttons
        private void onePlayerButton_Click(object sender, EventArgs e)
        {
            // play one player game
            playOnePlayerGame();
        }
        private void twoPlayerButton_Click(object sender, EventArgs e)
        {
            //play two player game
        }
        private void highscoresButton_Click(object sender, EventArgs e)
        {
            //load highscore screen
            showHighscoreMenu();

        }
        private void exitGameButton_Click(object sender, EventArgs e)
        {
            // exit game
            Application.Exit();
        }

        #endregion

        private void MenuScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
