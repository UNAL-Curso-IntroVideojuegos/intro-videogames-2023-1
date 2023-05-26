using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera _cam;
    
    private void Start()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        transform.LookAt(_cam.transform);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180f, 0);
    } 
}
