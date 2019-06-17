using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BigBoatGame
{
    public class Plane
    {
        public Direction direction;
        public int hp, x, y, speed, ammo1, ammo2, shotClock, fireRate, primaryCounter, secondaryCounter, maxSpeed;
        int turnTimer, speedTimer, target,Stagger;
        public bool cannon, gunSide, reload1, reload2;
        public bool bombed = false;
        public Rectangle rect;
        public Point leftGun, rightGun, backGun;
        string name;
        

        public enum Direction
        {
            Up = 0,
            UpRight = 1,
            Right = 2,
            DownRight = 3,
            Down = 4,
            DownLeft = 5,
            Left = 6,
            UpLeft = 7
        }

        public Plane(int _hp, int _x, int _y, int _direction, string _name)
        {
            hp = _hp;
            x = _x;
            y = _y;
            speed = 0;
            direction = (Direction)_direction;
            maxSpeed = 10;

         
            ammo1 = 40;
            ammo2 = 20;
            rect = new Rectangle(x, y, 50, 50);
            name = _name;
            turnTimer = 0;
            shotClock = 0;
            speedTimer = 0;
            fireRate = 5;
            
            switch (name)
            {
                case "F4F_4":
                    cannon = false;
                    ammo1 = 40;
                    ammo2 = 40;
                    break;
                case "A6M2":
                    cannon = true;
                    ammo1 = 40;
                    ammo2 = 20;
                    break;
                case "Dauntless":
                    cannon = false;
                    hp = 2;
                    ammo1 = 40;
                    ammo2 = 0;
                    maxSpeed = 5;
                    Stagger = GameForm.rand.Next(10, 50);
                    target = GameForm.rand.Next(150, 600);
                    rect.Y = target;
                    rect.X -= Stagger;
                    break;
                case "B7A2":
                    cannon = false;
                    hp = 1;
                    ammo1 = 40;
                    ammo2 = 0;
                    maxSpeed = 5;
                    Stagger = GameForm.rand.Next(10, 50);
                    target = GameForm.rand.Next(150, 600);
                    rect.Y = target;
                    rect.X -= Stagger;
                    break;
            }


        }

        public void Move()
        {
            if (speed < maxSpeed && speedTimer > 3)
            {
                speed++;
                speedTimer = 0;
            }
            switch (direction)
            {
                case Direction.Up:
                    rect.Y -= speed;
                    break;
                case Direction.UpRight:
                    rect.Y -= speed * 2 / 3;
                    rect.X += speed * 2 / 3;
                    break;
                case Direction.Right:
                    rect.X += speed;
                    break;
                case Direction.DownRight:
                    rect.Y += speed * 2 / 3;
                    rect.X += speed * 2 / 3;
                    break;
                case Direction.Down:
                    rect.Y += speed;
                    break;
                case Direction.DownLeft:
                    rect.Y += speed * 2 / 3;
                    rect.X -= speed * 2 / 3;
                    break;
                case Direction.Left:
                    rect.X -= speed;
                    break;
                case Direction.UpLeft:
                    rect.Y -= speed * 2 / 3;
                    rect.X -= speed * 2 / 3;
                    break;
            }


        }

        public void CarrierAutoTurn(Carrier p)
        {
            if (turnTimer > 10)
            {

                Direction changer = direction;

                if (p.rect.X > rect.X && target + 25 > rect.Y && target - 25 < rect.Y)
                {
                    direction = Direction.Right;
                }
                else if (p.rect.X < rect.X && target + 25 > rect.Y && target - 25 < rect.Y)
                {
                    direction = Direction.Left;
                }
                else if (target > rect.Y && p.rect.X + 25 > rect.X && p.rect.X - 25 < rect.X)
                {
                    direction = Direction.Down;
                }
                else if (target < rect.Y && p.rect.X + 25 > rect.X && p.rect.X - 25 < rect.X)
                {
                    direction = Direction.Up;
                }
                else if (p.rect.X > rect.X && target > rect.Y)
                {
                    direction = Direction.DownRight;
                }
                else if (p.rect.X > rect.X && target < rect.Y)
                {
                    direction = Direction.UpRight;
                }
                else if (p.rect.X < rect.X && target > rect.Y)
                {
                    direction = Direction.DownLeft;
                }
                else if (p.rect.X < rect.X && target < rect.Y)
                {
                    direction = Direction.UpLeft;
                }

                if (changer != direction)
                {
                    speed -= 3;
                    turnTimer = 0;
                }
            }
        }

        public void Turn(Boolean right)
        {
            if (turnTimer > 10 && right)
            {
                speed -= 3;
                switch (direction)
                {
                    case Direction.Up:
                        direction = Direction.UpRight;
                        turnTimer = 0;
                        break;
                    case Direction.UpRight:
                        direction = Direction.Right;
                        turnTimer = 0;
                        break;
                    case Direction.Right:
                        direction = Direction.DownRight;
                        turnTimer = 0;
                        break;
                    case Direction.DownRight:
                        direction = Direction.Down;
                        turnTimer = 0;
                        break;
                    case Direction.Down:
                        direction = Direction.DownLeft;
                        turnTimer = 0;
                        break;
                    case Direction.DownLeft:
                        direction = Direction.Left;
                        turnTimer = 0;
                        break;
                    case Direction.Left:
                        direction = Direction.UpLeft;
                        turnTimer = 0;
                        break;
                    case Direction.UpLeft:
                        direction = Direction.Up;
                        turnTimer = 0;
                        break;
                }
            }
            else if (turnTimer > 10 & !right)
            {
                speed -= 3;
                switch (direction)
                {
                    case Direction.Up:
                        direction = Direction.UpLeft;
                        turnTimer = 0;
                        break;
                    case Direction.UpRight:
                        direction = Direction.Up;
                        turnTimer = 0;
                        break;
                    case Direction.Right:
                        direction = Direction.UpRight;
                        turnTimer = 0;
                        break;
                    case Direction.DownRight:
                        direction = Direction.Right;
                        turnTimer = 0;
                        break;
                    case Direction.Down:
                        direction = Direction.DownRight;
                        turnTimer = 0;
                        break;
                    case Direction.DownLeft:
                        direction = Direction.Down;
                        turnTimer = 0;
                        break;
                    case Direction.Left:
                        direction = Direction.DownLeft;
                        turnTimer = 0;
                        break;
                    case Direction.UpLeft:
                        direction = Direction.Left;
                        turnTimer = 0;
                        break;
                }
            }
        }
        public Boolean Colision(Plane p)
        {
            return (rect.IntersectsWith(p.rect));
        }
        public Boolean Colision(Bullet b)
        {
            return (rect.IntersectsWith(b.rect));
        }
        public Boolean Colision(Carrier c)
        {
            return (rect.IntersectsWith(c.rect));
        }
        public void OnScreen(int time) // make sure the plane stays on screen
        {

            if (rect.X > 1060)
            {

                direction = Direction.Left;
            }
            if (rect.X < -0)
            {

                direction = Direction.Right;
            }
            if (rect.Y > 720)
            {

                direction = Direction.Up;
            }
            if (rect.Y < -0)
            {

                direction = Direction.Down;
            }

        }

        public Bullet Shoot(int shootDirection, bool cannon, bool side)
        {
            if (side)
            {
                shotClock = 0;
                Bullet b = new Bullet(rightGun.X - 2, rightGun.Y - 2, cannon, shootDirection);
                return b;
            }
            else if (!side)
            {
                shotClock = 0;
                Bullet b = new Bullet(leftGun.X - 2, leftGun.Y - 2, cannon, shootDirection);
                return b;
            }
            Bullet bullet = new Bullet(rect.X + 23, rightGun.Y + 23, false, shootDirection);
            return bullet;
        }

        //public Bullet BackShoot(int shootDirection)
        //{
        //        shotClock = 0;
        //        Bullet b = new Bullet(backGun.X, backGun.Y, false, shootDirection);
        //        return b;
        //}


        public void GunPosition()
        {
            switch (direction)
            {
                case Direction.Up:
                    leftGun = new Point(rect.X + 8, rect.Y + 12);
                    rightGun = new Point(rect.X + 42, rect.Y + 12);
                    backGun = new Point(rect.X + 25, rect.Y + 56);
                    break;
                case Direction.UpRight:
                    leftGun = new Point(rect.X + 20, rect.Y + 7);
                    rightGun = new Point(rect.X + 43, rect.Y + 30);
                    backGun = new Point(rect.X - 6, rect.Y + 56);
                    break;
                case Direction.Right:
                    leftGun = new Point(rect.X + 38, rect.Y + 8);
                    rightGun = new Point(rect.X + 38, rect.Y + 42);
                    backGun = new Point(rect.X - 6, rect.Y + 25);
                    break;
                case Direction.DownRight:
                    leftGun = new Point(rect.X + 43, rect.Y + 20);
                    rightGun = new Point(rect.X + 20, rect.Y + 43);
                    backGun = new Point(rect.X - 6, rect.Y - 6);
                    break;
                case Direction.Down:
                    leftGun = new Point(rect.X + 8, rect.Y + 38);
                    rightGun = new Point(rect.X + 42, rect.Y + 38);
                    backGun = new Point(rect.X + 25, rect.Y - 6);
                    break;
                case Direction.DownLeft:
                    leftGun = new Point(rect.X + 7, rect.Y + 20);
                    rightGun = new Point(rect.X + 30, rect.Y + 43);
                    backGun = new Point(rect.X + 56, rect.Y - 6);
                    break;
                case Direction.Left:
                    leftGun = new Point(rect.X + 8, rect.Y + 12);
                    rightGun = new Point(rect.X + 8, rect.Y + 38);
                    backGun = new Point(rect.X + 56, rect.Y + 25);
                    break;
                case Direction.UpLeft:
                    leftGun = new Point(rect.X + 7, rect.Y + 30);
                    rightGun = new Point(rect.X + 30, rect.Y + 7);
                    backGun = new Point(rect.X + 56, rect.Y + 56);
                    break;
            }
        }

        public void PrimaryReload()
        {
            if (reload1)
            {
                primaryCounter--;
            }
            else
            {
                reload1 = true;
                primaryCounter = 100;
            }

            if (primaryCounter == 0 && reload1 == true)
            {
                reload1 = false;
                ammo1 = 40;
            }
        }

        public void SecondaryReload()
        {
            if (reload2)
            {
                secondaryCounter--;
            }
            else
            {
                reload2 = true;
                secondaryCounter = 100;
            }

            if (secondaryCounter == 0 && reload2 == true)
            {
                reload2 = false;
                if (GameForm.yank)
                {
                    ammo2 = 40;
                }
                else
                {
                    ammo2 = 20;
                }
                
            }
        }

        public Image playerImage()             // i hate this but it works
        {
            switch (name)
            {
                case "F4F_4":
                    switch (direction)
                    {
                        case Direction.Up:
                            return Properties.Resources.F4F_4_Up;
                        case Direction.UpRight:
                            return Properties.Resources.F4F_4_UpRight;
                        case Direction.Right:
                            return Properties.Resources.F4F_4_Right;
                        case Direction.DownRight:
                            return Properties.Resources.F4F_4_DownRight;
                        case Direction.Down:
                            return Properties.Resources.F4F_4_Down;
                        case Direction.DownLeft:
                            return Properties.Resources.F4F_4_DownLeft;
                        case Direction.Left:
                            return Properties.Resources.F4F_4_Left;
                        case Direction.UpLeft:
                            return Properties.Resources.F4F_4_UpLeft;
                    }
                    return Properties.Resources.F4F_4_Up;

                case "A6M2":
                    switch (direction)                // TODO chage images
                    {
                        case Direction.Up:
                            return Properties.Resources.A6M2_Up;
                        case Direction.UpRight:
                            return Properties.Resources.A6M2_UpRight;
                        case Direction.Right:
                            return Properties.Resources.A6M2_Right;
                        case Direction.DownRight:
                            return Properties.Resources.A6M2_DownRight;
                        case Direction.Down:
                            return Properties.Resources.A6M2_Down;
                        case Direction.DownLeft:
                            return Properties.Resources.A6M2_DownLeft;
                        case Direction.Left:
                            return Properties.Resources.A6M2_Left;
                        case Direction.UpLeft:
                            return Properties.Resources.A6M2_UpLeft;
                    }
                    return Properties.Resources.F4F_4_Up;

                case "Dauntless":
                    switch (direction)
                    {
                        case Direction.Up:
                            return Properties.Resources.Dauntless_Up;
                        case Direction.UpRight:
                            return Properties.Resources.Dauntless_UpRight;
                        case Direction.Right:
                            return Properties.Resources.Dauntless_Right;
                        case Direction.DownRight:
                            return Properties.Resources.Dauntless_DownRight;
                        case Direction.Down:
                            return Properties.Resources.Dauntless_Down;
                        case Direction.DownLeft:
                            return Properties.Resources.Dauntless_DownLeft;
                        case Direction.Left:
                            return Properties.Resources.Dauntless_Left;
                        case Direction.UpLeft:
                            return Properties.Resources.Dauntless_UpLeft;
                    }
                    return Properties.Resources.Dauntless_Up;

                case "B7A2":
                    switch (direction)                        // TODO change image directory when images are done
                    {
                        case Direction.Up:
                            return Properties.Resources.A6M2_Up;
                        case Direction.UpRight:
                            return Properties.Resources.A6M2_UpRight;
                        case Direction.Right:
                            return Properties.Resources.A6M2_Right;
                        case Direction.DownRight:
                            return Properties.Resources.A6M2_DownRight;
                        case Direction.Down:
                            return Properties.Resources.A6M2_Down;
                        case Direction.DownLeft:
                            return Properties.Resources.A6M2_DownLeft;
                        case Direction.Left:
                            return Properties.Resources.A6M2_Left;
                        case Direction.UpLeft:
                            return Properties.Resources.A6M2_UpLeft;
                    }
                    return Properties.Resources.F4F_4_Up;


            }
            return Properties.Resources.F4F_4_Up;
        }


        public void Update()
        {
            turnTimer++;
            shotClock++;
            speedTimer++;
        }
    }
}
