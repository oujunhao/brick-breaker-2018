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
            this.hsExitLabel = new System.Windows.Forms.Label();
            this.hsmenuLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.titleBox)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBox
            // 
            this.titleBox.BackColor = System.Drawing.Color.Transparent;
            this.titleBox.Image = global::BrickBreaker.Properties.Resources.HighScores3;
            this.titleBox.Location = new System.Drawing.Point(155, 17);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(465, 110);
            this.titleBox.TabIndex = 0;
            this.titleBox.TabStop = false;
            // 
            // hsLabel
            // 
            this.hsLabel.BackColor = System.Drawing.Color.Transparent;
            this.hsLabel.Font = new System.Drawing.Font("Roboto Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.hsLabel.Location = new System.Drawing.Point(155, 144);
            this.hsLabel.Name = "hsLabel";
            this.hsLabel.Size = new System.Drawing.Size(465, 310);
            this.hsLabel.TabIndex = 1;
            // 
            // hsExitLabel
            // 
            this.hsExitLabel.BackColor = System.Drawing.Color.Transparent;
            this.hsExitLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hsExitLabel.Font = new System.Drawing.Font("Rustico", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hsExitLabel.Location = new System.Drawing.Point(239, 472);
            this.hsExitLabel.Name = "hsExitLabel";
            this.hsExitLabel.Size = new System.Drawing.Size(100, 47);
            this.hsExitLabel.TabIndex = 2;
            this.hsExitLabel.Text = "EXIT";
            this.hsExitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hsExitLabel.Click += new System.EventHandler(this.hsExitLabel_Click);
            this.hsExitLabel.Enter += new System.EventHandler(this.hsExitLabel_Enter);
            this.hsExitLabel.Leave += new System.EventHandler(this.hsExitLabel_Leave);
            // 
            // hsmenuLabel
            // 
            this.hsmenuLabel.BackColor = System.Drawing.Color.Transparent;
            this.hsmenuLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hsmenuLabel.Font = new System.Drawing.Font("Rustico", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hsmenuLabel.Location = new System.Drawing.Point(448, 472);
            this.hsmenuLabel.Name = "hsmenuLabel";
            this.hsmenuLabel.Size = new System.Drawing.Size(100, 47);
            this.hsmenuLabel.TabIndex = 3;
            this.hsmenuLabel.Text = "MENU";
            this.hsmenuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hsmenuLabel.Click += new System.EventHandler(this.label1_Click);
            this.hsmenuLabel.Leave += new System.EventHandler(this.hsmenuLabel_Leave);
            // 
            // HighscoreScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BrickBreaker.Properties.Resources.backbroundHS;
            this.Controls.Add(this.hsmenuLabel);
            this.Controls.Add(this.hsExitLabel);
            this.Controls.Add(this.hsLabel);
            this.Controls.Add(this.titleBox);
            this.Name = "HighscoreScreen";
            this.Size = new System.Drawing.Size(800, 550);
            ((System.ComponentModel.ISupportInitialize)(this.titleBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox titleBox;
        private System.Windows.Forms.Label hsLabel;
        private System.Windows.Forms.Label hsExitLabel;
        private System.Windows.Forms.Label hsmenuLabel;
    }
}
