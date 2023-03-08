using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{
  // Start is called before the first frame update
  [SerializeField]
  private GameObject[] drops;
  [field: SerializeField]
  public int TotalHealthPoints { get; private set; }
  public int HealthPoints { get; private set; }
  private int rdDropIndex;
  private float rdDropProbability;
  void Start()
  {
    HealthPoints = TotalHealthPoints;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void TakeHit()
  {
    if (HealthPoints <= 0)
      return;

    HealthPoints--;
    if (HealthPoints <= 0)
    {
      rdDropProbability = Random.Range(0f, 1f);
    if(rdDropProbability>0.4f)
        DropObject();
      DestroyObject();
    }
  }

  public void DropObject()
  {
    rdDropIndex = Random.Range(0, drops.Length);
    GameObject drop = Instantiate(drops[rdDropIndex]);
    Vector2 newPost = Random.insideUnitCircle;
    drop.transform.position = new Vector3(transform.position.x + newPost.x, transform.position.y + newPost.y, transform.position.z);
  }

  private void DestroyObject()
  {
    gameObject.SetActive(false);
    Destroy(gameObject);
  }

}
