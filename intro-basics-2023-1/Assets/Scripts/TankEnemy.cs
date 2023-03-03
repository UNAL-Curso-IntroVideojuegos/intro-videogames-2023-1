using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;

public class TankEnemy : MonoBehaviour
{
    // Como vamos a trabajar con físicas en 2D entonces usamos RigidBody2D
    private Rigidbody2D _rb;
    [SerializeField]
    // Variable para la velocidad de movimiento
    private float _speed = 0.5f;
    

    private float timeValue = 0.0f;
    
    // Posición inicial a donde se mueve el tanque
    [SerializeField]
    private Transform initPos;
    // Posición final a donde se mueve el tanque
	[SerializeField]
    private Transform endPost;

    // Torretas del tanque
    [SerializeField]
    private Transform[] turrets;

    // Tanque del jugador
    [SerializeField]
    private GameObject playerTank;

    // Prefab de las balas
    [SerializeField]
    private GameObject _projectilePrefab;

    // Cañón 1
    [SerializeField]
    private Transform _shootPoint1;
    // Cañón 2
    [SerializeField]
    private Transform _shootPoint2;

    // Timer
    [SerializeField]
    private float _timer = 5.0f;
    // Variable auxiliar
    private float aux;


    void Start()
    {
        // Auxiliar va a guardar el timer para reiniciarlo
        aux = _timer;
        // GetComponent: nos permite obtener la referencia de un componente que este en el mismo Game Object
        _rb = GetComponent<Rigidbody2D>();
        // Desactivamos los sprites del tanque
        GameObject.Find("tankEnemy").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("barrel1").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("barrel2").GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        // 
        

		// Definimos los vectores de la posición inicial y final.
        Vector3 startPosition = initPos.transform.position;
	    Vector3 endPosition = endPost.transform.position;
        // Hacemos el valor en el eje Z 0 para que no se muevan en este eje
        startPosition.z = 0;
        endPosition.z = 0;

        // Incrementamos el tiempo de animación.
		timeValue += Time.deltaTime;
		// Actualizamos el vector de posición del tanque según la posición inicial y final.
		transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(_speed * timeValue, 1.0f));

        // Vector que tendrá la dirección donde está el tanque del jugador
        Vector3 aimVector = (playerTank.transform.position - transform.position).normalized;
        // Ángulo que deberán rotar las torretas del tanque enemigo
        float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
        
        // A cada torreta le aplicamos la rotación
        foreach (Transform _turret in turrets)
        {
            _turret.rotation = Quaternion.Euler(0, 0, angle);
        }

        // Si el sprite está activo significa que ya spawneó el tanque
        if (GameObject.Find("tankEnemy").GetComponent<SpriteRenderer>().enabled == true)
        {
            // Disminuir el tiempo
            _timer -= Time.deltaTime;
            
            // Si se acabó el tiempo, disparar
            if (_timer <= 0.0f)
            {
            //Instanciar las balas
            GameObject projectile1 = Instantiate(_projectilePrefab);
            GameObject projectile2 = Instantiate(_projectilePrefab);

            // Posición y rotación de la bala 1
            projectile1.transform.position = _shootPoint1.position;
            projectile1.transform.rotation = _shootPoint1.rotation;
            // Posición y rotación de la bala 2
            projectile2.transform.position = _shootPoint2.position;
            projectile2.transform.rotation = _shootPoint2.rotation;
            
            // Resetear el timer
            _timer = aux;
            }
        }
        
        
    }
}
