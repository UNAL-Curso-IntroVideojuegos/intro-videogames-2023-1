using UnityEngine;
using UnityEngine.Events;

public class TriggerDetection : MonoBehaviour
{

    [SerializeField] 
    private bool _disableOnDetection;
    
    public UnityEvent OnDetection;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnDetection?.Invoke();
            if(_disableOnDetection)
                gameObject.SetActive(false);
        }
    }
}
