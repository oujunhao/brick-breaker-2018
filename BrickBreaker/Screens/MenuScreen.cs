using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {
        

        public void drawTriangle(Point position, int sideLength) {
            Graphics g = this.CreateGraphics();
            Pen trianglePen = new Pen(Color.Red, 10);
            Point[] triangle = new Point[3];
            triangle[0] = new Point(position.X, position.Y);
            triangle[1] = new Point(position.X + sideLength, position.Y);
            triangle[2] = new Point(position.X + sideLength/2, position.Y - (int)((double)sideLength * Math.Sin(45)) );
            g.DrawPolygon(trianglePen, triangle);
        }
        public MenuScreen()
        {
            InitializeComponent();
            
            

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            // Goes to the game screen
            GameScreen gs = new GameScreen();
            Form form = this.FindForm();

            form.Controls.Add(gs);
            form.Controls.Remove(this);

            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);
        }

        private void twoPlayerButton_Click(object sender, EventArgs e)
        {
            drawTriangle(new Point(70, 100), 500);
        }

        private void highscoresButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
