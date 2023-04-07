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
        fms.TriggerAnimation("Attack");
        _attackDelay = fms.Config.AttackDelay;
        SetStateDuration(fms.Config.AttackDuration);
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        if (fms.Config.attackType == EnemyAttackType.Basic)
        {
            BasicAttack(fms, deltaTime);
        } else {
            ExplodeAttack(fms, deltaTime);
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
        Collider[] hitColliders = Physics.OverlapSphere(fms.transform.position + (Vector3.up * 0.9f), fms.Config.AttackRange);


        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out IDamageable objective))
            {
                objective.TakeHit(fms.Config.AttackDamage);
            }
        }
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}
