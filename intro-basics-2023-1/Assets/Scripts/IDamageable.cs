public interface IDamageable
{
    public int TotalHealthPoints { get; }
    public int HealthPoints { get; }

    public void TakeHit();
}
