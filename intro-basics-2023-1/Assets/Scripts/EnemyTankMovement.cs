using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankMovement : MonoBehaviour
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


    void Start()


    {   tanqueenemigo.SetActive(false);
        PosicionI= transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(iniciarpinpong){ 

            if(reversar){
                if (x)
                transform.position = new Vector3 (PosicionI.x - Mathf.PingPong(Time.time, distancia),transform.position.y,0);
                if (y)
                transform.position = new Vector3 (transform.position.x, PosicionI.y - Mathf.PingPong(Time.time, distancia),0);
            }
            else{
                if (x)
                transform.position = new Vector3 (PosicionI.x + Mathf.PingPong(Time.time, distancia),transform.position.y,0);
                if (y)
                transform.position = new Vector3 (transform.position.x, PosicionI.y + Mathf.PingPong(Time.time, distancia),0);

            }

        }
    }

} 


