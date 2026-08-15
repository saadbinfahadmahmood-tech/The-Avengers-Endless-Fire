using Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Managers
{
    internal class CollisionsManager
    {
        public static void CheckAttackingObjectCharacterCollision(List<Character> characters, List<AttackingObject> attackingObjects)
        {
            foreach (AttackingObject a in attackingObjects)
            {
                foreach (Character c in characters)
                {
                    if(!a.isDead() && !c.isDead())
                    {
                        if (a.Bounds.IntersectsWith(c.Bounds))
                        {
                            a.Destroy();
                            c.GetDamage(a.damage);
                        }
                    }
                }
            }
        }
        

        public static void CheckAttackingObjectsCollision(List<AttackingObject> a, List<AttackingObject> b)
        {
            foreach (AttackingObject a1 in a)
            {
                foreach (AttackingObject a2 in b)
                {
                    if (!a1.isDead() && !a2.isDead())
                    {
                        if (a1.Bounds.IntersectsWith(a2.Bounds))
                        {
                            a1.Destroy();
                            a2.Destroy();
                        }
                    }
                }
            }
        }
    }
}
