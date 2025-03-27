using UnityEngine;

public class moveRandomOnScreen : MonoBehaviour
{
    public Rigidbody rb;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        this.transform.position = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0);
    }

    private void FixedUpdate()
    {
        if (!rb.isKinematic) return;
        float minX = -32f;
        float maxX = 32f;
        float minY = -16f;
        float maxY = 16f;
        if (transform.position.y > 4f)
        {
            maxY = -8;
        }
        else if (transform.position.y < -4f)
        {
            minY = 8;
        }
        if (transform.position.x > 8f)
        {
            maxX = -8;
        }
        else if (transform.position.x < -8f)
        {
            minX = 8;
        }
        transform.position = new Vector3(transform.position.x + Random.Range(minX, maxX) * Time.deltaTime, transform.position.y + Random.Range(minY, maxY) * Time.deltaTime, 0);
    }
}