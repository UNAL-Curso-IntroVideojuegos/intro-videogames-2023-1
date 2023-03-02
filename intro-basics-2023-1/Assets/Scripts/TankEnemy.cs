using UnityEngine;
using System.Collections.Generic;


public class TankEnemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1;
    
    [Space(20)]
    public Transform[] _cannons;
    [Space(20)]
    public Transform[] _shootPoints;
    [Space(20)]
    public GameObject _projectilePrefab;

    [Space(20)]
    [SerializeField]
    private Transform _inicio;

    [SerializeField]
    private Transform _fin;

    [Space(20)]
    [SerializeField]
    private Transform _player; //Para obtener la posicion del jugador

    
    private Rigidbody2D _rb;

    [Space(20)]
    [SerializeField]
    private float _timeRemaining;

    private float elapsed;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        transform.gameObject.SetActive(false); //Desactivar el tankEnemy
    }

    void Update()
    {
        //Movement
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * _speed, _inicio.position.y - _fin.position.y) + _fin.position.y, transform.position.z);
        
        //Player Look
        Vector3 playerPos = _player.position;
        playerPos.z = 0;

        
        //Cannons Rotation:
        foreach (Transform cannon in _cannons){

            Vector3 aimVector = (playerPos - cannon.position).normalized; //(Donde quiero mirar - yo)
            float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
            
            cannon.rotation = Quaternion.Euler(0,0,angle);

        }

        //Timer dispararador

        elapsed += Time.deltaTime;
        if (elapsed >= _timeRemaining)
        {
            elapsed = 0f; //Volver a inicair disparador
            foreach (Transform shootPoint in _shootPoints)
            {
                GameObject projectile = Instantiate(_projectilePrefab);
                projectile.transform.position = shootPoint.position;
                projectile.transform.rotation = shootPoint.rotation;
            }

        }
    }

}