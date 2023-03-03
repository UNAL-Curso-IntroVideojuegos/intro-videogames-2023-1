using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{   
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _DangerZone; 

    private BoxCollider2D _bc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        _enemy.SetActive(true);
        _DangerZone.SetActive(false);
    }


}
