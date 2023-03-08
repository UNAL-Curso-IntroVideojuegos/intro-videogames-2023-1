using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
  // Start is called before the first frame update
  private Rigidbody2D _rb;

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("Loot grabbed by Player");
    DestroyObject();
  }

  private void DestroyObject()
  {
    gameObject.SetActive(false);
    Destroy(gameObject);
  }
}
