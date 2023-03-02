using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankTurret : MonoBehaviour
{
    [SerializeField] private Transform _turret1;
    [SerializeField] private Transform _turret2;
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform[] torretas = { _turret1, _turret2 };
        foreach (Transform torreta in torretas) {
            Vector3 vectorDirector = (torreta.position - player.position).normalized;
            float angulo = Mathf.Atan2(vectorDirector.y, vectorDirector.x) * Mathf.Rad2Deg - 90;
            Vector3 rot = transform.eulerAngles;
            rot.z = angulo;
            torreta.eulerAngles = rot;
        }
    }
}
