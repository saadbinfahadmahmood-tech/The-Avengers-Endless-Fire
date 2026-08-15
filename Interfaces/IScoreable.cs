namespace Game.Interfaces
{
    public interface IScoreable
    {
        int Score { get; set; }
        void AddScore(int points);
    }
}
