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

namespace BrickBreaker
{
    public partial class Form1 : Form
    {
        //create list to hold blocks and new block 
        public static List<Block> blocks = new List<Block>();
        Block b = new Block();

        public Form1()
        {
            InitializeComponent();
            GetLevels();

            //start the program centred on the Menu Screen
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }

        public void GetLevels()
        {
            //TODO: add doc name
            XmlReader reader = XmlReader.Create();

            while(reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    b.x = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("y");
                    b.y = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("hp");
                    b.hp = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("colour");
                    b.colour = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("power");
                    b.power = reader.ReadString();

                    blocks.Add(b);
                }
            }
        }
    }
}
