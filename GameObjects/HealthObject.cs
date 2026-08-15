using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game.GameObjects
{
    public class HealthObject : GameObject
    {
        private int healthValue;

        public HealthObject(Image sprite, int x, int y, int width, int height, int healthValue)
            : base(sprite, x, y, width, height)
        {
            this.healthValue = healthValue;
        }

        public int GetHealthValue()
        {
            return healthValue;
        }

        public override void Move()
        {
            // It doesnot move 
        }

        public override void checkBoundary(int formWidth, int formHeight)
        {
            // It doesnot react with boundaries
        }
    }
}
