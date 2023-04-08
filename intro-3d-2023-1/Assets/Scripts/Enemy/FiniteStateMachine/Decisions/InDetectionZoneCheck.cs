using UnityEngine;
    
[CreateAssetMenu(fileName = "InDetectionZone Check", menuName = "FSM/Decisions/InDetectionZone Check")]
public class InDetectionZoneCheck : StateDecision
{
    public override bool Check(FiniteStateMachine fms)
    {
        Vector3 direction = fms.Target.position - fms.transform.position;
        float distance = direction.magnitude;
        if (distance <= fms.Config.DetectionRange)
        {
            return true;
        }

        return false;
    }
}