using Game.GameObjects;
using Game.Interfaces;
using Game.Properties;
using System;
using System.Collections.Generic;
using Game.enums;
using System.Drawing;
using System.Windows.Forms;
using Game.Managers;

namespace Game.GamePlay
{
    public class GameBL
    {
        private const int HeroMaxFireInterval = 20;

        private const int VillainBaseFireInterval = 30;

        private const int VillainMinFireInterval = 8;

        public Form form;
        public static int level = 1;

        public static Character CurrentHero;
        public static Characters CurrentHeroName;
        public static Villain CurrentVillain;

        private static Hero IronMan;
        private static Hero CaptionAmerica;
        private static Hero SpiderMan;
        private static Hero Thor;
        private static Hero Hulk;

        private static VillainSpawner villainSpawner;
        private static HealthPickupSpawner healthSpawner;

        private static List<AttackingObject> heroAttacks = new List<AttackingObject>();
        private static List<AttackingObject> villainAttacks = new List<AttackingObject>();
        private static List<HealthObject> healthPickups = new List<HealthObject>();

        private static int heroFiringCounter = 0;
        private static int villainFiringCounter = 0;
        private static int healthSpawnCounter = 0;
        private const int HealthSpawnInterval = 400;

        public static ProgressBar pbHeroHealth;
        public static ProgressBar pbVillainHealth;
        public static Label lblLevel;
        public static Label lblScore;

        public GameBL(Form f)
        {
            form = f;
            GameObjectsRepository factory = new GameObjectsRepository(f);

            IronMan = factory.CreateIronMan();
            CaptionAmerica = factory.CreateCaptionAmerica();
            Thor = factory.CreateThor();
            Hulk = factory.CreateHulk();
            SpiderMan = factory.CreateSpiderMan();

            villainSpawner = new VillainSpawner(factory);
            healthSpawner = new HealthPickupSpawner(factory);
        }

        public void Start()
        {
            level = 1;
            ClearAllAttacks();

            for (int i = healthPickups.Count - 1; i >= 0; i--)
                healthPickups[i].Sprite.Parent?.Controls.Remove(healthPickups[i].Sprite);

            healthPickups.Clear();
            heroFiringCounter = 0;
            villainFiringCounter = 0;
            healthSpawnCounter = 0;

            SetupHero();
            SpawnVillain();
        }

        public static void StartNextLevel()
        {
            level++;
            ClearAllAttacks();

            foreach (HealthObject h in healthPickups)
                h.Sprite.Parent?.Controls.Remove(h.Sprite);
            healthPickups.Clear();
            (CurrentHero as IHealable)?.ReviveHealth();

            CurrentVillain.Sprite.Parent?.Controls.Remove(CurrentVillain.Sprite);

            int spawnX = CurrentHero.Sprite.Parent.Width - 120;
            int spawnY = CurrentHero.Sprite.Parent.Height / 2;
            CurrentVillain = villainSpawner.SpawnNext(spawnX, spawnY, level);
            CurrentHero.Sprite.Parent.Controls.Add(CurrentVillain.Sprite);
            CurrentVillain.Sprite.BringToFront();
            CurrentHero.Sprite.BringToFront();
            UpdateHUD();
        }

        private void SetupHero()
        {
            CurrentHero = GetHeroByName(CurrentHeroName) ?? IronMan;
            form.Controls.Add(CurrentHero.Sprite);
            CurrentHero.Sprite.BringToFront();
        }

        private void SpawnVillain()
        {
            int spawnX = form.Width - 120;
            int spawnY = form.Height / 2;
            CurrentVillain = villainSpawner.SpawnNext(spawnX, spawnY, level);
            form.Controls.Add(CurrentVillain.Sprite);
            CurrentVillain.Sprite.BringToFront();
        }

        public static void ChangePlayer(Characters hero) { CurrentHeroName = hero; }

        private Hero GetHeroByName(Characters name)
        {
            switch (name)
            {
                case Characters.CaptionAmerica: return CaptionAmerica;
                case Characters.Thor: return Thor;
                case Characters.Hulk: return Hulk;
                case Characters.SpiderMan: return SpiderMan;
                default: return IronMan;
            }
        }

        private static int VillainFireInterval()
        {
            return Math.Max(VillainMinFireInterval,
                            VillainBaseFireInterval - (level - 1) * 4);
        }

        public static void Update()
        {
            if (CurrentHero == null || CurrentVillain == null) return;

            int formWidth = CurrentHero.Sprite.Parent?.Width ?? 1264;
            int formHeight = CurrentHero.Sprite.Parent?.Height ?? 681;

            CurrentHero.Move();
            CurrentHero.checkBoundary(formWidth, formHeight);
            CurrentVillain.Move();
            CurrentVillain.checkBoundary(formWidth, formHeight);

            heroFiringCounter++;
            if (InputManagers.attack() && heroFiringCounter >= HeroMaxFireInterval)
            {
                heroFiringCounter = 0;
                SpawnHeroShot();
            }

            villainFiringCounter++;
            if (villainFiringCounter >= VillainFireInterval())
            {
                villainFiringCounter = 0;
                SpawnVillainShot();
            }

            MoveAttacks(formWidth, formHeight);

            CollisionsManager.CheckAttackingObjectCharacterCollision(
                new List<Character> { CurrentVillain }, heroAttacks);
            CollisionsManager.CheckAttackingObjectCharacterCollision(
                new List<Character> { CurrentHero }, villainAttacks);
            CollisionsManager.CheckAttackingObjectsCollision(heroAttacks, villainAttacks);

            CheckHealthPickupCollection();

            healthSpawnCounter++;
            if (healthSpawnCounter >= HealthSpawnInterval)
            {
                healthSpawnCounter = 0;
                SpawnHealthPickup(formWidth, formHeight);
            }

            if (CurrentVillain.isDead())
            {
                (CurrentHero as IScoreable)?.AddScore(100 * level);
            }

            RemoveDeadAttacks(heroAttacks);
            RemoveDeadAttacks(villainAttacks);
            RemoveCollectedHealthPickups();

            UpdateHUD();
        }

        private static void SpawnHeroShot()
        {
            AttackingObject shot = (CurrentHero as IAttackable)?.Attack();
            if (shot == null) return;
            heroAttacks.Add(shot);
            CurrentHero.Sprite.Parent?.Controls.Add(shot.Sprite);
            shot.Sprite.BringToFront();
        }

        private static void SpawnVillainShot()
        {
            AttackingObject shot = (CurrentVillain as IAttackable)?.Attack();
            if (shot == null) return;
            villainAttacks.Add(shot);
            CurrentVillain.Sprite.Parent?.Controls.Add(shot.Sprite);
            shot.Sprite.BringToFront();
        }

        private static void SpawnHealthPickup(int formWidth, int formHeight)
        {
            HealthObject hp = healthSpawner.SpawnRandom(formWidth, formHeight);
            hp.Sprite.BackColor = Color.Transparent;
            healthPickups.Add(hp);
            CurrentHero.Sprite.Parent?.Controls.Add(hp.Sprite);
            hp.Sprite.BringToFront();
        }

        private static void CheckHealthPickupCollection()
        {
            foreach (HealthObject hp in healthPickups)
            {
                if (!hp.isDead() && hp.Bounds.IntersectsWith(CurrentHero.Bounds))
                {
                    (CurrentHero as IHealable)?.GetHealth(hp.GetHealthValue());
                    (CurrentHero as IScoreable)?.AddScore(50);
                    hp.Destroy();
                }
            }
        }

        private static void MoveAttacks(int formWidth, int formHeight)
        {
            foreach (AttackingObject a in heroAttacks)
                if (!a.isDead()) { a.Move(); a.checkBoundary(formWidth, formHeight); }

            foreach (AttackingObject a in villainAttacks)
                if (!a.isDead()) { a.Move(); a.checkBoundary(formWidth, formHeight); }
        }

        private static void RemoveDeadAttacks(List<AttackingObject> attacks)
        {
            for (int i = attacks.Count - 1; i >= 0; i--)
            {
                if (attacks[i].isDead())
                {
                    attacks[i].Sprite.Parent?.Controls.Remove(attacks[i].Sprite);
                    attacks.RemoveAt(i);
                }
            }
        }

        private static void RemoveCollectedHealthPickups()
        {
            for (int i = healthPickups.Count - 1; i >= 0; i--)
            {
                if (healthPickups[i].isDead())
                {
                    healthPickups[i].Sprite.Parent?.Controls.Remove(healthPickups[i].Sprite);
                    healthPickups.RemoveAt(i);
                }
            }
        }

        private static void ClearAllAttacks()
        {
            for (int i = heroAttacks.Count - 1; i >= 0; i--)
                heroAttacks[i].Sprite.Parent?.Controls.Remove(heroAttacks[i].Sprite);
            for (int i = villainAttacks.Count - 1; i >= 0; i--)
                villainAttacks[i].Sprite.Parent?.Controls.Remove(villainAttacks[i].Sprite);
            heroAttacks.Clear();
            villainAttacks.Clear();
        }

        private static void UpdateHUD()
        {
            if (pbHeroHealth != null)
            {
                pbHeroHealth.Maximum = CurrentHero.MaxHealth;
                pbHeroHealth.Value = Math.Max(0, Math.Min(CurrentHero.Health, CurrentHero.MaxHealth));
            }
            if (pbVillainHealth != null)
            {
                pbVillainHealth.Maximum = CurrentVillain.MaxHealth > 0 ? CurrentVillain.MaxHealth : 1;
                pbVillainHealth.Value = Math.Max(0, Math.Min(CurrentVillain.Health, pbVillainHealth.Maximum));
            }
            if (lblScore != null) lblScore.Text = "Score: " + (CurrentHero as IScoreable)?.Score;
            if (lblLevel != null) lblLevel.Text = "Level: " + level;
        }
    }
}
