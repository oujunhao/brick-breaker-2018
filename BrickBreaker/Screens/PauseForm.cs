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
        // creating a private static for the pause form
        private static PauseForm pauseForm;
        private static DialogResult buttonResult = new DialogResult();

        //Creating the button selected integer
        private int buttonSelected;

        public PauseForm()
        {
            InitializeComponent();
           continueButton.ForeColor = Color.White;
        }

        //creating the dialog result to show the pauseForm
        public static DialogResult Show()
        {
            pauseForm = new PauseForm();
            pauseForm.ShowDialog();
            return buttonResult;
        }
    //load the pauseForm and and get rid of the border
        private void PauseForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        //when you click continue close the pasueform
        private void continueButton_Click(object sender, EventArgs e)
        {
            buttonResult = DialogResult.Cancel;
            pauseForm.Close();
        }

        // set focus on continue button
        private void continueButton_Enter(object sender, EventArgs e)
        {
            setButtonFocused(0);
        }

        //once exit button is clicked close the pause form
        private void exitButton_Click(object sender, EventArgs e)
        {
            buttonResult = DialogResult.Abort;
            pauseForm.Close();
        }

        // set focus on exit button
        private void exitButton_Enter(object sender, EventArgs e)
        {
            setButtonFocused(1);
        }

        //  set the colour of the focus button
        private void setButtonFocused(int buttonIndex)
        {
            buttonSelected = buttonIndex;
            resetAllLabelColours();
            switch (buttonIndex)
            {
                case 0:
                    continueButton.ForeColor = Color.White;
                    break;
                case 1:
                    exitButton.ForeColor = Color.White;
                    break;
            }
        }

        // reset all colours to hotpink
        private void resetAllLabelColours()
        {
            Color hotPink = Color.FromArgb(255, 255, 0, 102);
            continueButton.ForeColor = hotPink;
            exitButton.ForeColor = hotPink;
        }
    }
}
