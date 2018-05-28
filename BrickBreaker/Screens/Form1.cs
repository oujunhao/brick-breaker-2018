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

// sahil-pause

namespace BrickBreaker
{
    public partial class Form1 : Form
    {
        const string gameToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJnYW1lSWQiOiI1YWU3NDlmMGMzMWFkMTU4MDhiNzM2YmYiLCJjYXJkSWQiOiIxIiwiaWF0IjoxNTI1MTA3MjYxfQ.SIWHqfZYSzfnLxOKtw0bLf4wYPEGsi_LAE4aP_J7Ke8";
        public static GameSystemServices.GameSystemServices service = new GameSystemServices.GameSystemServices(gameToken);

        int lifeSize = 35;
        int ballSpace = 15;
        MenuScreen ms = new MenuScreen();

        public Form1()
        {
            InitializeComponent();
            Cursor.Hide();

            //start the program centred on the Menu Screen
            this.Controls.Add(ms);
            ms.Location = new Point((Screen.PrimaryScreen.Bounds.Width - ms.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - ms.Height) / 2);
        }
        // Go full screen to be optimized for arcade
        void GoFullScreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }

    }
}
