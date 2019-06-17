namespace BigBoatGame.Screens
{
    partial class EndScreen
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
            this.carrierBox = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.oneLabel = new System.Windows.Forms.Label();
            this.twoLabel = new System.Windows.Forms.Label();
            this.threeLabel = new System.Windows.Forms.Label();
            this.ContinueLabel = new System.Windows.Forms.Label();
            this.msgLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.carrierBox)).BeginInit();
            this.SuspendLayout();
            // 
            // carrierBox
            // 
            this.carrierBox.BackColor = System.Drawing.Color.Transparent;
            this.carrierBox.BackgroundImage = global::BigBoatGame.Properties.Resources.Shokaku;
            this.carrierBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.carrierBox.Location = new System.Drawing.Point(155, 77);
            this.carrierBox.Name = "carrierBox";
            this.carrierBox.Size = new System.Drawing.Size(80, 450);
            this.carrierBox.TabIndex = 1;
            this.carrierBox.TabStop = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.LightSlateGray;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(423, 132);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(90, 24);
            this.scoreLabel.TabIndex = 2;
            this.scoreLabel.Text = "la ywyeyy";
            // 
            // oneLabel
            // 
            this.oneLabel.BackColor = System.Drawing.Color.Transparent;
            this.oneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneLabel.Location = new System.Drawing.Point(704, 223);
            this.oneLabel.Name = "oneLabel";
            this.oneLabel.Size = new System.Drawing.Size(70, 75);
            this.oneLabel.TabIndex = 3;
            this.oneLabel.Text = "A";
            // 
            // twoLabel
            // 
            this.twoLabel.BackColor = System.Drawing.Color.Transparent;
            this.twoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoLabel.Location = new System.Drawing.Point(813, 223);
            this.twoLabel.Name = "twoLabel";
            this.twoLabel.Size = new System.Drawing.Size(70, 75);
            this.twoLabel.TabIndex = 4;
            this.twoLabel.Text = "A";
            // 
            // threeLabel
            // 
            this.threeLabel.BackColor = System.Drawing.Color.Transparent;
            this.threeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.threeLabel.Location = new System.Drawing.Point(922, 223);
            this.threeLabel.Name = "threeLabel";
            this.threeLabel.Size = new System.Drawing.Size(70, 75);
            this.threeLabel.TabIndex = 5;
            this.threeLabel.Text = "A";
            // 
            // ContinueLabel
            // 
            this.ContinueLabel.AutoSize = true;
            this.ContinueLabel.BackColor = System.Drawing.Color.LightSlateGray;
            this.ContinueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContinueLabel.Location = new System.Drawing.Point(752, 483);
            this.ContinueLabel.Name = "ContinueLabel";
            this.ContinueLabel.Size = new System.Drawing.Size(207, 20);
            this.ContinueLabel.TabIndex = 6;
            this.ContinueLabel.Text = "Press Green to Continue";
            // 
            // msgLabel
            // 
            this.msgLabel.AutoSize = true;
            this.msgLabel.BackColor = System.Drawing.Color.LightSlateGray;
            this.msgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgLabel.Location = new System.Drawing.Point(427, 77);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(340, 25);
            this.msgLabel.TabIndex = 7;
            this.msgLabel.Text = "you you you you you you you you ";
            // 
            // EndScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BigBoatGame.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.ContinueLabel);
            this.Controls.Add(this.threeLabel);
            this.Controls.Add(this.twoLabel);
            this.Controls.Add(this.oneLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.carrierBox);
            this.Name = "EndScreen";
            this.Size = new System.Drawing.Size(1300, 730);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.EndScreen_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.carrierBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox carrierBox;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label oneLabel;
        private System.Windows.Forms.Label twoLabel;
        private System.Windows.Forms.Label threeLabel;
        private System.Windows.Forms.Label ContinueLabel;
        private System.Windows.Forms.Label msgLabel;
    }
}
