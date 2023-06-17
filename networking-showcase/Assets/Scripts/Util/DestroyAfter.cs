using UnityEngine;

namespace SpaceShipNetwork.Util
{
    public class DestroyAfter : MonoBehaviour
    {
        public float TimeToDestroy;

        private void Start()
        {
            Destroy(gameObject, TimeToDestroy);
        }
    }
}