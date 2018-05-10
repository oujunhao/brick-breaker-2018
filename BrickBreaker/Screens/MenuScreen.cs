using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //Click when player hits exit
            var dingPlayer = new System.Windows.Media.MediaPlayer();
            dingPlayer.Open(new Uri(Application.StartupPath + "/Resources.resx/Exit.wav"));
            dingPlayer.Play();

            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            //Click when player hits play
            var dingPlayer = new System.Windows.Media.MediaPlayer();
            dingPlayer.Open(new Uri(Application.StartupPath + "/Resources.resx/Play.wav"));
            dingPlayer.Play();

            // Goes to the game screen
            GameScreen gs = new GameScreen();
            Form form = this.FindForm();

            form.Controls.Add(gs);
            form.Controls.Remove(this);

            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);
        }

    }
}
