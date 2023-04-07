using System;
using UnityEngine;

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
                if (fms.Config.EnemyAttackType == EnemyAttackType.Basic)
                {
                    BasicAttack(fms);
                }
                else
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
        Debug.Log("Basic");
        if (fms.Target.TryGetComponent(out IDamageable target))
        {
            Debug.Log(fms.Target.name);
            target.TakeHit(fms.Config.AttackDamage);
        }
    }

    private void ExplodeAttack(FiniteStateMachine fms)
    {
        Debug.Log("Explode");
        Collider[] collidersInRange = Physics.OverlapSphere(
            fms.transform.position + Vector3.up * 0.5f,
            fms.Config.AttackRange
        );

        foreach (Collider collider in collidersInRange)
        {
            if (collider.TryGetComponent(out IDamageable target))
            {
                Debug.Log(collider.name);
                target.TakeHit(fms.Config.AttackDamage);
            }
        }
    }
}