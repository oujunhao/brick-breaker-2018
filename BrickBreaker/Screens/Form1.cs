using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using GameSystemServices;
using System.Media;

namespace BrickBreaker
{
    public partial class Form1 : Form
    {
        const string gameToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJnYW1lSWQiOiI1YWU3NDlmMGMzMWFkMTU4MDhiNzM2YmYiLCJjYXJkSWQiOiIxIiwiaWF0IjoxNTI1MTA3MjYxfQ.SIWHqfZYSzfnLxOKtw0bLf4wYPEGsi_LAE4aP_J7Ke8";
        public static Service service = new Service(Environment.GetCommandLineArgs(), gameToken);
        MenuScreen ms = new MenuScreen();

        public Form1()
        {
            InitializeComponent();
            Cursor.Hide();

            //start the program centred on the Menu Screen
            
            this.Controls.Add(ms);

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int barHeight = 50, barGap = 10, lifeSpacing = 10, lifeDiameter = 30;

            string drawScore = GameScreen.score.ToString();

            float scoreWordLength = e.Graphics.MeasureString("SCORE: ", GameScreen.scoreFont).Width;
            float scoreNumberLength = e.Graphics.MeasureString(drawScore, GameScreen.scoreFont).Width;

            Rectangle backRect2 = new Rectangle((this.Width - ms.Width)/2, (this.Height - ms.Height) / 2 - barHeight, ms.Width, barHeight);
            e.Graphics.FillRectangle(Brushes.Black, backRect2);

            e.Graphics.DrawString("SCORE:", GameScreen.scoreFont, Brushes.White,
                (this.Width - ms.Width) / 2 + ms.Width - scoreWordLength - scoreNumberLength - 10, (this.Height - ms.Height) / 2 - barHeight);
            e.Graphics.DrawString(drawScore, GameScreen.scoreFont, GameScreen.capBrush,
                (this.Width - ms.Width) / 2 + ms.Width - scoreNumberLength - 10, ms.Location.Y - barHeight);

            for (int i = 0; i < GameScreen.lives; i++)
            {
                e.Graphics.FillEllipse(GameScreen.capBrush, (this.Width - ms.Width)/2 + (i*lifeDiameter) + (i*lifeSpacing) + lifeSpacing,
                    (this.Height-ms.Height)/2 -barHeight / 2 - lifeDiameter / 2, lifeDiameter, lifeDiameter);
            }
        }
    }
}
