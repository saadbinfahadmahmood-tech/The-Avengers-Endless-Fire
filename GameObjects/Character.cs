using System;
using System.Drawing;
using System.Windows.Forms;
using Game.Interfaces;

namespace Game.GameObjects
{
    public abstract class Character : GameObject, IAttackable, IDamageable
    {
        protected int speed;
        protected int health;
        protected int damage;
        protected int FiringSpeed;
        protected Image attackingObjectImg;

        public abstract int Health    { get; }
        public abstract int MaxHealth { get; }

        public Character(Image sprite, int x, int y, int width, int height,
                         int speed, int health, int damage, int firingSpeed,
                         Image attackingObjectImg)
            : base(sprite, x, y, width, height)
        {
            this.speed             = speed;
            this.health            = health;
            this.damage            = damage;
            this.FiringSpeed       = firingSpeed;
            this.attackingObjectImg = attackingObjectImg;
        }

        public abstract override void Move();
        public abstract override void checkBoundary(int formWidth, int formHeight);

        public abstract AttackingObject Attack();          
        public abstract void GetDamage(int damage);       
        public abstract void GetHealth(int amount);       
    }
}
