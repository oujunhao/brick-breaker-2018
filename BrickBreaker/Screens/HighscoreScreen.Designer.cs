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
            // HighscoreScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BrickBreaker.Properties.Resources.backbroundHS;
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
    }
}
