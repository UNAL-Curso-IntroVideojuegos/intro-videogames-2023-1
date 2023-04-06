using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    public override StateType Type => StateType.Dead;
    public float deathDelay = 0;

    public DeadState() : base("Death") { }
    
    protected override void OnEnterState(FiniteStateMachine fms)
    {
        fms.TriggerAnimation("Death");
        deathDelay = fms.Config.DeathDelay;
        SetStateDuration(fms.Config.DeathDelay + 0.15f);
    }

    protected override void OnUpdateState(FiniteStateMachine fms, float deltaTime)
    {
       if (deathDelay > 0)
        {
            deathDelay -= deltaTime;
            if (deathDelay <= 0)
            { 
                fms.Config.dead();
            }
        }
    }

    protected override void OnExitState(FiniteStateMachine fms)
    {

    } 
}
