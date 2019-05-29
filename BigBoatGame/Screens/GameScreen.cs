﻿using System;
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
        SolidBrush hudBrush = new SolidBrush(Color.Moccasin);
        Brush textBrush = new SolidBrush(Color.Black);
        Font textFont = new Font("Mongolian Baiti", 12);

        List<Plane> players = new List<Plane>();
        List<Plane> enemies = new List<Plane>();
        List<Carrier> carriers = new List<Carrier>();
        List<Bullet> bullets = new List<Bullet>();

        int waves;
        public static int carrierHP;
        public Carrier carrier;
        public Plane player;
        public Plane enemy;
        Boolean upKeyDown, rightKeyDown, leftKeyDown, downKeyDown, spaceKeyDown;

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
            DoubleBuffered = true;
        }

        public void OnStart()
        {
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
            carriers.Add(carrier = new Carrier(400, 400));



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
            if (enemies.Count == 0) //New Wave
            {
                waves++;
                if (waves == 6)
                {
                    GameOver();
                }
                if (GameForm.yank)
                {
                    for (int i = 0; i <= waves * 2; i++)
                    {
                        enemies.Add(enemy = new Plane(1, 250, 550, 0, "B7A2"));
                    }
                }
                else
                {
                    for (int i = 0; i <= waves * 2; i++)
                    {
                        enemies.Add(enemy = new Plane(2, 250, 550, 0, "Dauntless"));
                    }
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

            foreach (Plane p in players)
            {
                p.Update();
                p.Move();
                if (spaceKeyDown)
                {
                    bullets.Add(p.Shoot(Convert.ToInt16(p.direction), true));
                }
                foreach (Plane en in enemies)
                {
                    
                }
            }
            foreach (Bullet b in bullets)
            {
               b.Move();
            }

            Refresh();
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
                e.Graphics.DrawImage(p.playerImage(), p.planeRect);
            }
            foreach (Plane p in enemies)
            {
                e.Graphics.DrawImage(p.playerImage(), p.planeRect);
            }
            foreach (Bullet b in bullets)
            {
                e.Graphics.FillRectangle(hudBrush, b.bulletRect);
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
            e.Graphics.DrawString("Primary: " + player.ammo1, textFont, textBrush, this.Width - 150, 225);
            e.Graphics.DrawString("Secondary: " + player.ammo2, textFont, textBrush, this.Width - 150, 250);
        }
    }
}
