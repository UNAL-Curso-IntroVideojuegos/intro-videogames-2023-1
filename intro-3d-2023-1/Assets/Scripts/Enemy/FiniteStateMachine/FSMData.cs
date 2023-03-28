using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FSMData
{
    public List<FSMStateData> States;
}

[Serializable]
public class FSMStateData
{
    public StateType StateType;
    public FSMTransitionData[] Transition;
}

[Serializable]
public class FSMTransitionData
{
    public StateType TargetState;
    [Header("Null means it rely in the State Timer")]
    public StateDecision Decision;
}
