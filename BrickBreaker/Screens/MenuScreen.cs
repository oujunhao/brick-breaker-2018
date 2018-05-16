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
        private SoundPlayer Player = new SoundPlayer();

        public MenuScreen()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //Click when player hits exit
            SoundPlayer player = new SoundPlayer(Properties.Resources.Exit);
            player.Play();
            System.Threading.Thread.Sleep(500);
            this.Player.Stop();

            Application.Exit(); 
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            //Click when player hits play
            using (SoundPlayer player = new SoundPlayer("C:\\Play.wav"))
            player.Play();
            //var dingPlayer = new System.Windows.Media.MediaPlayer();
            //dingPlayer.Open(new Uri(Application.StartupPath + "/Resources.resx/Play.wav"));
            //dingPlayer.Play();

            //SoundPlayer player = new SoundPlayer(Properties.Resources.Play);


            // Goes to the game screen
            GameScreen gs = new GameScreen();
            Form form = this.FindForm();

            //Background music
            try
            {
                this.Player.SoundLocation = @"C:\Windows\Media\Level.wav";
                this.Player.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error playing sound");
            }

            form.Controls.Add(gs);
            form.Controls.Remove(this);

            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);
        }   
    }
}
