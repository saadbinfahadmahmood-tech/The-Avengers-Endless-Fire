using System;
using System.Drawing;
using System.Windows.Forms;
using Game.enums;
using Game.Interfaces;
using Game.Managers;

namespace Game.GameObjects
{

    public class Hero : Character, IHealable, IScoreable
    {
        private const int HudHeight = 65;

        private int maxHealth;
        public override int Health    { get { return health; } }
        public override int MaxHealth { get { return maxHealth; } }
        public int Score { get; set; }

        public Hero(Image character, int x, int y, int width, int height,
                    int speed, int health, int damage, int firingSpeed,
                    Image attackingObjectImg)
            : base(character, x, y, width, height, speed, health, damage,
                   firingSpeed, attackingObjectImg)
        {
            this.maxHealth = health;
            this.Score     = 0;
        }

        public void AddScore(int points) { Score += points; }

        public override void GetHealth(int amount)
        {
            health += amount;
            if (health > maxHealth) health = maxHealth;
        }

        public void ReviveHealth()
        {
            health  = maxHealth;
            isAlive = true;
            Sprite.Show();
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


        public override AttackingObject Attack()
        {
            return new AttackingObject(attackingObjectImg,X + Sprite.Width, Y + Sprite.Height / 2,50, 25, FiringSpeed, damage, directions.Right);
        }


        public override void Move()
        {
            if (InputManagers.moveUp()) 
                Y -= speed;
            if (InputManagers.moveDown())
                Y += speed;
            if (InputManagers.moveLeft())
                X -= speed;
            if (InputManagers.moveRight())
                X += speed;
        }

        public override void checkBoundary(int formWidth, int formHeight)
        {
            if (X < 0)
                X = 0;

            if (Y < HudHeight)
                Y = HudHeight;

            if (X + Sprite.Width > formWidth * 3 / 4)
                X = formWidth * 3 / 4 - Sprite.Width;

            if (Y + Sprite.Height > formHeight)
                Y = formHeight - Sprite.Height;
        }
    }
}
