using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtDelay : MonoBehaviour
{
    [SerializeField]
    private float _delay = 2;

    void Start()
    {
        Destroy(gameObject, _delay);
    }
}
