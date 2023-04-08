using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InDetectionZone Check", menuName = "Assets/Packables/FSMDecision/InDetectionZone Check")]
public class InDetectionZoneCheck : StateDecision
{
    public override bool Check(FiniteStateMachine fms)
    {
        Vector3 direction = fms.Target.position - fms.transform.position;
        float distance = direction.magnitude;
        if (distance <= fms.Config.DetectionRange)
        {
            float angleToPlayer = Vector3.Angle(direction, fms.transform.forward);
            if (angleToPlayer < fms.Config.ViewAngle / 2f)
                return true;
        }

        return false;
    }
}
