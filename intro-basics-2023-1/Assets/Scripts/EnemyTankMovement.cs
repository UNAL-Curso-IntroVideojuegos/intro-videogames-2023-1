using UnityEngine;

public class EnemyTankMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _point1;
    
    [SerializeField]
    private GameObject _point2;
    
    [SerializeField]
    private float speed = 1.0f;
    
    private Transform startPoint;
    private Transform endPoint;
    private float distance;

    void Start()
    {
        startPoint = _point1.transform;
        endPoint = _point2.transform;
        distance = Vector3.Distance(startPoint.position, endPoint.position);
        gameObject.SetActive(false);
    }

    void Update()
    {
        float currentPos = Mathf.PingPong(Time.time * speed, distance);
        
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, currentPos / distance);
    }
}
