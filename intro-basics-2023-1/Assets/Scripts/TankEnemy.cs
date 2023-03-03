using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pos1, pos2;
    private Vector3 startPosition;
    private Vector3 endPosition;
    public float speed=0.1f;
    [SerializeField]
    private Transform[] _cannons;
    private Camera _cam;
    public Transform lookPlayer;
    [SerializeField]
    private GameObject _enemyTank;
    void Start()
    {
        _cam = Camera.main;
        startPosition = pos1.position;
        endPosition = pos2.position;
        _enemyTank.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(Time.time * speed, 1.0f));
        Vector3 aimVector = (lookPlayer.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
        foreach (Transform cannon in _cannons)
        {
            cannon.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
