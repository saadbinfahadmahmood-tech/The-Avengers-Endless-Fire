using EZInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Game.Managers
{
    internal class InputManagers
    {
        public static bool moveUp()
        {
            return Keyboard.IsKeyPressed(Key.UpArrow);
        }
        public static bool moveDown()
        {
            return Keyboard.IsKeyPressed(Key.DownArrow);
        }
        public static bool moveLeft()
        {
            return Keyboard.IsKeyPressed(Key.LeftArrow);
        }
        public static bool moveRight()
        {
            return Keyboard.IsKeyPressed(Key.RightArrow);
        }
        public static bool attack()
        {
            return Keyboard.IsKeyPressed(Key.Space);
        }


        }
}
