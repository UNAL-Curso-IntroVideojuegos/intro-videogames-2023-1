using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 Move { get; private set; }
    public Vector3 Look { get; private set; }

    private Camera _cam;
    private Plane _worldPlane;

    private void Start()
    {
        _cam = Camera.main;
        _worldPlane = new Plane(Vector3.up, 0);
    }

    private void Update()
    {
        DesktopInputs();
    }

    private void DesktopInputs()
    {
        Move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        
        Vector3 mousePos = Input.mousePosition;
        Ray ray = _cam.ScreenPointToRay(mousePos);

        // if (Physics.Raycast(ray, out RaycastHit hitInfo))
        // {
        //     _sphere.position = hitInfo.point;
        // }

        if (_worldPlane.Raycast(ray, out float distance))
        {
            Vector3 point = ray.GetPoint(distance);
            Look = (point - transform.position).normalized;
        }
        else
        {
            Look = Vector3.zero;
        }
    }
}
