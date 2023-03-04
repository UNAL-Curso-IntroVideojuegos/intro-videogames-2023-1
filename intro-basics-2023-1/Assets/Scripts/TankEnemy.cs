using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 2f;
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform endPoint;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform[] _cannons;
    [SerializeField]
    private GameObject projectil;
    [SerializeField]
    private float fireDelay = 3f;

    private bool timerIsRunnig = false;
    private bool _isStatic;

    // Singleton Pattenr
    public static TankEnemy sharedInstace;

    private Vector2 currentTarget;
    // Start is called before the first frame update

    private void Awake()
    {
        if (sharedInstace == null)
        {
            sharedInstace = this;
        }
    }
    void Start()
    {
        currentTarget = startPoint.position;
        _isStatic = true;
        timerIsRunnig = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isStatic)
        {
            LookAtPlayer();
            Movent();
            Fire();
        }
    }
    void Movent()
    {
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, Mathf.PingPong(Time.time * _speed, 1f));
    }
    // Esta función cuando hay colision cambia el sentido al tank enemy

    void LookAtPlayer()
    {
        Debug.Log("Atack the player;" + player.tag);
        foreach (Transform cannon in _cannons)
        {
            Vector3 direction = (player.position - cannon.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            cannon.rotation = rotation;
        }
        
    }
    void Fire()
    {
        if (fireDelay > 0)
        {
            fireDelay -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Time has run out");
            fireDelay = 3f;
            foreach (Transform cannon in _cannons)
            {
                GameObject projectile = Instantiate(projectil);
                projectile.transform.position = cannon.position;
                projectile.transform.rotation = cannon.rotation;
            }
        }

    }
    public void SetIsStactic(bool isStactic)
    {
        _isStatic = isStactic;
        timerIsRunnig = true;
    }

}
