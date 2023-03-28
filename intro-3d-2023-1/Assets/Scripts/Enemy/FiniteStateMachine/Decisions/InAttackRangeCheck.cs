using UnityEngine;

[CreateAssetMenu(fileName = "InRangeAttack Check", menuName = "FSM/Decisions/InRangeAttack Check")]
public class InAttackRangeCheck : StateDecision
{
    public override bool Check(FiniteStateMachine fms)
    {
        float distance = (fms.Target.position - fms.transform.position).magnitude;
        return distance <= fms.Config.AttackRange;
    }
}
