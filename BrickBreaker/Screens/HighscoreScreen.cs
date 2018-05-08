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
        }

    }
}
