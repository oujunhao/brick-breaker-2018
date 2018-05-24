﻿using System;
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
using System.Media;

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {
        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceDown;

        int buttonSelected = 0;

        private SoundPlayer Player = new SoundPlayer(BrickBreaker.Properties.Resources.Level);
        private SoundPlayer HighscorePlayer = new SoundPlayer(BrickBreaker.Properties.Resources.Highscore);


        public MenuScreen()
        {
            InitializeComponent();
            this.Location = new Point(140, 70);
            onePlayerButton.ForeColor = Color.White;
        }

        private void playOnePlayerGame()
        {
            //Click sound when player hits play
            using (SoundPlayer player = new SoundPlayer(BrickBreaker.Properties.Resources.Play))
            player.Play();

            // Goes to the game screen
            GameScreen gs = new GameScreen();
            Form form = this.FindForm();

            //Background music
            try
            {
                this.Player.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error playing sound");
            }

            form.Controls.Add(gs);
            form.Controls.Remove(this);

            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);

            Graphics g = form.CreateGraphics();
            int barHeight = 50, lifeSpacing = 10, lifeDiameter = 30;

            string drawScore = GameScreen.score.ToString();

            float scoreWordLength = g.MeasureString("SCORE: ", GameScreen.scoreFont).Width;
            float scoreNumberLength = g.MeasureString(drawScore, GameScreen.scoreFont).Width;

            Rectangle menuRect = new Rectangle(gs.Location.X, gs.Location.Y - barHeight, gs.Width, barHeight);

            g.FillRectangle(Brushes.Black, menuRect);
            g.DrawString("SCORE:", GameScreen.scoreFont, Brushes.White, gs.Location.X + gs.Width - scoreWordLength - scoreNumberLength - 10, gs.Location.Y - barHeight);
            g.DrawString(drawScore, GameScreen.scoreFont, GameScreen.capBrush, gs.Location.X + gs.Width - scoreNumberLength - 10, gs.Location.Y - barHeight);

            for (int i = 0; i < GameScreen.lives; i++)
            {
                g.FillEllipse(GameScreen.capBrush, gs.Location.X + (i * lifeDiameter) + (i * lifeSpacing) + lifeSpacing, gs.Location.Y - barHeight / 2 - lifeDiameter / 2, lifeDiameter, lifeDiameter);
            }
        }

        private void showHighscoreMenu()
        {
            HighscorePlayer.Play();
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
            resetAllLabelColours();
            switch (buttonIndex)
            {
                case 0:
                    onePlayerButton.ForeColor = Color.White;
                    break;
                case 1:
                    twoPlayerButton.ForeColor = Color.White;
                    break;
                case 2:
                    highscoresButton.ForeColor = Color.White;
                    break;
                case 3:
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
