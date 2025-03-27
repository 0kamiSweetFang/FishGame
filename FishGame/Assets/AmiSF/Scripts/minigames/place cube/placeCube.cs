using UnityEngine;

public class placeCube : MonoBehaviour
{
    public miniGameHelper mgh;
    public GameObject cursor;
    public GameObject cube;
    public Transform character;
    public GameObject[] charSprites;

    void Start()
    {
        cursor = mgh.cursor;
        character.transform.position = new Vector3(Random.Range(-8f, 8f), Random.Range(-1f, -2f), 0);
        charSprites[0].SetActive(true);
        charSprites[1].SetActive(false);
        charSprites[2].SetActive(false);
    }

    void Update()
    {
        Vector3 newPos = cursor.transform.position;
        cube.transform.position = new Vector3(newPos.x, newPos.y, -1);
        if (Input.GetMouseButtonDown(0))
        {
            if (charSprites[1].activeSelf)
            {
                mgh.finalScore = 1;
            }
            else
            {
                mgh.finalScore = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != cursor) return;
        charSprites[0].SetActive(false);
        charSprites[1].SetActive(true);
        charSprites[2].SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != cursor) return;
        charSprites[0].SetActive(false);
        charSprites[1].SetActive(false);
        charSprites[2].SetActive(true);
    }
}