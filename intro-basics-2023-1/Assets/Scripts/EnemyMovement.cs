using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform initPos;
    public Transform endPos;
    private Vector3 pos1;
    private Vector3 pos2;
    public float speed=0.1f;
    [Space(20)]
    [SerializeField]
    public Transform _cannon1;
    public Transform _cannon2;
    public Transform mirar;
    private Camera _cam;
    public GameObject gameObjectToDeactivate;
    void Start()
    {
       pos1=initPos.position; 
       pos2=endPos.position;
       _cam=Camera.main;
       gameObjectToDeactivate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pos1,pos2,Mathf.PingPong(Time.time*speed,1.0f));

        Vector3 aimVector = (mirar.position - transform.position).normalized;
        float lookAngle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
        _cannon1.rotation = Quaternion.Euler(0,0,lookAngle);
        _cannon2.rotation = Quaternion.Euler(0,0,lookAngle);
        
        
        
    }
}
