using UnityEngine;

public class hatHat : MonoBehaviour
{
    public miniGameHelper mgh;
    public GameObject cursor;
    public bool inRange;
    public bool goodHat;
    public Sprite[] sprites;
    public SpriteRenderer sr;

    public void Start()
    {
        cursor = mgh.cursor;
        sr.sprite = sprites[Random.Range(0, sprites.Length)];
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (inRange)
        {
            if (goodHat)
            {
                mgh.finalScore = 1;
            }
            else
            {
                mgh.finalScore = -1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!cursor) Start();
        if (other.gameObject != cursor) return;
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!cursor) Start();
        if (other.gameObject != cursor) return;
        inRange = false;
    }
}