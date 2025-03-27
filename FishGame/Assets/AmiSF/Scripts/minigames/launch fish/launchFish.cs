using UnityEngine;

public class launchFish : MonoBehaviour
{
    public miniGameHelper mgh;
    public int fishLaunched;
    public GameObject cursor;
    public int maxFish = 6;
    public GameObject[] weaponSprites;
    public GameObject[] fishes;
    public GameObject fishPrefab;

    private void Start()
    {
        fishLaunched = 0;
        int a = Random.RandomRange(1, maxFish);
        fishes = new GameObject[a];
        for (int i = 0; i < a; i++)
        {
            fishes[i] = Instantiate(fishPrefab);
            fishes[i].gameObject.transform.SetParent(this.gameObject.transform);
            fishes[i].GetComponent<fishLaunch>().lf = this;
        }
    }

    private void Update()
    {
        if (fishLaunched >= fishes.Length)
        {
            mgh.finalScore = 1;
            //Debug.Log("won at fish game");
        }
        cursor.transform.position = mgh.cursor.transform.position;
        if (Input.GetMouseButton(0))
        {
            weaponSprites[0].SetActive(false);
            weaponSprites[1].SetActive(true);
        }
        else
        {
            weaponSprites[0].SetActive(true);
            weaponSprites[1].SetActive(false);
        }
    }
}
