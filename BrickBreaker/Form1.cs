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


namespace BrickBreaker
{
    public partial class Form1 : Form
    {
        //create list to hold blocks and new block 
        public static List<Block> blocks = new List<Block>();
        Block b = new Block();
        const string gameToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJnYW1lSWQiOiI1YWU3NDlmMGMzMWFkMTU4MDhiNzM2YmYiLCJjYXJkSWQiOiIxIiwiaWF0IjoxNTI1MTA3MjYxfQ.SIWHqfZYSzfnLxOKtw0bLf4wYPEGsi_LAE4aP_J7Ke8";
        public static Service service = new Service(Environment.GetCommandLineArgs(), gameToken);

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, System.EventArgs e)
        {
            GetLevels();

            //start the program centred on the Menu Screen
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }

        public void GetLevels()
        {
            //TODO: add doc name
            XmlReader reader = XmlReader.Create("test.xml");

            while(reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    b.x = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("y");
                    b.y = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("hp");
                    b.hp = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("r");
                    b.r = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("g");
                    b.g = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("b");
                    b.b = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("power");
                    b.power = reader.ReadString();

                    blocks.Add(b);
                }
            }
        }
    }
}
