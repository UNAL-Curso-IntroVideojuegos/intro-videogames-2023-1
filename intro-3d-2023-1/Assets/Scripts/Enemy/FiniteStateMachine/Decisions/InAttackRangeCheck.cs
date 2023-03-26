using UnityEngine;

public class InAttackRangeCheck : StateDecision
{
    public override bool Check(FiniteStateMachine fms)
    {
        float distance = (fms.Target.position - fms.transform.position).magnitude;
        return distance <= fms.Config.AttackRange;
    }
}
