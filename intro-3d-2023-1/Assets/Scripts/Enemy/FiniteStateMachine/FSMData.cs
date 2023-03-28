using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class FSMData
{
    public List<FSMStateData> States;

    public static State GetState(StateType stateType)
    {
        switch (stateType)
        {
            case StateType.Patrol:
                return new PatrolState();
            case StateType.Chase:
                return new ChaseState();
            case StateType.Attack:
                return new AttackState();
            case StateType.Taunt:
                return new TauntState();
            case StateType.Dead:
                return new DeadState();
            case StateType.Idle:
                return new IdleState();
        }

        return null;
    }
}

[Serializable]
public class FSMStateData
{
    [FormerlySerializedAs("State")] public StateType StateType;
    public FSMTransitionData[] Transition;
}

[Serializable]
public class FSMTransitionData
{
    public StateType TargetState;
    [Header("Null means it rely in the State Timer")]
    public StateDecision Decision;
}
