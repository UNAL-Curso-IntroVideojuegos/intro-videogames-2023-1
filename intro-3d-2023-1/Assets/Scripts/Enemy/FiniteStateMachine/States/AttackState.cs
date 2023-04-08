using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{

    public override StateType Type { get; }

    private float _attackDelay = 0;
    public AttackState() : base("Attack") { }

    protected override void OnEnterState(FiniteStateMachine fms)
    {
        Debug.Log("Atacar");
        fms.TriggerAnimation("Attack");
        _attackDelay = fms.Config.AttackDelay;
        SetStateDuration(fms.Config.AttackDuration);
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        if (_attackDelay > 0)
        {
            _attackDelay -= deltaTime;
            if (_attackDelay <= 0)
            {
                //Apply Damage
                if (fms.Target.TryGetComponent(out IDamageable target))
                {
                    target.TakeHit(fms.Config.AttackDamage);
                }
            }
        }
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}
