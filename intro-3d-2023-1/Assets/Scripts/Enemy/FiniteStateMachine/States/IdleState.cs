using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IdleState : State
{
    public override StateType Type => StateType.Idle; 


    public IdleState() : base("Idle") { } //metodo constructor


    //metodos 
    protected  override void OnEnterState(FiniteStateMachine fms) //en el estado
    {
        
    }

    protected  override void OnUpdateState(FiniteStateMachine fms, float deltaTime) //cuando se actualiza
    {
        
    }

    protected  override void OnExitState(FiniteStateMachine fms) //salgo estado
    {
        
    }
}
