using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    [SerializeField]
    public Transform _limitup;
    [SerializeField]
    public Transform _limitdown;
    private Rigidbody2D _rb;
    [SerializeField]
    private Transform _player;


    [SerializeField]
    private Transform[] _cannon2;


    [SerializeField]
    private GameObject shooter;




    public float timeRemaining = 3;

    void Start(){
        _rb=GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);


    }
    void Update()
    {   
       Vector3 inicio=_limitdown.position;
        Vector3 final=_limitup.position;
       
        float x=Mathf.PingPong(Time.time,1);
        //Vector3 vector=new Vector3(1,x,1);
        

        Vector3 ruta=Vector3.Lerp(inicio,final,x);
        _rb.transform.position=ruta;






        Vector3 dir=(_player.position)-(_cannon2[0].position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Vector3 rot=_cannon2[0].eulerAngles;
        rot.z=angle;
        _cannon2[0].eulerAngles=rot;
///////////////////////////////////////////////////////////////////////
        Vector3 dir1=((_cannon2[1].position)-(_player.position)).normalized;
        float angle1 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Vector3 rot1=_cannon2[1].eulerAngles;
        rot1.z=angle1;
        _cannon2[1].eulerAngles=rot1;
        timeRemaining-=Time.deltaTime;
        ////////////////////////////////////////////////////////////////
            if (timeRemaining<0){
                timeRemaining=3;
            GameObject projectile1 = Instantiate(shooter);
            projectile1.transform.position = _cannon2[0].position;
            projectile1.transform.rotation = _cannon2[0].rotation;
            

            GameObject projectile2 = Instantiate(shooter);
            projectile2.transform.position = _cannon2[1].position;
            projectile2.transform.rotation = _cannon2[1].rotation;
            
}
        

        
    }
}
