using UnityEngine;

[CreateAssetMenu(fileName = "InDetectionZone Check", menuName = "FSM/Decisions/InDetectionZone Check")]
public class InDetectionZoneCheck: StateDecision
{
    private Vector3 direction;
    public override bool Check(global::FiniteStateMachine fms)
    {
        direction = fms.Target.position - fms.transform.position;
        if (direction.magnitude <= fms.Config.DetectionRange)
        {
            return true;
        }

        return false;
    }
}
