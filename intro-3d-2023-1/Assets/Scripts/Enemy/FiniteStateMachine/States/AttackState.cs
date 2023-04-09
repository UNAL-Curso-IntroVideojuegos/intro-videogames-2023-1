using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    
    public override StateType Type { get; }

    private EnemyAttackType _attackType;
    private float _attackDelay = 0;
    public AttackState() : base("Attack") { }

    protected override void OnEnterState(FiniteStateMachine fms)
    {
        fms.TriggerAnimation("Attack");
        _attackType = fms.Config.AttackType;
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
                if (_attackType == EnemyAttackType.Basic) BasicAttack(fms, deltaTime);
                else ExplodeAttack(fms, deltaTime);
            }
        }
    }

    private void BasicAttack(FiniteStateMachine fms, float deltaTime)
    {
        if (fms.Target.TryGetComponent(out IDamageable target))
        {
            target.TakeHit(fms.Config.AttackDamage);
        }
    }

    private void ExplodeAttack(FiniteStateMachine fms, float deltaTime)
    {
        Collider[] collidersInRange = Physics.OverlapSphere(
            fms.transform.position + Vector3.up * 0.5f,
            fms.Config.AttackRange);
        
        foreach (var collider in collidersInRange)
        {
            if (collider.TryGetComponent(out IDamageable target))
            {
                target.TakeHit(fms.Config.AttackDamage);
            }
        }
    }
    
    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}