using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeadState : State
{
    public override StateType Type => StateType.Dead; 


    public DeadState() : base("Dead") { } //metodo constructor


    //metodos 
    protected  override void OnEnterState(FiniteStateMachine fms) //en el estado
    {
        fms.Object.SetActive(false); //apagar
    }

    protected  override void OnUpdateState(FiniteStateMachine fms, float deltaTime) //cuando se actualiza
    {
        
    }

    protected  override void OnExitState(FiniteStateMachine fms) //salgo estado
    {
        
    }
}
