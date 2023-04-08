using UnityEngine;

[CreateAssetMenu(fileName = "InDetectionZone Check", menuName = "FSM/Decisions/InDetectionZone Check")]
public class InDetectionZoneCheck : StateDecision
{
    public override bool Check(FiniteStateMachine fms)
    {
        float distance = (fms.Target.position - fms.transform.position).magnitude;
        return distance <= fms.Config.DetectionRange;
    }
}
 