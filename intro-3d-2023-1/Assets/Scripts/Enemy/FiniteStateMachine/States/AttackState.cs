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
                if (fms.Config.InitialAtackType == EnemyAttackType.Basic)
                    BasicAttack(fms, deltaTime);
                else if (fms.Config.InitialAtackType == EnemyAttackType.Explode)
                    ExplodeAttack(fms, deltaTime);
            }
        }
    }

    private void BasicAttack(FiniteStateMachine fms, float deltaTime)
    {
        Debug.Log("Ataque basico");
        if (fms.Target.TryGetComponent(out IDamageable target))
        {
            target.TakeHit(fms.Config.AttackDamage);
        }
    }

    private void ExplodeAttack(FiniteStateMachine fms, float deltaTime)
    {
        Debug.Log("Ataque explode");
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

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
}
