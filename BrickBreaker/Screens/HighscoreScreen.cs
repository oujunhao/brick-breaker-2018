using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker.Screens
{
    public partial class HighscoreScreen : UserControl
    {
        public HighscoreScreen()
        {
            InitializeComponent();
        }

        private void HighscoreScreen_Load(object sender, EventArgs e)
        {
            IList<GameSystemServices.Highscore> highscoreList = Form1.service.getHighscores(limit: 10);

            titleBox.Dock = DockStyle.Fill;
            hsLabel.Dock = DockStyle.Fill;

            foreach (GameSystemServices.Highscore hs in highscoreList)
            {
                
         
            }
        }

        private void hsExitLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();

            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);

            form.Controls.Add(ps);
            form.Controls.Remove(this);
        }

        private void hsExitLabel_Enter(object sender, EventArgs e)
        {
            ForeColor = Color.FromArgb(255, 0, 102);
        }

        private void hsmenuLabel_Enter(object sender, EventArgs e)
        {
            ForeColor = Color.FromArgb(255, 0, 102);
        }

        private void hsmenuLabel_Leave(object sender, EventArgs e)
        {
            ForeColor = Color.Black;
        }

        private void hsExitLabel_Leave(object sender, EventArgs e)
        {
            ForeColor = Color.Black;
        }
    }
}
