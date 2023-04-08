using System.Collections;
using System.Collections.Generic;
using Enemy.FiniteStateMachine.States;
using UnityEngine;

public enum StateType { None,Idle, Patrol, Chase, Attack, Taunt }

public abstract class State
{
    [HideInInspector] public string name = "Patrol";
    private List<StateTransition> _transitions = new List<StateTransition>();

    private float _stateDuration;
    private float _stateTimer;

    public State(string name) => this.name = name;
    
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
        
        for (int i = 0; i < _transitions.Count; i++)
        {
            if (_transitions[i].Check(fms))
            {
                fms.ToState(_transitions[i].TargetState);
                break;
            }
        }
    }

    protected void SetStateDuration(float time)
    {
        _stateDuration = time;
    }
    
    public void AddTransition(StateType targetState, StateDecision decision)
    {
        _transitions.Add(new StateTransition
        {
            TargetState = targetState,
            Decision = decision
        });
    }
    
    public static State CreateState(StateType stateType)
    {
        switch (stateType)
        {
            case StateType.Idle:
                return new IdleState();
            case StateType.Patrol:
                return new PatrolState();
            case StateType.Chase:
                return new ChaseState();
            case StateType.Attack:
                return new AttackState();
        }

        return null;
    }
}
