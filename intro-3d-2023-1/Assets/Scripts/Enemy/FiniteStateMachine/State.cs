using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType { None, Patrol, Chase, Attack, Taunt }

public abstract class State
{
    [HideInInspector] public string name = "Patrol";

    private float _stateDuration;
    private float _stateTimer;

    public abstract StateType Type { get; }
    protected abstract void OnEnterState(FiniteStateMachine fms);
    protected abstract void OnUpdateState(FiniteStateMachine fms, float deltaTime);
    protected abstract void OnExitState(FiniteStateMachine fms);
    
    public void OnEnter(FiniteStateMachine fms)
    {
        OnEnterState(fms);
        _stateTimer = _stateDuration;
    }
    
    public void OnUpdate(FiniteStateMachine fms, float deltaTime)
    {
        OnUpdateState(fms, deltaTime);
    }
    
    public void OnExit(FiniteStateMachine fms)
    {
        OnExitState(fms);
    }

    public void CheckTransition(FiniteStateMachine fms, float deltaTime)
    {
        _stateTimer -= deltaTime;
        
        if(_stateTimer > 0)
            return;

        _stateTimer = 0;
        
        //TODO: Add transitions
    }

    protected void SetStateDuration(float time)
    {
        _stateDuration = time;
    }
}
