using Game.GameObjects;
using Game.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.GamePlay
{
    public class GameObjectsRepository
    {

        private Form form;

        public GameObjectsRepository(Form f)
        {
            form = f;
        }

        public Hero CreateIronMan()
        {
            //  balance speed, damage and health
            return new Hero(Resources.IronMan, 20, form.Height / 2, 100, 140, 20, 100, 25, 40, Resources.IronMan_AttackingObject);
        }

        public Hero CreateCaptionAmerica()
        {
            // more health, moderate speed and damage
            return new Hero(Resources.CaptionAmerica, 20, form.Height / 2, 90, 126, 16, 120, 22, 35, Resources.CaptionAmerica_AttackingObject);
        }

        public Hero CreateThor()
        {
            // stronger attack, slower speed 
            return new Hero(Resources.Thor, 20, form.Height / 2, 92, 140, 18, 120, 30, 35, Resources.Thor_AttackingObject);
        }

        public Hero CreateHulk()
        {
            // very high health and damage, but slow
            return new Hero(Resources.Hulk, 20, form.Height / 2, 100, 150, 12, 180, 35, 32, Resources.Hulk_AttackingObject);
        }

        public Hero CreateSpiderMan()
        {
            // very fast, lower health and damage, faster firing
            return new Hero(Resources.SpiderMan, 20, form.Height / 2, 80, 130, 26, 90, 18, 43, Resources.SpiderMan_AttackingObject);
        }

        public Villain CreateThanos()
        {
            // Thanos: heavy boss, high health and damage, slow firing and movement
            return new Villain(Resources.Thanos, form.Width - 120, form.Height / 2, 100, 150, 15, 24, 30, 220, Resources.Thanos_AttackingObject);
        }

        public Villain CreateUltron()
        {
            // Ultron: balanced enemy, moderate speed and firing
            return new Villain(Resources.Ultron, form.Width - 120, form.Height / 2, 90, 140, 19, 25, 24, 160, Resources.Ultron_AttackingObject);
        }

        public Villain CreateVenom()
        {
            // Venom: faster enemy with lower health but tricky attack
            return new Villain(Resources.Venom, form.Width - 120, form.Height / 2, 100, 150, 14, 15, 20, 140, Resources.venom_attackingobject);
        }

        public Villain CreateDoctorDoom()
        {
            //fires many shots , moderate health
            return new Villain(Resources.DoctorDoom, form.Width - 120, form.Height / 2, 92, 142, 10, 15, 22, 170, Resources.DoctorDoom_AttackingObject);
        }

        public HealthObject CreateHealthPickup(int x, int y)
        {
            return new HealthObject(Resources.HealthSprite, x, y, 50, 50, 30);
        }
    }
}
