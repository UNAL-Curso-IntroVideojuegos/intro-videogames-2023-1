using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour, IDamageable{

     [field:SerializeField]
     public int TotalHealthPoints { get; private set; }
     public int HealthPoints { get; private set; }

     private Rigidbody2D _rb;
     [SerializeField]
     private Transform enemyStart;
     [SerializeField]
     private Transform enemyEnd;
     
     [SerializeField]
     private Transform cannon1;
     [SerializeField]
     private Transform cannon2;
     [SerializeField]
     private Transform player;

     [SerializeField]
     private GameObject _projectilePrefab;
     [SerializeField]
     private Transform _shootPoint1;
     [SerializeField]
     private Transform _shootPoint2;
     
     private float pinpong;
     Vector3 aimVector;
     float angle;
     private float timeRemaining = 2f;

     // Start is called before the first frame update
     void Start(){
          transform.position = enemyStart.transform.position; 
     }

     private void OnEnable(){
          HealthPoints = TotalHealthPoints;
     }

     public void TakeHit(){
          if(HealthPoints <= 0){
               return;
          }
           
          HealthPoints--;
          if(HealthPoints <= 0){
               gameObject.SetActive(false);
          }       
     }

     // Update is called once per frame
     void Update(){

          pinpong = Mathf.PingPong(Time.time * 1f, enemyEnd.transform.position.y - enemyStart.transform.position.y);
          transform.position = new Vector3(enemyStart.transform.position.x, enemyStart.transform.position.y + pinpong, transform.position.z);
          
          //Cannon 1 Rotation:
          aimVector = (player.transform.position - cannon1.transform.position).normalized;
          angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 270;
          cannon1.rotation = Quaternion.Euler(0,0,angle);

          //Cannon 2 Rotation:
          aimVector = (player.transform.position - cannon2.transform.position).normalized;
          angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 270;
          cannon2.rotation = Quaternion.Euler(0,0,angle);

          if (timeRemaining > 0){
               timeRemaining -= Time.deltaTime;
               
          }else{
               GameObject projectile1 = Instantiate(_projectilePrefab);
               projectile1.transform.position = _shootPoint1.position;
               projectile1.transform.rotation = _shootPoint1.rotation;

               GameObject projectile2 = Instantiate(_projectilePrefab);
               projectile2.transform.position = _shootPoint2.position;
               projectile2.transform.rotation = _shootPoint2.rotation;

               timeRemaining = 2f;        
          }

     }
}
