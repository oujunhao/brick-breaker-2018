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
            continueButton.BackColor = Color.Green;
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
