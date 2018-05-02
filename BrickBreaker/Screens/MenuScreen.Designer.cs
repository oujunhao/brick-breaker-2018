namespace BrickBreaker
{
    partial class MenuScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuScreen));
            this.onePlayerButton = new System.Windows.Forms.Button();
            this.twoPlayerButton = new System.Windows.Forms.Button();
            this.brickBreakerTitleLable = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.highscoresButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // onePlayerButton
            // 
            this.onePlayerButton.BackColor = System.Drawing.Color.Transparent;
            this.onePlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.onePlayerButton.FlatAppearance.BorderSize = 0;
            this.onePlayerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.onePlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.onePlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.onePlayerButton.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onePlayerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.onePlayerButton.Location = new System.Drawing.Point(291, 216);
            this.onePlayerButton.Name = "onePlayerButton";
            this.onePlayerButton.Size = new System.Drawing.Size(181, 51);
            this.onePlayerButton.TabIndex = 0;
            this.onePlayerButton.Text = "1 Player";
            this.onePlayerButton.UseVisualStyleBackColor = false;
            this.onePlayerButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // twoPlayerButton
            // 
            this.twoPlayerButton.BackColor = System.Drawing.Color.Transparent;
            this.twoPlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.twoPlayerButton.FlatAppearance.BorderSize = 0;
            this.twoPlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twoPlayerButton.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoPlayerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.twoPlayerButton.Location = new System.Drawing.Point(291, 273);
            this.twoPlayerButton.Name = "twoPlayerButton";
            this.twoPlayerButton.Size = new System.Drawing.Size(181, 46);
            this.twoPlayerButton.TabIndex = 1;
            this.twoPlayerButton.Text = "2 Player";
            this.twoPlayerButton.UseVisualStyleBackColor = false;
            this.twoPlayerButton.Click += new System.EventHandler(this.twoPlayerButton_Click);
            // 
            // brickBreakerTitleLable
            // 
            this.brickBreakerTitleLable.AutoSize = true;
            this.brickBreakerTitleLable.BackColor = System.Drawing.Color.Transparent;
            this.brickBreakerTitleLable.Font = new System.Drawing.Font("Rustico", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brickBreakerTitleLable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.brickBreakerTitleLable.Location = new System.Drawing.Point(229, 127);
            this.brickBreakerTitleLable.Name = "brickBreakerTitleLable";
            this.brickBreakerTitleLable.Size = new System.Drawing.Size(336, 86);
            this.brickBreakerTitleLable.TabIndex = 2;
            this.brickBreakerTitleLable.Text = "Brick Breaker";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.exitButton.Location = new System.Drawing.Point(291, 379);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(181, 46);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click_1);
            // 
            // highscoresButton
            // 
            this.highscoresButton.BackColor = System.Drawing.Color.Transparent;
            this.highscoresButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.highscoresButton.FlatAppearance.BorderSize = 0;
            this.highscoresButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.highscoresButton.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoresButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.highscoresButton.Location = new System.Drawing.Point(278, 327);
            this.highscoresButton.Name = "highscoresButton";
            this.highscoresButton.Size = new System.Drawing.Size(210, 46);
            this.highscoresButton.TabIndex = 4;
            this.highscoresButton.Text = "Highscores";
            this.highscoresButton.UseVisualStyleBackColor = false;
            this.highscoresButton.Click += new System.EventHandler(this.highscoresButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(101, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 221);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.highscoresButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.brickBreakerTitleLable);
            this.Controls.Add(this.twoPlayerButton);
            this.Controls.Add(this.onePlayerButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(800, 550);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button onePlayerButton;
        private System.Windows.Forms.Button twoPlayerButton;
        private System.Windows.Forms.Label brickBreakerTitleLable;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button highscoresButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
