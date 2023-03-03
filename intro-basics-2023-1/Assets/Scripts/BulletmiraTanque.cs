using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletmiraTanque : MonoBehaviour
{
    public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MirarPlayer();

    }
    void MirarPlayer()
    {
        Vector3 aimVector = (jugador.transform.position - transform.position).normalized;
        float angulomirar = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg -90;
        var rot = transform.eulerAngles;
        rot.z = angulomirar;
        transform.eulerAngles = rot;
    }
}