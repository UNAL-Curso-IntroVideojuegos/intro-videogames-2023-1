using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonObject : MonoBehaviour
{
[SerializeField] GameObject square;
[SerializeField] float offset;
    void Update()
    {
        float xDiff = square.transform.position.x - transform.position.x;
        float yDiff = square.transform.position.y - transform.position.y;

        float radians = Mathf.Atan2(yDiff, xDiff);
        float degrees = radians * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, degrees + offset);
    }
}

