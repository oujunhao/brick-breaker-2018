using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class PauseForm : Form
    {
        Timer timer;

        public PauseForm(Timer _timer)
        {
            InitializeComponent();
            timer = _timer;
        }

        private void PauseForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        private void PauseForm_Load(object sender, EventArgs e)
        {
            // instance of game over
            MenuScreen ms = new MenuScreen();

            //close game screen
            Form f = this.FindForm();
            f.Controls.Remove(this);


            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //exit the game
            Application.Exit();
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
                timer.Start();
            //Form f = this.FindForm();
            //f.Controls.Remove(this);
        } 
    }
}
