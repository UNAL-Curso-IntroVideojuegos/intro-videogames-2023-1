using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    [field:SerializeField]
    public Animator EnemyChest { get; protected set;  }
    
    [field:SerializeField]
    public int TotalHealthPoints { get; protected set; }
    public int HealthPoints { get; private set; }
    
    public void TakeHit(int damage = 1)
    {
        if(HealthPoints <= 0)
            return;
    
        HealthPoints-=damage;
        OnTakeDamage();

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
