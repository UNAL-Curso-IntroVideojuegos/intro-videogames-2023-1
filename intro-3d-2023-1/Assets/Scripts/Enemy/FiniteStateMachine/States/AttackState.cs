using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public override StateType Type => StateType.Attack;
    
    private float _attackTimer = 0;

    public AttackState() : base("Attack") { }

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

        for (int i = 0; i < collidersInRange.Length; i++)
        {
            if (collidersInRange[i].TryGetComponent(out IDamageable target))
            {
                target.TakeHit(fms.Config.AttackDamage);
            }
        }
    }
    protected override void OnEnterState(FiniteStateMachine fsm)
    {
        fsm.TriggerAnimation("Attack");
        _attackTimer = fsm.Config.AttackDuration;
    }

    protected override void OnUpdateState(FiniteStateMachine fsm, float deltaTime)
    {
        if (fsm.Target.TryGetComponent(out IDamageable target))
        {
            target.TakeHit(fsm.Config.AttackDamage);
        }

        _attackTimer -= deltaTime;
        if (_attackTimer <= 0)
        {
            fsm.ToState(StateType.Idle);
        }
    }

    protected override void OnExitState(FiniteStateMachine fsm)
    {
    }
}

