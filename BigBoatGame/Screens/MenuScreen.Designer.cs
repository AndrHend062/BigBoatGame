namespace BigBoatGame.Screens
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
            this.startButton = new System.Windows.Forms.Button();
            this.highscoreButton = new System.Windows.Forms.Button();
            this.howButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.flipperButton = new System.Windows.Forms.Button();
            this.vsButton = new System.Windows.Forms.Button();
            this.displayBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.displayBox)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(865, 173);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(307, 46);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start Game";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // highscoreButton
            // 
            this.highscoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.highscoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoreButton.Location = new System.Drawing.Point(865, 314);
            this.highscoreButton.Name = "highscoreButton";
            this.highscoreButton.Size = new System.Drawing.Size(307, 46);
            this.highscoreButton.TabIndex = 2;
            this.highscoreButton.Text = "Aces Lounge   (Highscores)";
            this.highscoreButton.UseVisualStyleBackColor = true;
            this.highscoreButton.Click += new System.EventHandler(this.highscoreButton_Click);
            // 
            // howButton
            // 
            this.howButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.howButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howButton.Location = new System.Drawing.Point(865, 381);
            this.howButton.Name = "howButton";
            this.howButton.Size = new System.Drawing.Size(307, 46);
            this.howButton.TabIndex = 3;
            this.howButton.Text = "Flight School ";
            this.howButton.UseVisualStyleBackColor = true;
            this.howButton.Click += new System.EventHandler(this.howButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exitButton.Location = new System.Drawing.Point(885, 665);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(265, 46);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Retire   (Exit Game)";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // flipperButton
            // 
            this.flipperButton.BackColor = System.Drawing.Color.Navy;
            this.flipperButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flipperButton.Font = new System.Drawing.Font("Mixage Bk BT", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flipperButton.ForeColor = System.Drawing.Color.Black;
            this.flipperButton.Location = new System.Drawing.Point(918, 20);
            this.flipperButton.Name = "flipperButton";
            this.flipperButton.Size = new System.Drawing.Size(200, 121);
            this.flipperButton.TabIndex = 5;
            this.flipperButton.UseVisualStyleBackColor = false;
            this.flipperButton.Click += new System.EventHandler(this.flipperButton_Click);
            // 
            // vsButton
            // 
            this.vsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vsButton.Location = new System.Drawing.Point(865, 245);
            this.vsButton.Name = "vsButton";
            this.vsButton.Size = new System.Drawing.Size(307, 46);
            this.vsButton.TabIndex = 1;
            this.vsButton.Text = "Dogfight ";
            this.vsButton.UseVisualStyleBackColor = true;
            this.vsButton.Click += new System.EventHandler(this.vsButton_Click);
            // 
            // displayBox
            // 
            this.displayBox.BackgroundImage = global::BigBoatGame.Properties.Resources.A6M2_UpRight;
            this.displayBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.displayBox.Location = new System.Drawing.Point(84, 3);
            this.displayBox.Name = "displayBox";
            this.displayBox.Size = new System.Drawing.Size(720, 720);
            this.displayBox.TabIndex = 6;
            this.displayBox.TabStop = false;
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::BigBoatGame.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.displayBox);
            this.Controls.Add(this.vsButton);
            this.Controls.Add(this.flipperButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.howButton);
            this.Controls.Add(this.highscoreButton);
            this.Controls.Add(this.startButton);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(1300, 734);
            ((System.ComponentModel.ISupportInitialize)(this.displayBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button highscoreButton;
        private System.Windows.Forms.Button howButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button flipperButton;
        private System.Windows.Forms.Button vsButton;
        private System.Windows.Forms.PictureBox displayBox;
    }
}
