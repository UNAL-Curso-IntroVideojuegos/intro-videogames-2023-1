using UnityEngine;

namespace AllieJoe.Util
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