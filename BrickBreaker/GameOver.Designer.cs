namespace BrickBreaker
{
    partial class GameOver
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.returnbutton = new System.Windows.Forms.Button();
            this.quitGameButton = new System.Windows.Forms.Button();
            this.highScoreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.Font = new System.Drawing.Font("Charlemagne Std", 71.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverLabel.ForeColor = System.Drawing.Color.White;
            this.gameOverLabel.Location = new System.Drawing.Point(58, 13);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(688, 114);
            this.gameOverLabel.TabIndex = 1;
            this.gameOverLabel.Text = "Game Over";
            // 
            // returnbutton
            // 
            this.returnbutton.Font = new System.Drawing.Font("Charlemagne Std", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnbutton.Location = new System.Drawing.Point(127, 142);
            this.returnbutton.Name = "returnbutton";
            this.returnbutton.Size = new System.Drawing.Size(500, 100);
            this.returnbutton.TabIndex = 5;
            this.returnbutton.Text = "Main Menu";
            this.returnbutton.UseVisualStyleBackColor = true;
            this.returnbutton.Click += new System.EventHandler(this.returnbutton_Click);
            this.returnbutton.Enter += new System.EventHandler(this.returnbutton_Enter);
            // 
            // quitGameButton
            // 
            this.quitGameButton.Font = new System.Drawing.Font("Charlemagne Std", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitGameButton.Location = new System.Drawing.Point(127, 354);
            this.quitGameButton.Name = "quitGameButton";
            this.quitGameButton.Size = new System.Drawing.Size(500, 100);
            this.quitGameButton.TabIndex = 4;
            this.quitGameButton.Text = "Quit";
            this.quitGameButton.UseVisualStyleBackColor = true;
            this.quitGameButton.Click += new System.EventHandler(this.quitGameButton_Click);
            this.quitGameButton.Enter += new System.EventHandler(this.quitGameButton_Enter);
            // 
            // highScoreButton
            // 
            this.highScoreButton.Font = new System.Drawing.Font("Charlemagne Std", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreButton.Location = new System.Drawing.Point(127, 248);
            this.highScoreButton.Name = "highScoreButton";
            this.highScoreButton.Size = new System.Drawing.Size(500, 100);
            this.highScoreButton.TabIndex = 7;
            this.highScoreButton.Text = "High Score";
            this.highScoreButton.UseVisualStyleBackColor = true;
            this.highScoreButton.Enter += new System.EventHandler(this.highScoreButton_Enter);
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.highScoreButton);
            this.Controls.Add(this.returnbutton);
            this.Controls.Add(this.quitGameButton);
            this.Controls.Add(this.gameOverLabel);
            this.Name = "GameOver";
            this.Size = new System.Drawing.Size(800, 550);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.Button returnbutton;
        private System.Windows.Forms.Button quitGameButton;
        private System.Windows.Forms.Button highScoreButton;
    }
}
