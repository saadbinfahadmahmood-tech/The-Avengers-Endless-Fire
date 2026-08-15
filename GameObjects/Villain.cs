using Game.enums;
using Game.Interfaces;
using System;
using System.Drawing;

namespace Game.GameObjects
{
    public class Villain : Character
    {
        private const int HudHeight = 65;

        private directions direction;

        private int baseSpeed;
        private int baseFiringSpeed;
        private int baseDamage;
        private int baseHealth;

        public override int Health { get { return health; } }
        public override int MaxHealth { get { return baseHealth; } }

        public Villain(Image img, int x, int y, int width, int height, int speed, int firingSpeed, int damage, int health, Image attackingObject)
            : base(img, x, y, width, height, speed, health, damage, firingSpeed, attackingObject)
        {
            direction = directions.Down;
            baseSpeed = speed;
            baseFiringSpeed = firingSpeed;
            baseDamage = damage;
            baseHealth = health;
        }

        public void PowerUp(int level)
        {
            int extra = level - 1;
            speed = baseSpeed + extra * 3;
            FiringSpeed = Math.Max(5, baseFiringSpeed - extra * 3);
            damage = baseDamage + extra * 5;
            health = baseHealth + extra * 20;
        }

        public void ResetForNewRound(int startX, int startY, int level)
        {
            isAlive = true;
            X = startX;
            Y = startY;
            direction = directions.Down;
            Sprite.Show();
            PowerUp(level);
        }


        public override AttackingObject Attack()
        {
            return new AttackingObject( attackingObjectImg, X - 30, Y + Sprite.Height / 2, 50, 25, FiringSpeed, damage, directions.Left);
        }


        public override void Move()
        {
            if (direction == directions.Up)
                Y -= speed;
            else
                Y += speed;
        }

        public override void checkBoundary(int formWidth, int formHeight)
        {
            if (Y + Sprite.Height > formHeight)
                direction = directions.Up;
            else if (Y < HudHeight)
            {
                Y = HudHeight;   
                direction = directions.Down;
            }
        }

        public override void GetDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                Destroy();
            }
        }

        public override void GetHealth(int amount)
        {
            health += amount;
        }
    }
}
