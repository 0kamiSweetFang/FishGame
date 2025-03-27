using UnityEngine;

public class moderateAvi : MonoBehaviour
{
    public moderate mm; //moderate minigame
    public SpriteRenderer sr;
    public Sprite[] Sprites;
    public Sprite BadSprite;
    public bool inRange;
    public bool hit;
    public float timer = 0.25f;
    public AudioSource AS;
    public AudioClip[] AC;

    void Start()
    {
        if (sr.sprite == BadSprite) return;
        sr.sprite = Sprites[Random.Range(0, Sprites.Length)];
    }

    public void Update()
    {
        if (inRange && Input.GetMouseButtonDown(0))
        {
            inRange = false;
            hit = true;
            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddTorque(transform.forward * Random.Range(-200, 200));
            AS.clip = AC[Random.Range(0, AC.Length)];
            AS.Play();
        }
        if (hit && sr.sprite == BadSprite)
        {
            timer -= Time.deltaTime * mm.mgh.speedMod;
            if (timer <= 0)
            {
                hit = false;
                mm.moderated++;
            }
        }
    }

    public void BadAvi()
    {
        sr.sprite = BadSprite;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != mm.mgh.cursor || hit) return;
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != mm.mgh.cursor || hit) return;
        inRange = false;
    }
}