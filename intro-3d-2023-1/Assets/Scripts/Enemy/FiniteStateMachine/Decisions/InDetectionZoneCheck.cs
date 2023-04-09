using UnityEngine;

[CreateAssetMenu(fileName = "InDetectionZone Check", menuName = "FSM/Decisions/InDetectionZone Check")]
public class InDetectionZoneCheck : StateDecision
{
    public override bool Check(FiniteStateMachine fsm)
    {
        // Obtener la distancia entre el jugador y el enemigo
        float distance = Vector3.Distance(fsm.transform.position, fsm.Target.position);

        // Verificar si la distancia es menor o igual al rango de detección
        return distance <= fsm.Config.DetectionRange;
    }
}

