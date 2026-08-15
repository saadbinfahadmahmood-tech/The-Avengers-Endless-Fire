using Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GamePlay
{
    public class HealthPickupSpawner
    {
        private GameObjectsRepository factory;
        private Random rng = new Random();

        public HealthPickupSpawner(GameObjectsRepository factory)
        {
            this.factory = factory;
        }

        public HealthObject SpawnRandom(int formWidth, int formHeight)
        {
            int x = rng.Next(60, formWidth /3  - 60);
            int y = rng.Next(60, formHeight - 60);
            return factory.CreateHealthPickup(x, y);
        }
    }
}
