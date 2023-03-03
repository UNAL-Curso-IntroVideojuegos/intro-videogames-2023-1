using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform[] _cannons;
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private Transform _ini;
    [SerializeField]
    private Transform _fin;
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private GameObject _tankoff;  
    
    private Vector3 _inicio;
    private Vector3 _final;

    

    // Start is called before the first frame update
    void Start()
    {
        _inicio=_ini.position;
        _final=_fin.position;
        _tankoff.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position= Vector3.Lerp(_inicio, _final, Mathf.PingPong(Time.time*_speed,1.0f));

        Vector3 aimVector = (_player.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;

        foreach (Transform cannon  in _cannons)
        {
            cannon.rotation = Quaternion.Euler(0,0,angle);
        }

    }
}

