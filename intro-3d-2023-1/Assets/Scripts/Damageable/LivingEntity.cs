using System;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int TotalHealthPoints { get; protected set; } = 1;
    public int HealthPoints { get; private set; }

    public Action<int, int> OnHealthChange;

    public void TakeHit(int damage = 1)
    {
        if(HealthPoints <= 0)
            return;
    
        HealthPoints -= damage;
        OnTakeDamage();

        OnHealthChange?.Invoke(HealthPoints, TotalHealthPoints);
        
        if (HealthPoints <= 0)
        {
            OnDeath();
        }
    }

    protected void InitHealth()
    {
        HealthPoints = TotalHealthPoints;
    }
    
    protected virtual void OnTakeDamage(){ }
    protected virtual void OnDeath(){ }
}
