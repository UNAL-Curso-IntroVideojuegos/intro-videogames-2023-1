using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startTransform;
    public Transform endTransform;
    public Transform player;
    public Transform[] cannons;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float timeRemaining = 3;
    public float speed = 1.0f;
    
    [SerializeField]
    private GameObject shooter;
    void Start()
    {
        startPosition = startTransform.position;
        endPosition = endTransform.position;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        float time = Mathf.PingPong(Time.time * speed, 1); 
        transform.position = Vector3.Lerp(startPosition, endPosition, time);


        timeRemaining -= Time.deltaTime;
        foreach (Transform cannon in cannons)
        {
            Vector3 aimVector = (cannon.position - player.position).normalized;
            float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
            cannon.rotation = Quaternion.Euler(0, 0, angle);
            if (timeRemaining < 0)
            {
                GameObject projectile = Instantiate(shooter);
                projectile.transform.position = cannon.position;
                projectile.transform.rotation = cannon.rotation;
            }
        }

        if (timeRemaining < 0)
        {
            timeRemaining = 3;
        }

    }
}
