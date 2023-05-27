using UnityEngine;

public class Player : LivingEntity
{
    private Animator _anim;
    
    void Start()
    {
        InitHealth();
    }

    protected override void OnTakeDamage()
    {
        base.OnTakeDamage();
        GameEvents.OnPlayerHealthChangeEvent?.Invoke(HealthPoints);
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        
        if(TryGetComponent<PlayerController>(out var controller))
            controller.ToDeathState();
        if (TryGetComponent<PlayerInput>(out var input))
            input.enabled = false;
        

        GameManager.Instance.GameOver();
    }
}
