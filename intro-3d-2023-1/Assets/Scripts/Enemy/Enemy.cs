﻿
using UnityEngine;

public class Enemy : LivingEntity
{
    private FiniteStateMachine _fms;
    private EnemyConfig _config;
    
    void Start()
    {
        InitHealth();

        _config = GetComponent<EnemyConfig>();
        _fms = GetComponent<FiniteStateMachine>();
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        _fms.ToState(StateType.Dead);
        
        GameEvents.OnEnemyDeathEvent?.Invoke(this, _config.Points);

        if (_config.DeathVFX)
        {
            GameObject vfx = Instantiate(_config.DeathVFX, transform.position, Quaternion.identity);
            Destroy(vfx, 5);
        }

        // EventManager.Instance.Dispatch(new EnemyDeathEvent
        // {
        //     EnemyDeath = this,
        //     Points = _config.Points
        // });
    }
}
