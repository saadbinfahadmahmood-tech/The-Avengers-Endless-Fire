using Game.enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.GameObjects
{
    public class AttackingObject : GameObject
    {
        public int speed { get; set; }
        public int damage { get; set; }
        public enums.directions direction { get; set; }

        public AttackingObject(Image attackingobject, int x, int y,int width,int height, int speed, int damage, enums.directions direction) : base(attackingobject, x, y,width,height)
        {
            this.speed = speed;
            this.damage = damage;
            this.direction = direction;
        }
        public override void Move()
        {
            switch (direction)
            {
                case enums.directions.Left:
                    X -= speed;
                    break;
                case enums.directions.Right:
                    X += speed;
                    break;
            }
        }

        public override void checkBoundary(int formWidth, int formHeight)
        {
            if (X + Sprite.Width > formWidth || X < 0)
            {
                Destroy();
            }
        }
    }
}
