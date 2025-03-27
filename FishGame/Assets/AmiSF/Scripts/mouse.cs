using UnityEngine;

public class mouse : MonoBehaviour
{
    public Camera cam;
    private Vector3 target;
    public float zPos;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        target = cam.ScreenToWorldPoint(Input.mousePosition);
        target.z = zPos;
        transform.position = target;
    }
}