using UnityEngine;

public class moderate : MonoBehaviour
{
    public miniGameHelper mgh;
    public GameObject crosshair;
    public GameObject aviPrefab;
    public Transform[] poss;
    public GameObject[] avatars;
    public int moderated;
    public AudioSource pewAS;

    private void Start()
    {
        mgh = FindAnyObjectByType<miniGameHelper>();
        avatars = new GameObject[poss.Length];
        int i = 0;
        foreach (Transform t in poss)
        {
            avatars[i] = Instantiate(aviPrefab);
            avatars[i].transform.parent = this.gameObject.transform;
            avatars[i].GetComponent<moderateAvi>().mm = this;
            avatars[i].transform.position = t.position;
            i++;
        }
        avatars[Random.Range(0,avatars.Length)].GetComponent<moderateAvi>().BadAvi();
    }

    private void Update()
    {
        crosshair.transform.position = mgh.cursor.transform.position;
        if (moderated >= 1)
        {
            mgh.finalScore = 1;
        }
        if (Input.GetMouseButtonDown(0))
        {
            pewAS.Play();
        }
    }
}