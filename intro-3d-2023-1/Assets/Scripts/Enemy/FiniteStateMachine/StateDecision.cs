using UnityEngine;

public abstract class StateDecision : ScriptableObject
{
    public abstract bool Check(FiniteStateMachine fms);
}