using System;
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
                if (fms.Config.AttackType == EnemyAttackType.Basic)
                {
                     BasicAttack(fms);
                } else
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
             Console.WriteLine("Basico");
             target.TakeHit(fms.Config.AttackDamage);
        }
     }

     private void ExplodeAttack(FiniteStateMachine fms)
     {
          //Apply Area damage
          // El centro es la posición del enemigo, el radio su AttackRange

          Collider[] hitColliders = Physics.OverlapSphere(fms.transform.position, fms.Config.AttackRange);
          foreach (var hitCollider in hitColliders)
          {
               Console.WriteLine(hitCollider.name);
               if (hitCollider.TryGetComponent(out IDamageable target))
               {
                    target.TakeHit(fms.Config.AttackDamage);
               }
          }
    }
}
