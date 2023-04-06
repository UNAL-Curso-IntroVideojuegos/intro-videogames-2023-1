using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackState : State
{

    public override StateType Type => StateType.Attack;

    private float _attackDelay = 0;
    private EnemyAttackType _attackType;
    public AttackState() : base("Attack") { }


    protected override void OnEnterState(FiniteStateMachine fms)
    {
        fms.TriggerAnimation("Attack");
        _attackDelay = fms.Config.AttackDelay;
        _attackType = fms.Config.type;
        SetStateDuration(fms.Config.AttackDuration);
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
        if (_attackType == EnemyAttackType.Basic)
        {
           BasicAttack(fms, deltaTime);
        }
        else
        {
            ExplodeAttack(fms,deltaTime);
        }
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
        fms.NavMeshController.StopAgent();
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
        Collider[] collidersInRange = Physics.OverlapSphere(fms.transform.position + Vector3.up * 0.5f, fms.Config.AttackRange);
        for (int i = 0; i < collidersInRange.Length; i++)
        {
            if (collidersInRange[i].TryGetComponent(out IDamageable target))
            {
                target.TakeHit(fms.Config.AttackDamage);
            }
        }
    }
}
