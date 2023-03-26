public class StateTransition
{
    public StateType TargetState;
    public StateDecision Decision;

    public bool Check(FiniteStateMachine fms)
    {
        if(Decision != null)
            return Decision.Check(fms);

        return true;
    }
}