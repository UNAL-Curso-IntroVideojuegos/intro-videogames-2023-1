using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    private float _speed = 0.3f;

    [SerializeField] private Transform initPos;
    [SerializeField] private Transform endPos;
    [SerializeField] private Transform _user;
    [SerializeField] private Transform _cannon1;
    [SerializeField] private Transform _cannon2;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _shootPoint1;
    [SerializeField] private Transform _shootPoint2;
    public float timeRemaining = 3;
    public bool shoot = false;

    // Start is called before the first frame update
    private float distance;
    void Start()
    {
        this.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Vector3.Lerp(initPos.position, endPos.position, Mathf.PingPong(Time.time* _speed, 1.0f));
        transform.position = position;
        LookAtUser();
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Time has run out!");
            timeRemaining = 3;
            shoot = true;
        }
        
        if (shoot)
        {
            GameObject projectile1 = Instantiate(_projectile);
            projectile1.transform.position = _shootPoint1.position;
            projectile1.transform.rotation = _shootPoint1.rotation;
            GameObject projectile2 = Instantiate(_projectile);
            projectile2.transform.position = _shootPoint2.position;
            projectile2.transform.rotation = _shootPoint2.rotation;
            shoot = false;
        }
        
    }

    void LookAtUser()
    {
        Transform[] cannons = { _cannon1, _cannon2 };
        Vector3 direction = (_user.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg+90;
        foreach (var cannon in cannons)
        {
            cannon.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
