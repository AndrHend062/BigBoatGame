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
    public partial class GameScreen : UserControl
    {
        Random randGen = new Random();
        SolidBrush hudBrush = new SolidBrush(Color.Moccasin);
        Brush textBrush = new SolidBrush(Color.Black);
        Font textFont = new Font("Mongolian Baiti", 12);

        List<Plane> players = new List<Plane>();
        List<Plane> enemies = new List<Plane>();
        List<Carrier> carriers = new List<Carrier>();
        List<Bullet> bullets = new List<Bullet>();

        int waves;
        public static int carrierHP;
        int gameTime, primaryTime, secondaryTime;
        public Carrier carrier;
        public Plane player;
        public Plane enemy;
        Boolean upKeyDown, rightKeyDown, leftKeyDown, downKeyDown, spaceKeyDown, primaryReload, secondaryReload;

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
            DoubleBuffered = true;
        }

        public void OnStart()
        {
            gameTime = 0;
            waves = 0;
            carrierHP = 100;
            gameTimer.Start();

            if (GameForm.yank == true)
            {
                players.Add(player = new Plane(8, 250, 550, 0, "F4F_4"));
            }
            else
            {
                players.Add(player = new Plane(5, 250, 250, 0, "A6M2"));
            }
            carriers.Add(carrier = new Carrier(this.Width / 2 - 40, this.Height / 2 - 225));



        }
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upKeyDown = true;
                    break;
                case Keys.Right:
                    rightKeyDown = true;
                    break;
                case Keys.Left:
                    leftKeyDown = true;
                    break;
                case Keys.Down:
                    downKeyDown = true;
                    break;
                case Keys.Space:
                    spaceKeyDown = true;
                    break;
            }
        }


        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upKeyDown = false;
                    break;
                case Keys.Right:
                    rightKeyDown = false;
                    break;
                case Keys.Left:
                    leftKeyDown = false;
                    break;
                case Keys.Down:
                    downKeyDown = false;
                    break;
                case Keys.Space:
                    spaceKeyDown = false;
                    break;
            }
        }


        private void gameTimer_Tick(object sender, EventArgs e)
        {
            gameTime++;
            foreach (Bullet b in bullets)
            {
                foreach (Plane en in enemies)
                {
                    if (en.Colision(b))
                    {
                        enemies.Remove(en);
                        break;
                    }
                }
            }

            if (enemies.Count == 0) //New Wave
            {
                waves++;
                if (waves == 6)
                {
                    GameOver();
                }
                if (GameForm.yank)
                {
                    EnemySpawn("B7A2");
                }
                else
                {
                    EnemySpawn("Dauntless");
                }

            }

            if (rightKeyDown)
            {
                players[0].Turn(true);
            }
            else if (leftKeyDown)
            {
                players[0].Turn(false);
            }

            foreach (Plane p in enemies)
            {
                p.Update();
                p.AutoTurn(players[0]);
                p.Move();
            }

            foreach (Plane p in players)
            {
                p.OnScreen(gameTime);
                p.Update();
                p.GunPosition();
                p.Move();
                if (spaceKeyDown && p.shotClock > p.fireRate && p.ammo1 > 0)
                {
                    p.ammo1--;
                    if (p.gunSide)
                    {
                        bullets.Add(p.Shoot(Convert.ToInt16(p.direction), true, true));
                    }
                    else if (!p.gunSide)
                    {
                        bullets.Add(p.Shoot(Convert.ToInt16(p.direction), true, false));
                    }
                    p.gunSide = !p.gunSide;
                }
                if (p.ammo1 <= 0)
                {
                    PrimaryReload();
                }
                foreach (Plane en in enemies)
                {
                    p.Colision(en);
                }
            }
            foreach (Bullet b in bullets)
            {
                b.Move();
            }

            Refresh();
        }

        public void PrimaryReload()
        {
            if (primaryReload)
            {
                primaryTime--;
            }
            else
            {
                primaryReload = true;
                primaryTime = 100;
            }

            if (primaryTime == 0 && primaryReload == true)
            {
                primaryReload = false;
                player.ammo1 = 40;
            }
        }

        public void EnemySpawn(string type)
        {
            for (int i = 0; i <= waves * 2; i++)
            {
                int side = randGen.Next(1, 3);
                int position = randGen.Next(1, 4);
                if (side == 1) //Spawn the plane on either the left or right side
                {
                    side = -100;
                }
                else
                {
                    side = this.Width + 100;
                }
                if (position == 1) //Spawn the plane at one of three different y values
                {
                    position = this.Height / 4;
                }
                else if (position == 2)
                {
                    position = this.Height / 2;
                }
                else
                {
                    position = this.Height * (3 / 4);
                }
                enemies.Add(enemy = new Plane(2, side, position, 0, type));
            }
                
        }

        public void GameOver()
        {
            GameForm.ChangeScreen(this, "EndScreen");
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Carrier c in carriers)
            {
                e.Graphics.DrawImage(Properties.Resources.Dauntless_Down, c.rect);
            }
            foreach (Plane p in players)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), p.rect);
                e.Graphics.DrawImage(p.playerImage(), p.rect);
            }
            foreach (Plane p in enemies)
            {
                e.Graphics.DrawImage(p.playerImage(), p.rect);
            }
            foreach (Bullet b in bullets)
            {
                e.Graphics.FillRectangle(hudBrush, b.rect);
            }

            //HUD
            e.Graphics.FillRectangle(hudBrush, this.Width - 200, 0, 200, this.Height);
            e.Graphics.DrawString("Score: " + GameForm.score, textFont, textBrush, this.Width - 150, 50);
            e.Graphics.DrawString("Carrier HP: " + carrierHP, textFont, textBrush, this.Width - 150, 75);
            e.Graphics.DrawString("HP: " + player.hp, textFont, textBrush, this.Width - 150, 175);
            if (GameForm.yank)
            {
                e.Graphics.DrawString("Speed: " + player.speed * 15 + "mph", textFont, textBrush, this.Width - 150, 200);
            }
            else
            {
                e.Graphics.DrawString("Speed: " + player.speed * 15 + "km/h", textFont, textBrush, this.Width - 150, 200);
            }

            if (primaryReload)
            {
                e.Graphics.DrawString("Reload: " + primaryTime, textFont, textBrush, this.Width - 150, 225);
            }
            else
            {
                e.Graphics.DrawString("Primary: " + player.ammo1, textFont, textBrush, this.Width - 150, 225);
            }
            
            e.Graphics.DrawString("Secondary: " + player.ammo2, textFont, textBrush, this.Width - 150, 250);
        }
    }
}
