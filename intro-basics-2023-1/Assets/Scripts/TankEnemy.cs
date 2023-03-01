using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTank;

    [Space(20)]
    [SerializeField]
    private Transform _initialPos;
    [SerializeField]
    private Transform _endPos;

    [Space(20)]
    [SerializeField]
    private List<Transform> _canons = new List<Transform>();

    [Space(20)]
    [SerializeField]
    private GameObject _projectilePrefab;
    [SerializeField]
    private List<Transform> _shootpoints = new List<Transform>();

    [Space(20)]
    [SerializeField]
    private int shootTime = 1;

    private float dist;
    private float speed;
    private float time;
    private float movementTime = 0;


    private void Start()
    {
        changeActive();
    }

    // Update is called once per frame
    void Update()
    {
        dist = _endPos.position.y - _initialPos.position.y;
        movementTime += Time.deltaTime;
        speed = Mathf.PingPong(movementTime, dist) / dist;
        transform.position = Vector3.Lerp(_initialPos.position, _endPos.position, speed);

        // Canons Look
        foreach (Transform t in _canons)
        {
            Vector3 aimVector = (_playerTank.position - t.position).normalized;
            float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
            t.rotation = Quaternion.Euler(0, 0, angle);
        }

        time += Time.deltaTime;
        if (time > shootTime)
        {
            //Shoot
            foreach (Transform t in _shootpoints)
            {
                GameObject projectile = Instantiate(_projectilePrefab);
                projectile.transform.position = t.position;
                projectile.transform.rotation = t.rotation;
            }

            time = 0;
        }
    }

    public void changeActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
