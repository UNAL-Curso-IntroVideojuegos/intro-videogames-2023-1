using UnityEngine;

[CreateAssetMenu(fileName = "InDetectionRange Check", menuName = "FSM/Decisions/InDetectionRange Check")]
public class InDetectionZoneCheck : StateDecision
{
    public override bool Check(FiniteStateMachine fms)
    {
        float distance = (fms.Target.position - fms.transform.position).magnitude;
        return distance <= fms.Config.DetectionRange;
    }
}
