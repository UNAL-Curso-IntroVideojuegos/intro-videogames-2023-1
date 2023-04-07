using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyAttackType
{
    Basic,
    Explode
}

public class AttackState : State
{
    
    public override StateType Type { get; }
    
    private float _attackDelay = 0;

    public AttackState() : base("Attack")
    {
    }

    protected override void OnEnterState(FiniteStateMachine fms)
    {
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
                if (fms.Config.AttackType == EnemyAttackType.Basic)
                {
                    BasicAttack(fms);
                }
                else if (fms.Config.AttackType == EnemyAttackType.Explode)
                {
                    ExplodeAttack(fms);
                }
            }
        }
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }

    private void BasicAttack(FiniteStateMachine fms)
    {
        //Apply Damage
        if (fms.Target.TryGetComponent(out IDamageable target))
        {
            target.TakeHit(fms.Config.AttackDamage);
        }
    }

    private void ExplodeAttack(FiniteStateMachine fms)
    {
        Collider[] colliders = Physics.OverlapSphere(fms.transform.position, fms.Config.AttackRange);
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IDamageable target))
            {
                target.TakeHit(fms.Config.AttackDamage);
            }
        }
    }
}
