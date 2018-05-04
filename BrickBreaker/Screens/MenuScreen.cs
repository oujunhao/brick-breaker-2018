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

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {

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

        private void playButton_Click(object sender, EventArgs e)
        {
            playOnePlayerGame();
        }

        private void twoPlayerButton_Click(object sender, EventArgs e)
        {

        }

        private void highscoresButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
