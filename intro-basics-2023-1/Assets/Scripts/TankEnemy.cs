using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    Vector3 PosicionI;
    public bool iniciarpinpong;
    [Header("Prueba")]
    [SerializeField] 
    public float distancia;
    public bool reversar;
    public bool y; // movamonos en el eje y
     public bool x; // movamonos en el eje x
    public GameObject tanqueenemigo;
    [SerializeField]
    private GameObject _projectilePrefab1;
    [SerializeField]
    private GameObject _projectilePrefab2;
    [SerializeField]
    private Transform _shootPoint1;
    [SerializeField]
    private Transform _shootPoint2;
    public float timeshot=2;


    void Start()


    {
        PosicionI= transform.position;
        tanqueenemigo.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        MovimientoTank();

















    }

    private void FixedUpdate()
    {
        disparar();
    }

    void MovimientoTank()
    {
        if (iniciarpinpong)
        {

            if (reversar)
            {
                if (x)
                    transform.position = new Vector3(PosicionI.x - Mathf.PingPong(Time.time, distancia), transform.position.y, 0);
                if (y)
                    transform.position = new Vector3(transform.position.x, PosicionI.y - Mathf.PingPong(Time.time, distancia), 0);
            }
            else
            {
                if (x)
                    transform.position = new Vector3(PosicionI.x + Mathf.PingPong(Time.time, distancia), transform.position.y, 0);
                if (y)
                    transform.position = new Vector3(transform.position.x, PosicionI.y + Mathf.PingPong(Time.time, distancia), 0);

            }
        }
    }

    void disparar()
    {
        if (timeshot > 0)
        {
            timeshot -= Time.deltaTime;
        }
        else
        {
            GameObject projectile1 = Instantiate(_projectilePrefab1);
            GameObject projectile2 = Instantiate(_projectilePrefab2);
            projectile1.transform.position = _shootPoint1.position;
            projectile2.transform.position = _shootPoint2.position;
            projectile1.transform.rotation = _shootPoint1.rotation;
            projectile2.transform.rotation = _shootPoint2.rotation;
            timeshot = 2;
        }
    }



} 


