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
        if (_attackDelay > 0)
        {
            _attackDelay -= deltaTime;
            if (_attackDelay <= 0)
            {
               if (fms.Config.type == EnemyAttackType.Basic){
                    BasicAttack(fms, deltaTime);
               }else{
                    ExplodeAttack(fms, deltaTime);
               }
            }
        }
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }

    private void BasicAttack(FiniteStateMachine fms, float deltaTime)
    {
        _attackDelay -= deltaTime;
        if (_attackDelay <= 0)
        {
           if (fms.Target.TryGetComponent(out IDamageable target))
           {
             target.TakeHit(fms.Config.AttackDamage);
           }
        }
    }

    private void ExplodeAttack(FiniteStateMachine fms, float deltaTime)
    {
        Collider[] colliders = Physics.OverlapSphere(fms.transform.position + Vector3.up * 0.35f, fms.Config.AttackRange);
        for (int i = 0; i < colliders.Length; i ++)
        {
            if (colliders[i].TryGetComponent(out IDamageable target))
            {
                target.TakeHit(fms.Config.AttackDamage);
            }
        }
    }

}