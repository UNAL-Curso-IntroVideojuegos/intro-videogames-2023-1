using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    private float _time;
    void Update()
    {
        _time += Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, 20 * _time);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Loot grabbed by Player");
        gameObject.SetActive(false);
    }
}
