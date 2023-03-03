using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour //crear script del tanque enemigo
{
    [SerializeField] //campos en unity
    private float _speed = 1;
    [Space(15)] //espacio entre lineas de campos unity
    [SerializeField]//campos en unity
    private Transform[] _cannons; //para disparar

    [SerializeField]//campos en unity
    private Transform[] _shootPoints; //variable de disparos

    [SerializeField] //campos en unity
    private GameObject _projectilePrefab; //variable para arrastrar el bullet pero del enemy

    [SerializeField] //campos en unity
    private Transform _target; //el objetivo que es el player

    private Rigidbody2D _rb;
    private float _dirY; //direccion de movimiento del tanque enemigo

    private float _shootingTime = 0; //contador de disparo




    private void Start() //inciializar
    {
        gameObject.SetActive(false); //si se activa la zona del detector
        _rb = GetComponent<Rigidbody2D>(); //trae componente
        _dirY = 2f; //doy un valor a la direcci?n, esto es arriba

    }

    void Update()
    {
        Vector3 targetPosition = _target.position; //posicion del objetivo
        targetPosition.z = 0; //no necesitamos la z porque es 2d
        for (int i = 0; i < _cannons.Length; i++) //iterar los ca?ones porque son dos, comenzando desde cero, terminando en el total
        {
            Vector3 aimVector = (targetPosition - _cannons[i].position).normalized; //se resta a la posicion del objetvio la del ca?on actual, que se saca con la iteracion. Se normaliza para tener direccion a la que apunta el tanque enemigo
            float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90; //calculo el angulo en radianes con tan-1 como con el player, sumando los 90 grados
                                                                                      //ya tengo vector entre objetivo y cada ca?on para tener direccion con normalizacion y saco el angulo de apuntado
            _cannons[i].rotation = Quaternion.Euler(0, 0, angle); //cada ca?on tengo que rotarlo segun el angulo que determine antes
        }

        //no quiero que dispare seguido sino que sea cada que de clic entonces toca hacer un delay
        if (_shootingTime > 0) //si es mayor a cero, tiene que restar el delta para ir descontando
        {
            _shootingTime -= Time.deltaTime;
        }
        else
        {
            _shootingTime = 2; //reiniciar el contador de disparo

            for (int i = 0; i < _shootPoints.Length; i++) //itero para poder hace rlos disparos
            {
                //Shoot
                GameObject projectile = Instantiate(_projectilePrefab); //similar al player shooter,  crear copia y ponerlo en memoria, es instanciar
                projectile.transform.position = _shootPoints[i].position; //ponerse en la posicion que quiero
                projectile.transform.rotation = _shootPoints[i].rotation; //para que la bala vaya hacia el player
            }
        }

    }

    //el tiempo igual entre cada frame para hacer una buena simulacion
    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _dirY * _speed); //cambio la velocidad de la direccion fisica considerando el eje Y que es en el que se mueve la torreta enemiga
    }

    private void OnTriggerEnter2D(Collider2D other) //cuando otro objeto ingresa a un colisionador activador adjunto a este objeto
    {
        if (other.GetComponent<SwitchPoint>()) //con el codigo creado del switch point
        {
            _dirY *= -1; //si toma ese valor, est? abajo
        }
    }
}