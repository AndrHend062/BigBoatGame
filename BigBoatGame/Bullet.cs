using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BigBoatGame
{
    public class Bullet
    {
        public int x, y, speed, direction;
        public bool cannon;
        public Rectangle rect;

        public Bullet(int _x, int _y, bool _cannon,int _direction)// need some way to know if the plane has power up 
        {
            x = _x;
            y = _y;
            speed = 15;  // * by power ups 
            cannon = _cannon;
            rect = new Rectangle(x, y, 5, 5);
            direction = _direction;
        }

        public void Move()
        {
            switch (direction)
            {
                case 0: //up
                    rect.Y -= speed;
                    break;
                case 1: //upRight
                    rect.Y -= speed * 2 / 3;
                    rect.X += speed * 2 / 3;
                    break;
                case 2: //right
                    rect.X += speed;
                    break;
                case 3: //downRight
                    rect.Y += speed * 2 / 3;
                    rect.X += speed * 2 / 3;
                    break;
                case 4: //down
                    rect.Y += speed;
                    break;
                case 5: //downLeft
                    rect.Y += speed * 2 / 3;
                    rect.X -= speed * 2 / 3;
                    break;
                case 6: //left
                    rect.X -= speed;
                    break;
                case 7: //upLeft
                    rect.Y -= speed * 2 / 3;
                    rect.X -= speed * 2 / 3;
                    break;
            }
        }
    }
}
