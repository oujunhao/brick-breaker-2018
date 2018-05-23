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
        
        public Form1()
        {
            InitializeComponent();
            Cursor.Hide();

            //start the program centred on the Menu Screen
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);
            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }
    }
}
