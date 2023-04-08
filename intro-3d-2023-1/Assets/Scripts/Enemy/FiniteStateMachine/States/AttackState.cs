using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    
    public override StateType Type => StateType.Attack;

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
                //Apply Damage
                if (fms.Config.AttackType == EnemyConfig.EnemyAttackType.Basic)
                {
                    BasicAttack(fms, deltaTime);    
                }
                else if (fms.Config.AttackType == EnemyConfig.EnemyAttackType.Explode)
                {
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
        Debug.Log("BASIC");

        if (fms.Target.TryGetComponent(out IDamageable target))
        {
            target.TakeHit(fms.Config.AttackDamage);
        }
    }
    
    private void ExplodeAttack(FiniteStateMachine fms, float deltaTime)
    {
        Debug.Log("EXPLODE");
        Collider[] colliders = Physics.OverlapSphere(fms.transform.position, fms.Config.AttackRange);
        
        foreach (Collider collider in colliders)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeHit(fms.Config.AttackDamage);
            }
        }
    }
}
