using UnityEngine;

public class fishLaunch : MonoBehaviour
{
    public launchFish lf;
    public bool done;
    public AudioSource AudioSource;
    public AudioClip[] AudioClips;
    public Rigidbody rb;
    public bool hitCursor;
    public int launchPower = 1000;

    private void Start()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        done = false;
        this.transform.position = new Vector3(Random.Range(-9f, 9f), Random.Range(-3f,-4.5f),0);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !done && hitCursor)
        {
            done = true;
            rb.useGravity = true;
            rb.isKinematic = false;
            lf.fishLaunched++;
            AudioSource.clip = AudioClips[Random.Range(0, AudioClips.Length)];
            AudioSource.loop = false;
            AudioSource.Play();
            rb.AddForce(Vector3.up * launchPower);
            rb.AddTorque(Vector3.forward * Random.Range(-2000,2000));
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "Cursor") return;
        hitCursor = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag != "Cursor") return;
        hitCursor = false;
    }
}