using Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GamePlay
{
    public class VillainSpawner
    {
        private Villain[] villains;
        private Random rng = new Random();
        private int lastIndex = -1;

        public VillainSpawner(GameObjectsRepository factory)
        {
            villains = new Villain[]
            {
                factory.CreateThanos(),
                factory.CreateUltron(),
                factory.CreateVenom(),
                factory.CreateDoctorDoom()
            };
        }

        public Villain[] AllVillains { get { return villains; } }


        public Villain SpawnNext(int spawnX, int spawnY, int level)
        {
            int index;
            do
            { 
                index = rng.Next(villains.Length);
            }
            while (villains.Length > 1 && index == lastIndex);

            lastIndex = index;
            Villain v = villains[index];
            v.ResetForNewRound(spawnX, spawnY, level);
            return v;
        }
    }
}
