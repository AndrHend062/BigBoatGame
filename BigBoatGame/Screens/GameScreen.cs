using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BigBoatGame.Screens
{
    public partial class GameScreen : UserControl
    {
        Random randGen = new Random();
        SolidBrush hudBrush = new SolidBrush(Color.Moccasin);
        SolidBrush reloadBrush = new SolidBrush(Color.IndianRed);
        Brush textBrush = new SolidBrush(Color.Black);
        Font textFont = new Font("Mongolian Baiti", 16);

        List<Plane> players = new List<Plane>();
        List<Plane> enemies = new List<Plane>();
        List<Carrier> carriers = new List<Carrier>();
        List<Bullet> bullets = new List<Bullet>();
        List<Bullet> enemyBullets = new List<Bullet>();
        SoundPlayer primaryPlayer = new SoundPlayer(Properties.Resources.Primary);
        SoundPlayer secondaryPlayer = new SoundPlayer(Properties.Resources.Secondary);
        SoundPlayer bombPlayer = new SoundPlayer(Properties.Resources.Explosion);
        

        int waves;

        int gameTime, gameScore;
        public Carrier carrier, dummy;
        public Plane player;
        public Plane enemy;
        Boolean upKeyDown, rightKeyDown, leftKeyDown, downKeyDown, wKeyDown, dKeyDown, aKeyDown, sKeyDown, mKeyDown, spaceKeyDown, zKeyDown, xKeyDown, escapeKeyDown,paused;

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

            gameTimer.Start();
            if (GameForm.vs)
            {
                players.Add(player = new Plane(8, 750, 350, 0, "F4F_4" ));
                enemies.Add(player = new Plane(5, 250, 350, 0, "A6M2"));
            }
            else
            {
                if (GameForm.yank == true)
                {
                    players.Add(player = new Plane(8, 250, 550, 0, "F4F_4"));
                }
                else
                {
                    players.Add(player = new Plane(5, 250, 250, 0, "A6M2"));
                }
                carriers.Add(carrier = new Carrier(this.Width / 2 + 120, this.Height / 2 - 225));
                carriers.Add(dummy = new Carrier(this.Width + 100, this.Height / 2 - 225));
            }
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
                case Keys.W:
                    wKeyDown = true;
                    break;
                case Keys.D:
                    dKeyDown = true;
                    break;
                case Keys.A:
                    aKeyDown = true;
                    break;
                case Keys.S:
                    sKeyDown = true;
                    break;
                case Keys.Space:
                    spaceKeyDown = true;
                    break;
                case Keys.M:
                    mKeyDown = true;
                    break;
                case Keys.Z:
                    zKeyDown = true;
                    break;
                case Keys.X:
                    xKeyDown = true;
                    break;
                case Keys.Escape:
                    escapeKeyDown = true;
                    break;
            }
        }


        private void GameScreen_KeyUp(object sender, KeyEventArgs e) // when keys are relesed 
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
                case Keys.W:
                    wKeyDown = false;
                    break;
                case Keys.D:
                    dKeyDown = false;
                    break;
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.S:
                    sKeyDown = false;
                    break;
                case Keys.Space:
                    spaceKeyDown = false;
                    break;
                case Keys.M:
                    mKeyDown = false;
                    break;
                case Keys.Z:
                    zKeyDown = false;
                    break;
                case Keys.X:
                    xKeyDown = false;
                    break;
                case Keys.Escape:
                    escapeKeyDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)// game tick 
        {
            gameTime++;
            BulletStuff(players, enemyBullets, "Japanese Player Wins!");  // bullet collision and updates with players and enemies bullets
            BulletStuff(enemies, bullets, "America Player Wins!"); // bullet collision and updates with enemies and bullets
            ShootStuff(players,bullets, spaceKeyDown, mKeyDown);

            if (GameForm.vs) // vs mode checks
            {
                if (dKeyDown)
                {
                    enemies[0].Turn(true);
                }
                else if (aKeyDown)
                {
                    enemies[0].Turn(false);
                }
                if (rightKeyDown)
                {
                    players[0].Turn(true);
                }
                else if (leftKeyDown)
                {
                    players[0].Turn(false);
                }
                ShootStuff(enemies,enemyBullets, zKeyDown, xKeyDown);
            }
            else/// vs mode end
            {
                foreach (Plane en in enemies) //Enemy Shooting
                {
                    enemyBullets.Add(en.BackShoot(Convert.ToInt16(en.direction) - 5));
                }

                if (enemies.Count == 0) //New Wave
                {
                    gameScore = Convert.ToInt32(GameForm.score);
                    gameScore += carrier.hp;
                    GameForm.score = gameScore;
                    waves++;
                    if (waves == 6)
                    {
                        GameOver("Congratulations! You've fought off all the enemies!", "EndScreen");
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

                foreach (Plane p in enemies) //Enemy movement
                {
                    p.Update();
                    if (p.bombed == false)
                    {
                        p.CarrierAutoTurn(carriers[0]);
                    }
                    else //Head offscreen toward dummy carrier
                    {
                        p.CarrierAutoTurn(carriers[1]);
                        if (p.rect.X > this.Width)
                        {
                            enemies.Remove(p);
                            break;
                        }
                    }
                    p.Move();
                }


                foreach (Plane en in enemies)
                {
                    if (en.Colision(carrier) && en.bombed == false)
                    {
                        bombPlayer.Play();
                        en.bombed = true;
                        en.maxSpeed = 8;
                        carrier.hp -= 5;
                    }
                    if (carrier.hp <= 0)
                    {
                        carrier.hp = 0;
                        GameOver("The carrier has been destroyed. This is a shameful display!", "EndScreen");
                        break;
                    }
                    if (en.Colision(player))
                    {
                        player.hp -= 2;
                        if (player.hp <= 0)
                        {
                            GameOver("You have chrashed into the ocean", "EndScreen");
                        }
                        enemies.Remove(en);
                        break;
                    }
                    
                }
            }
            Refresh();
        }
        public void BulletStuff(List<Plane> planes,List<Bullet> bullets,string winMsg)
        {
            foreach (Bullet b in bullets)
            {
                bool end = false;
                b.Move();
                foreach (Plane p in planes)
                {
                    if (p.Colision(b))
                    {
                        if (b.cannon) { p.hp -= 2; }/// bullet and enemie plane collision
                        else { p.hp -= 1; }
                        if (p.hp <= 0)
                        {
                            if (GameForm.vs)
                            {
                                end = true;
                                GameOver(winMsg, "EndScreen");
                                break;
                            }
                            else
                            {
                                planes.Remove(p);
                            }
                        }
                        end = true;
                        bullets.Remove(b);
                        break;
                    }
                }
                if (end) { break; }
                if (b.rect.X > 1400 || b.rect.X < -10 || b.rect.Y < -10 || b.rect.Y > 800) { bullets.Remove(b); break; }
            }

        }


        public void ShootStuff(List<Plane> planeList,List<Bullet> bulletList,bool key1Down,bool key2Down)
        {
            foreach (Plane p in planeList) ///plane list
            {
                p.OnScreen(gameTime);
                p.Update();
                p.GunPosition();
                p.Move();
                if (key1Down && p.shotClock > p.fireRate && p.ammo1 > 0)
                {
                    primaryPlayer.Play();
                    p.ammo1--;
                    if (p.gunSide)
                    {
                        bulletList.Add(p.Shoot(Convert.ToInt16(p.direction), true, true)); // alternates sides of shoot
                    }
                    else if (!p.gunSide)
                    {
                        bulletList.Add(p.Shoot(Convert.ToInt16(p.direction), true, false));
                    }
                    p.gunSide = !p.gunSide;
                }
                else if (p.ammo1 <= 0)
                {
                    p.PrimaryReload();
                }
                //Secondary Shooting
                if (key2Down && p.shotClock > p.fireRate && p.ammo2 > 0)
                {
                    p.ammo2--;
                    if (GameForm.yank)
                    {
                        primaryPlayer.Play();
                        if (p.gunSide)
                        {
                            bulletList.Add(p.Shoot(Convert.ToInt16(p.direction), false, true));
                        }
                        else if (!p.gunSide)
                        {
                            bulletList.Add(p.Shoot(Convert.ToInt16(p.direction), false, false)); //add boollts
                        }
                        p.gunSide = !p.gunSide;
                    }
                    else
                    {
                        secondaryPlayer.Play();
                        if (p.gunSide)
                        {
                            bulletList.Add(p.Shoot(Convert.ToInt16(p.direction), true, true));
                        }
                        else if (!p.gunSide)
                        {
                            bulletList.Add(p.Shoot(Convert.ToInt16(p.direction), true, false));
                        }
                        p.gunSide = !p.gunSide;
                    }

                }
                else if (p.ammo2 <= 0)
                {
                    p.SecondaryReload(); // reloads when out of ammo
                }

            }
        }

        public void EnemySpawn(string type)
        {
            for (int i = 0; i <= waves * 2; i++)
            {
                int position = 300;

                enemies.Add(enemy = new Plane(2, - 100, position, 0, type));
            }
        }

        public void GameOver(string msg,string screen) /// game over changes screen
        {
            gameTimer.Enabled = false;
            if (!GameForm.vs)
            {
               // GameForm.score = carrier.hp + "";
            }
            GameForm.msg = msg;
            GameForm.ChangeScreen(this, screen);
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Carrier c in carriers)
            {
                if (GameForm.yank)
                {
                    e.Graphics.DrawImage(Properties.Resources.Lexington, c.rect);
                }
                else
                {
                    e.Graphics.DrawImage(Properties.Resources.Shokaku, c.rect);
                }
            }
            foreach (Plane p in players)
            {
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
            foreach (Bullet b in enemyBullets)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Orange), b.rect);
            }

            //HUD
            e.Graphics.FillRectangle(hudBrush, this.Width - 200, 0, 200, this.Height);
            e.Graphics.DrawString("Score: " + GameForm.score, textFont, textBrush, this.Width - 150, 50);
            if (!GameForm.vs)
            {
                e.Graphics.DrawString("Carrier HP: " + carrier.hp, textFont, textBrush, this.Width - 150, 75);
                e.Graphics.DrawString("HP: " + players[0].hp, textFont, textBrush, this.Width - 150, 175);
            }
            else
            {
                e.Graphics.DrawString("Player 1", textFont, reloadBrush, this.Width - 125, 150);
                e.Graphics.DrawString("HP: " + players[0].hp, textFont, textBrush, this.Width - 150, 175);
                //player 2 HUD
                e.Graphics.DrawString("Player 2", textFont, reloadBrush, this.Width - 125, 450);
                e.Graphics.DrawString("HP: " + enemies[0].hp, textFont, textBrush, this.Width - 150, 475);
                e.Graphics.DrawString("Speed: " + enemies[0].speed * 15 + "km/h", textFont, textBrush, this.Width - 150, 500);
                if (enemies[0].reload1)
                {
                    e.Graphics.DrawString("Reload: " + enemies[0].primaryCounter, textFont, reloadBrush, this.Width - 150, 525);
                }
                else
                {
                    e.Graphics.DrawString("Primary: " + enemies[0].ammo1, textFont, textBrush, this.Width - 150, 525);
                }
                if (enemies[0].reload2)
                {
                    e.Graphics.DrawString("Secondary: " + enemies[0].secondaryCounter, textFont, reloadBrush, this.Width - 150, 550);
                }
                else
                {
                    e.Graphics.DrawString("Secondary: " + enemies[0].ammo2, textFont, textBrush, this.Width - 150, 550);
                }
            }

            if (GameForm.yank)
            {
                e.Graphics.DrawString("Speed: " + players[0].speed * 15 + "mph", textFont, textBrush, this.Width - 150, 200);
            }
            else
            {
                e.Graphics.DrawString("Speed: " + players[0].speed * 15 + "km/h", textFont, textBrush, this.Width - 150, 200);
            }
            if (player.reload1)
            {
                e.Graphics.DrawString("Reload: " + players[0].primaryCounter, textFont, reloadBrush, this.Width - 150, 225);
            }
            else
            {
                e.Graphics.DrawString("Primary: " + players[0].ammo1, textFont, textBrush, this.Width - 150, 225);
            }
            if (player.reload2)
            {
                e.Graphics.DrawString("Secondary: " + players[0].secondaryCounter, textFont, reloadBrush, this.Width - 150, 250);
            }
            else
            {
                e.Graphics.DrawString("Secondary: " + players[0].ammo2, textFont, textBrush, this.Width - 150, 250);
            }

        }
    }
}
