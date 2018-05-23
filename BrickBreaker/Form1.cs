using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using GameSystemServices;

// cam - levels //

namespace BrickBreaker
{
    public partial class Form1 : Form
    {
        //create list to hold blocks and new block 
        public static List<Block> blocks = new List<Block>();
        const string gameToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJnYW1lSWQiOiI1YWU3NDlmMGMzMWFkMTU4MDhiNzM2YmYiLCJjYXJkSWQiOiIxIiwiaWF0IjoxNTI1MTA3MjYxfQ.SIWHqfZYSzfnLxOKtw0bLf4wYPEGsi_LAE4aP_J7Ke8";
        public static Service service = new Service(Environment.GetCommandLineArgs(), gameToken);

        int lifeSize = 35;
        int ballSpace = 15;
        MenuScreen ms = new MenuScreen();

        public Form1()
        {
            InitializeComponent();
            Cursor.Hide();

            //start the program centred on the Menu Screen
            this.Controls.Add(ms);

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }

        private void Form1_Paint(object sender, PaintEventArgs g)
        {
            SolidBrush brush = new SolidBrush(Color.Purple);

            for (int i = 0; i < GameScreen.lives; i++)
            {
                g.Graphics.FillEllipse(brush, (this.Width - ms.Width) / 2 + (i * lifeSize) + (i * ballSpace), 
                    ((this.Height - ms.Height) / 2) - 40, lifeSize, lifeSize);
            }
        }
    }
}
