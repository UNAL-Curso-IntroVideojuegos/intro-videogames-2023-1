using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class EnemyConfig : MonoBehaviour
{
    public int Health = 2;

    [Header("Movement")] 
    public float Speed = 1.0f;
    public float ChaseSpeed = 2.7f;

    [Header("Detection Range")]
    public float DetectionRange = 5.0f;
    public float ViewAngle = 95.0f;
    public float TauntDuration = 2.0f;
    
    [Header("Attack")]
    public float AttackRange = 1.5f;
    public float AttackDelay = 0.18f;
    public float AttackDuration = 1.5f;
    public int AttackDamage = 1;

    [Header("Finite-State Machine")] 
    public FSMData FSMData;

        private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        
#if UNITY_EDITOR
        Vector3 fromDirection = Quaternion.Euler(0, -ViewAngle / 2f, 0) * transform.forward;
        Handles.color = new Color(1, 0.92f, 0.016f, 0.3f);
        Handles.DrawSolidArc(transform.position + Vector3.up * 0.9f, Vector3.up, fromDirection, ViewAngle, DetectionRange);
#endif
    }
}