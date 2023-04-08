using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TauntState : State
{
    public override StateType Type => StateType.Taunt; 


    public TauntState() : base("Taunt") { } //metodo constructor


    //metodos 
    protected  override void OnEnterState(FiniteStateMachine fms) //en el estado
    {
       fms.TriggerAnimation("Taunt"); //disparar trigger taunt
       SetStateDuration(fms.Config.TauntDuration); //cuanto dura el estado
    }

    protected  override void OnUpdateState(FiniteStateMachine fms, float deltaTime) //cuando se actualiza
    {
        
    }

    protected  override void OnExitState(FiniteStateMachine fms) //salgo estado
    {
        
    }
}

