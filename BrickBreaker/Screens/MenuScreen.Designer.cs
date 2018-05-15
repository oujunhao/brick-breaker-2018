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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuScreen));
            this.onePlayerButton = new System.Windows.Forms.Button();
            this.twoPlayerButton = new System.Windows.Forms.Button();
            this.brickBreakerTitleLable = new System.Windows.Forms.Label();
            this.highscoresButton = new System.Windows.Forms.Button();
            this.exitGameButton = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // onePlayerButton
            // 
            this.onePlayerButton.AutoSize = true;
            this.onePlayerButton.BackColor = System.Drawing.Color.Transparent;
            this.onePlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.onePlayerButton.FlatAppearance.BorderSize = 0;
            this.onePlayerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.onePlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.onePlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.onePlayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onePlayerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.onePlayerButton.Location = new System.Drawing.Point(526, 518);
            this.onePlayerButton.Margin = new System.Windows.Forms.Padding(6);
            this.onePlayerButton.Name = "onePlayerButton";
            this.onePlayerButton.Size = new System.Drawing.Size(465, 98);
            this.onePlayerButton.TabIndex = 0;
            this.onePlayerButton.Text = "1  P L A Y E R";
            this.onePlayerButton.UseVisualStyleBackColor = false;
            this.onePlayerButton.Click += new System.EventHandler(this.onePlayerButton_Click);
            this.onePlayerButton.Enter += new System.EventHandler(this.onePlayerButton_Enter);
            // 
            // twoPlayerButton
            // 
            this.twoPlayerButton.AutoSize = true;
            this.twoPlayerButton.BackColor = System.Drawing.Color.Transparent;
            this.twoPlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.twoPlayerButton.FlatAppearance.BorderSize = 0;
            this.twoPlayerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.twoPlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.twoPlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twoPlayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoPlayerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.twoPlayerButton.Location = new System.Drawing.Point(526, 646);
            this.twoPlayerButton.Margin = new System.Windows.Forms.Padding(6);
            this.twoPlayerButton.Name = "twoPlayerButton";
            this.twoPlayerButton.Size = new System.Drawing.Size(465, 92);
            this.twoPlayerButton.TabIndex = 1;
            this.twoPlayerButton.Text = "2  P L A Y E R";
            this.twoPlayerButton.UseVisualStyleBackColor = false;
            this.twoPlayerButton.Click += new System.EventHandler(this.twoPlayerButton_Click);
            this.twoPlayerButton.Enter += new System.EventHandler(this.twoPlayerButton_Enter);
            // 
            // brickBreakerTitleLable
            // 
            this.brickBreakerTitleLable.AutoSize = true;
            this.brickBreakerTitleLable.BackColor = System.Drawing.Color.Transparent;
            this.brickBreakerTitleLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brickBreakerTitleLable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.brickBreakerTitleLable.Location = new System.Drawing.Point(458, 244);
            this.brickBreakerTitleLable.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.brickBreakerTitleLable.Name = "brickBreakerTitleLable";
            this.brickBreakerTitleLable.Size = new System.Drawing.Size(0, 108);
            this.brickBreakerTitleLable.TabIndex = 2;
            // 
            // highscoresButton
            // 
            this.highscoresButton.AutoSize = true;
            this.highscoresButton.BackColor = System.Drawing.Color.Transparent;
            this.highscoresButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.highscoresButton.FlatAppearance.BorderSize = 0;
            this.highscoresButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.highscoresButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.highscoresButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.highscoresButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoresButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.highscoresButton.Location = new System.Drawing.Point(446, 762);
            this.highscoresButton.Margin = new System.Windows.Forms.Padding(6);
            this.highscoresButton.Name = "highscoresButton";
            this.highscoresButton.Size = new System.Drawing.Size(645, 92);
            this.highscoresButton.TabIndex = 3;
            this.highscoresButton.Text = "H I G H S C O R E S";
            this.highscoresButton.UseVisualStyleBackColor = false;
            this.highscoresButton.Click += new System.EventHandler(this.highscoresButton_Click);
            this.highscoresButton.Enter += new System.EventHandler(this.highScoresButton_Enter);
            // 
            // exitGameButton
            // 
            this.exitGameButton.AutoSize = true;
            this.exitGameButton.BackColor = System.Drawing.Color.Transparent;
            this.exitGameButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitGameButton.FlatAppearance.BorderSize = 0;
            this.exitGameButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exitGameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exitGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitGameButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.exitGameButton.Location = new System.Drawing.Point(426, 866);
            this.exitGameButton.Margin = new System.Windows.Forms.Padding(6);
            this.exitGameButton.Name = "exitGameButton";
            this.exitGameButton.Size = new System.Drawing.Size(645, 92);
            this.exitGameButton.TabIndex = 4;
            this.exitGameButton.Text = "E X I T";
            this.exitGameButton.UseVisualStyleBackColor = false;
            this.exitGameButton.Click += new System.EventHandler(this.exitGameButton_Click);
            this.exitGameButton.Enter += new System.EventHandler(this.exitGameButton_Enter);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 77);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1594, 429);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(105)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.exitGameButton);
            this.Controls.Add(this.highscoresButton);
            this.Controls.Add(this.brickBreakerTitleLable);
            this.Controls.Add(this.twoPlayerButton);
            this.Controls.Add(this.onePlayerButton);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(1600, 1058);
            this.Load += new System.EventHandler(this.MenuScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button onePlayerButton;
        private System.Windows.Forms.Button twoPlayerButton;
        private System.Windows.Forms.Label brickBreakerTitleLable;
        private System.Windows.Forms.Button highscoresButton;
        private System.Windows.Forms.Button exitGameButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
