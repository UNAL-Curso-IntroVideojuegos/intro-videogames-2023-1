using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
  
        public int TotalHealthPoints { get; }
        public int HealthPoints { get; }

        public void TakeHit();

}
