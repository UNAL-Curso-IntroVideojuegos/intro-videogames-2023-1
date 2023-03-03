using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TankEnemy : MonoBehaviour
{
     [Header("Movement")]
     [SerializeField] private Transform[] _positions;
     [SerializeField] private float _speed;
     
     [Space(20)]
     [Header("Rotation")]
     [SerializeField] private Transform[] _cannons;
     [SerializeField] private Transform _player;

     [Space(20)]
     [Header("Aparicion")]
     [SerializeField] private GameObject _go;
     private Rigidbody2D _rb;

     


     // Start is called before the first frame update
     void Start()
     {
          _rb = GetComponent<Rigidbody2D>();
          //Hacemos desaparecer el objeto seleccionado, en este caso el mismo.
          _go.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
          //cannons rotation
          
          for (int i = 0; i < _cannons.Length; i++)
          {
               //vector direccion hacia el jugador
               Vector3 aimVector = (_player.position - transform.position).normalized;
               float lookAngle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
               //este Quaternion ni idea como funciona pero es el importante
               _cannons[i].rotation = Quaternion.Euler(0, 0, lookAngle);
          }
     }

     private void FixedUpdate()
     {
          //Movimeinto
               //Para la posicion solo es interpolar entre los valores de las dos posiciones el valor devuelto por pingpong (que debe ser entre 0 y 1) segun el timepo transcurrido
               //el time se multiplica por la velocidad para reducir o aumentar este espacio de tiempo de oscilacion entre 0 y 1 para que vaya mas lento o mas rapido
          _rb.position = Vector3.Lerp(_positions[0].position, _positions[1].position, Mathf.PingPong(Time.time*_speed,1));
     }
}
