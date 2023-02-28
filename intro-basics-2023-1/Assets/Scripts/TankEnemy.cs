using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    public Transform startPoint; 
    public Transform endPoint;
    public Transform visual;

    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 1.0f;

    [Space(20)]
    [SerializeField]
    public Transform[] cannon;

    public GameObject gameObjectToDeactivate;

    private Camera _cam;


    void Start()
    {
        pos1=startPoint.position; pos2=endPoint.position;
        gameObjectToDeactivate.SetActive(false);
        _cam = Camera.main;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        Vector3 aimVector = (visual.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;

        foreach (Transform i in cannon)
        {
            i.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
