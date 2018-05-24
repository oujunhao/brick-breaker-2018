using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BrickBreaker
{
    public partial class PauseForm : Form
    {
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(rc, Color.FromArgb(255, 55, 64, 105), Color.FromArgb(255, 32, 14, 48), 90F))
            {
                e.Graphics.FillRectangle(brush, rc);
            }
        }
        private static PauseForm pauseForm;
        private static DialogResult buttonResult = new DialogResult();

        public PauseForm()
        {
            InitializeComponent();
        }

        public static DialogResult Show()
        {
            pauseForm = new PauseForm();
            pauseForm.ShowDialog();
            return buttonResult; 
        }

        private void PauseForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            buttonResult = DialogResult.Cancel;
            pauseForm.Close();
        }

        private void continueButton_Enter(object sender, EventArgs e)
        {
            continueButton.BackColor = Color.Transparent;
            exitButton.BackColor = Color.Transparent;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            buttonResult = DialogResult.Abort;
            pauseForm.Close();
        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.Red;
            continueButton.BackColor = Color.Transparent;
        }
    }
}
