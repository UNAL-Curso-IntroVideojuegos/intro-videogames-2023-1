using UnityEngine;

namespace SpaceShipNetwork.Util
{
    public class EnableRandomChild : MonoBehaviour
    {
        private void OnEnable()
        {
            if(transform.childCount == 0)
                return;
            
            int index = Random.Range(0, transform.childCount);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(i == index);
            }
        }
    }
}