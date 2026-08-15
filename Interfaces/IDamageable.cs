namespace Game.Interfaces
{
    public interface IDamageable
    {
        void GetDamage(int damage);
        int Health { get; }
        int MaxHealth { get; }
    }
}
