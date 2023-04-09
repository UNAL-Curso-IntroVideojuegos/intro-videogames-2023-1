using UnityEngine;

[CreateAssetMenu(fileName = "InDetectionZone Check", menuName = "FSM/Decisions/InDetectionZone Check")]

public class InDetectionZoneCheck : StateDecision
{
    public override bool Check(FiniteStateMachine fms)
    {
        Vector3  direction = (fms.Target.position - fms.transform.position);
        float  distance = direction.magnitude;
        float angleToPlayer = Vector3.Angle(direction, fms.transform.forward);
        return (distance <=  fms.Config.DetectionRange && angleToPlayer < fms.Config.ViewAngle / 2f);
    }

    
}