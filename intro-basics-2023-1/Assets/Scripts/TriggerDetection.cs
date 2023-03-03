using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject triger;
    public GameObject tanqueenemigo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        triger.SetActive(false);
        tanqueenemigo.SetActive(true);
        Debug.Log("me active");
    }
}
