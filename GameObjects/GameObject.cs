
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.GameObjects
{
    public abstract class GameObject
    {
        public PictureBox Sprite { get; set; }
        

        protected int X
        {
            get { return Sprite.Left; }
            set { Sprite.Left = value; }
        }
        protected int Y
        {
            get { return Sprite.Top; }
            set { Sprite.Top = value; }
        }
        public Rectangle Bounds
        {
            get { return Sprite.Bounds; }
        }

        protected bool isAlive { get; set; } = true;

        public void Destroy()
        {
            isAlive = false;
            Sprite.Hide();
        }
        public GameObject(Image character, int x, int y,int width, int height)
        {
            Sprite = new PictureBox();
            Sprite.Image = character;
            Sprite.SizeMode = PictureBoxSizeMode.StretchImage;
            Sprite.Width = width;
            Sprite.Height = height;
            Sprite.BackColor = Color.Transparent;
            X = x;
            Y = y;
        }
        public abstract void Move();
        public abstract void checkBoundary(int formWidth, int formHeight);

        public bool isDead()
        {
            return !isAlive;
        }
    }
}
