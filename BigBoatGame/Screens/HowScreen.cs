using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoatGame.Screens
{
    public partial class HowScreen : UserControl
    {
        Boolean leftKeyDown, rightKeyDown, spaceKeyDown, mKeyDown, escapeKeyDown;
        Plane example, exampleLeft, exampleRight, examplePrimary, exampleSecondary;
        List<Bullet> bullets = new List<Bullet>();
        public HowScreen()
        {
            InitializeComponent();
            DoubleBuffered = true;
            OnStart();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            GameForm.ChangeScreen(this, "MenuScreen");
        }

        private void HowScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Left):
                    leftKeyDown = true;
                    break;
                case (Keys.Right):
                    rightKeyDown = true;
                    break;
                case (Keys.Space):
                    spaceKeyDown = true;
                    break;
                case (Keys.M):
                    mKeyDown = true;
                    break;
                case (Keys.Escape):
                    escapeKeyDown = true;
                    break;
            }
        }

        private void HowScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Left):
                    leftKeyDown = false;
                    break;
                case (Keys.Right):
                    rightKeyDown = false;
                    break;
                case (Keys.Space):
                    spaceKeyDown = false;
                    break;
                case (Keys.M):
                    mKeyDown = false;
                    break;
                case (Keys.Escape):
                    escapeKeyDown = false;
                    break;
            }
        }

        private void HowScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Bullet b in bullets)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), b.rect);
            }
            e.Graphics.DrawImage(example.playerImage(), example.rect);
            e.Graphics.DrawImage(exampleLeft.playerImage(), exampleLeft.rect);
            e.Graphics.DrawImage(exampleRight.playerImage(), exampleRight.rect);
            e.Graphics.DrawImage(examplePrimary.playerImage(), examplePrimary.rect);
            e.Graphics.DrawImage(exampleSecondary.playerImage(), exampleSecondary.rect);
        }

        public void OnStart()
        {
            example = new Plane(1, this.Width / 2 - 25, this.Height / 2 - 25, 0, "F4F_4", 0);
            exampleLeft = new Plane(1, 275, 275, 0, "Dauntless", 0);
            exampleRight = new Plane(1, 25, 575, 0, "Dauntless", 0);
            examplePrimary = new Plane(1, 1000, 275, 1, "Dauntless", 0);
            exampleSecondary = new Plane(1, 1000, 575, 1, "Dauntless", 0);
            howToTimer.Enabled = true;
        }

        private void howToTimer_Tick(object sender, EventArgs e)
        {
            example.Update();
            example.GunPosition();

            exampleLeft.Update();
            exampleLeft.Move();
            exampleLeft.Turn(false);
            exampleLeft.speed = 10;

            exampleRight.Update();
            exampleRight.Move();
            exampleRight.Turn(true);
            exampleRight.speed = 10;


            if (spaceKeyDown && example.shotClock > example.fireRate)
            {
                if (example.gunSide)
                {
                    bullets.Add(example.Shoot(Convert.ToInt16(example.direction), false, true));
                }
                else if (!example.gunSide)
                {
                    bullets.Add(example.Shoot(Convert.ToInt16(example.direction), false, false));
                }
                example.gunSide = !example.gunSide;
            }

            if (rightKeyDown)
            {
                example.Turn(true);
            }
            else if (leftKeyDown)
            {
                example.Turn(false);
            }
            else { }

            foreach (Bullet b in bullets)
            {
                b.Move();
            }

            if (escapeKeyDown)
            {
                GameForm.ChangeScreen(this, "MenuScreen");
                this.Dispose();
            }

            Refresh();
        }
    }
}
