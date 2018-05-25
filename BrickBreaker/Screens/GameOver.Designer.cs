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
            this.returnbutton = new System.Windows.Forms.Button();
            this.quitGameButton = new System.Windows.Forms.Button();
            this.highScoreButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // returnbutton
            // 
            this.returnbutton.BackColor = System.Drawing.Color.Transparent;
            this.returnbutton.FlatAppearance.BorderSize = 0;
            this.returnbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.returnbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.returnbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnbutton.Location = new System.Drawing.Point(241, 183);
            this.returnbutton.Name = "returnbutton";
            this.returnbutton.Size = new System.Drawing.Size(298, 100);
            this.returnbutton.TabIndex = 5;
            this.returnbutton.Text = "Main Menu";
            this.returnbutton.UseVisualStyleBackColor = false;
            this.returnbutton.Click += new System.EventHandler(this.returnbutton_Click);
            this.returnbutton.Enter += new System.EventHandler(this.returnbutton_Enter);
            // 
            // quitGameButton
            // 
            this.quitGameButton.BackColor = System.Drawing.Color.Transparent;
            this.quitGameButton.FlatAppearance.BorderSize = 0;
            this.quitGameButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.quitGameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.quitGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitGameButton.Location = new System.Drawing.Point(241, 395);
            this.quitGameButton.Name = "quitGameButton";
            this.quitGameButton.Size = new System.Drawing.Size(298, 100);
            this.quitGameButton.TabIndex = 4;
            this.quitGameButton.Text = "Quit";
            this.quitGameButton.UseVisualStyleBackColor = false;
            this.quitGameButton.Click += new System.EventHandler(this.quitGameButton_Click);
            this.quitGameButton.Enter += new System.EventHandler(this.quitGameButton_Enter);
            // 
            // highScoreButton
            // 
            this.highScoreButton.BackColor = System.Drawing.Color.Transparent;
            this.highScoreButton.FlatAppearance.BorderSize = 0;
            this.highScoreButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.highScoreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.highScoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.highScoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreButton.Location = new System.Drawing.Point(241, 289);
            this.highScoreButton.Name = "highScoreButton";
            this.highScoreButton.Size = new System.Drawing.Size(298, 100);
            this.highScoreButton.TabIndex = 7;
            this.highScoreButton.Text = "High Score";
            this.highScoreButton.UseVisualStyleBackColor = false;
            this.highScoreButton.Click += new System.EventHandler(this.highScoreButton_Click);
            this.highScoreButton.Enter += new System.EventHandler(this.highScoreButton_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::BrickBreaker.Properties.Resources.got;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(120, 0, 0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(800, 143);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::BrickBreaker.Properties.Resources.gameoverScreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.highScoreButton);
            this.Controls.Add(this.returnbutton);
            this.Controls.Add(this.quitGameButton);
            this.Name = "GameOver";
            this.Size = new System.Drawing.Size(800, 550);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button returnbutton;
        private System.Windows.Forms.Button quitGameButton;
        private System.Windows.Forms.Button highScoreButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
