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
                //Apply Damage
                if (fms.Config.AttackType == EnemyAttackType.Basic) 
                {
                    BasicAttack(fms, deltaTime); //llamar funcion
                }
                else {
                    ExplodeAttack(fms, deltaTime); //funcion
                }
                
            }
        }
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {
    }
    
    //ataque basico, por defecto
    private void BasicAttack(FiniteStateMachine fms, float deltaTime)
    {
    Debug.Log("B");
        if (fms.Target.TryGetComponent(out IDamageable target))
        {
            target.TakeHit(fms.Config.AttackDamage);
        }
    }

    //explosiva
    private void ExplodeAttack(FiniteStateMachine fms, float deltaTime)
    {
    Debug.Log("E"); //print consola
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
}
