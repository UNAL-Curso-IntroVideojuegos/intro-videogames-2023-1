using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform[] _cannons;
    [SerializeField]
    public Transform _limitup;
    [SerializeField]
    public Transform _limitdown;
    //private Rigidbody2D _rb;
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private GameObject shooter;
    public float timeRemaining = 2;
    void Start()
    {
        //Inicializador del Objeto EnemyTank
        gameObject.SetActive(false);

    }

    void Update()
    {
        //Obtiene la informacion de sus puntos de inicio y final
        Vector3 inicio = _limitdown.position;
        Vector3 final = _limitup.position;
        float d = Mathf.PingPong(Time.time * _speed, 1);
        transform.position = Vector3.Lerp(inicio, final, d);

        //Angulos de Cañones al jugador

        Vector3 dir = (_player.position) - (_cannons[0].position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Vector3 rot = _cannons[0].eulerAngles;
        rot.z = angle;
        _cannons[0].eulerAngles = rot;

        Vector3 dir1 = ((_cannons[1].position) - (_player.position)).normalized;
        float angle1 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Vector3 rot1 = _cannons[1].eulerAngles;
        rot1.z = angle1;
        _cannons[1].eulerAngles = rot1;

        //Tiempo de recarga
        timeRemaining -= Time.deltaTime;

        if (timeRemaining < 0)
        {
            GameObject projectile1 = Instantiate(shooter);
            projectile1.transform.position = _cannons[0].position;
            projectile1.transform.rotation = _cannons[0].rotation;


            GameObject projectile2 = Instantiate(shooter);
            projectile2.transform.position = _cannons[1].position;
            projectile2.transform.rotation = _cannons[1].rotation;
            timeRemaining = 2;

        }
    }
}