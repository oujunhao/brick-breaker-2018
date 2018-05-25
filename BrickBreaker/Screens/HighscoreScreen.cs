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
            hsmenuButton.ForeColor = Color.Black;
            hsexitButton.ForeColor = Color.Black;

            IList<GameSystemServices.Highscore> highscoreList = Form1.service.getHighscores();

            foreach (GameSystemServices.Highscore hs in highscoreList)
            {
                hsLabel.Text += hs.Rank + " " + hs.Name + " " + hs.Score + "\n\n";
            }
        }
        #region label controls
       
        private void hsexitButton_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void hsmenuButton_Click(object sender, EventArgs e)
        {
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();

            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);

            form.Controls.Add(ps);
            form.Controls.Remove(this);
        }
        #endregion

        private void hsLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
