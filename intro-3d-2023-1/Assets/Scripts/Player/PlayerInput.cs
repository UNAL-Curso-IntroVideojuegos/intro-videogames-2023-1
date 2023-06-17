using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 Move { get; private set; }
    public Vector3 Look { get; private set; }
    public Vector3 MouseWorldPosition { get; private set; }
    
    public bool TriggerHold { get; private set; }
    public bool TriggerRelease { get; private set; }

    private Camera _cam;
    private Plane _worldPlane;

    private void Start()
    {
        _cam = Camera.main;
        _worldPlane = new Plane(Vector3.up, 0);
    }

    private void Update()
    {
#if DEBUG_WIZZARD
        Debug.Log("Holi");
#endif
       
        
#if UNITY_IOS || UNITY_ANDROID
        //TODO: Inputs for mobile
        //MobileInputs();
#else
        DesktopInputs();
#endif
    }

    private void DesktopInputs()
    {
        Move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        TriggerHold = Input.GetMouseButton(0);

        Vector3 mousePos = Input.mousePosition;
        Ray ray = _cam.ScreenPointToRay(mousePos);

        // if (Physics.Raycast(ray, out RaycastHit hitInfo))
        // {
        //     _sphere.position = hitInfo.point;
        // }

        if (_worldPlane.Raycast(ray, out float distance))
        {
            MouseWorldPosition = ray.GetPoint(distance);
            Look = (MouseWorldPosition - transform.position).normalized;
        }
        else
        {
            MouseWorldPosition = Vector3.zero;
            Look = Vector3.zero;
        }
    }
}