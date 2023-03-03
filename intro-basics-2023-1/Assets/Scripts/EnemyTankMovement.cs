using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankMovement : MonoBehaviour
{
    [SerializeField]
    private Transform PosInicial;
    [SerializeField]
    private Transform PosFinal;
    private Vector3 vectorInicial;
    private Vector3 vectorFinal;
    private float speed = 0.2f;
    [SerializeField] private Transform[] _cannons;
    [SerializeField] private Transform jugador;
    [SerializeField] private GameObject enemigo;
    // Start is called before the first frame update
    void Start()
    {
        enemigo.SetActive(false);
        vectorInicial = PosInicial.position;
        vectorFinal = PosFinal.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(vectorInicial, vectorFinal, Mathf.PingPong((Time.time)*speed,1.0f));
        Vector3 aimVector = (jugador.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
        foreach (Transform i in _cannons)
        {
            i.rotation = Quaternion.Euler(0,0,angle);
        }
    }
}
