namespace BrickBreaker.Screens
{
    partial class HighscoreScreen
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
            this.titleBox = new System.Windows.Forms.PictureBox();
            this.hsLabel = new System.Windows.Forms.Label();
            this.hsexitButton = new System.Windows.Forms.Button();
            this.hsmenuButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.titleBox)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBox
            // 
            this.titleBox.BackColor = System.Drawing.Color.Transparent;
            this.titleBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBox.Image = global::BrickBreaker.Properties.Resources.HighScoresfinal;
            this.titleBox.Location = new System.Drawing.Point(0, 0);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(798, 110);
            this.titleBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.titleBox.TabIndex = 0;
            this.titleBox.TabStop = false;
            // 
            // hsLabel
            // 
            this.hsLabel.BackColor = System.Drawing.Color.Transparent;
            this.hsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hsLabel.Font = new System.Drawing.Font("Roboto Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hsLabel.ForeColor = System.Drawing.Color.White;
            this.hsLabel.Location = new System.Drawing.Point(0, 110);
            this.hsLabel.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.hsLabel.Name = "hsLabel";
            this.hsLabel.Padding = new System.Windows.Forms.Padding(50, 25, 0, 0);
            this.hsLabel.Size = new System.Drawing.Size(798, 438);
            this.hsLabel.TabIndex = 3;
            // 
            // hsexitButton
            // 
            this.hsexitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(105)))));
            this.hsexitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hsexitButton.Font = new System.Drawing.Font("Rustico", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hsexitButton.Location = new System.Drawing.Point(266, 466);
            this.hsexitButton.Name = "hsexitButton";
            this.hsexitButton.Size = new System.Drawing.Size(97, 41);
            this.hsexitButton.TabIndex = 4;
            this.hsexitButton.Text = "EXIT";
            this.hsexitButton.UseVisualStyleBackColor = false;
            this.hsexitButton.Click += new System.EventHandler(this.hsexitButton_Click);
            // 
            // hsmenuButton
            // 
            this.hsmenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(105)))));
            this.hsmenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hsmenuButton.Font = new System.Drawing.Font("Rustico", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hsmenuButton.Location = new System.Drawing.Point(438, 466);
            this.hsmenuButton.Name = "hsmenuButton";
            this.hsmenuButton.Size = new System.Drawing.Size(97, 41);
            this.hsmenuButton.TabIndex = 5;
            this.hsmenuButton.Text = "MENU";
            this.hsmenuButton.UseVisualStyleBackColor = false;
            this.hsmenuButton.Click += new System.EventHandler(this.hsmenuButton_Click);
            // 
            // HighscoreScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BrickBreaker.Properties.Resources.backbroundHS;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.hsmenuButton);
            this.Controls.Add(this.hsexitButton);
            this.Controls.Add(this.hsLabel);
            this.Controls.Add(this.titleBox);
            this.Name = "HighscoreScreen";
            this.Size = new System.Drawing.Size(798, 548);
            this.Load += new System.EventHandler(this.HighscoreScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.titleBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox titleBox;
        private System.Windows.Forms.Label hsLabel;
        private System.Windows.Forms.Button hsexitButton;
        private System.Windows.Forms.Button hsmenuButton;
    }
}
