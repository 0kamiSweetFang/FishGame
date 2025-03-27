using UnityEngine;

public class classyHat : MonoBehaviour
{
    public miniGameHelper mgh;
    public GameObject correctHat; //right ghat prefab
    public GameObject wrongHat; //wrong hat prefab
    public Transform[] hatPoss; //all hat pos's
    public Transform ghp; //good hat pos
    public Transform[] bhps; //bad hat pos's
    public hatHat ghhh; //good hat (hathat.cs)
    public GameObject[] groggs;

    private void Start()
    {
        //set positions of hats
        ghp = hatPoss[Random.Range(0, hatPoss.Length - 1)];
        bhps = new Transform[hatPoss.Length - 1];
        int ii = 0;
        for (int i = 0; i < hatPoss.Length; i++)
        {
            if (ii < hatPoss.Length - 1)
            {
                bhps[i] = hatPoss[ii];
                if (bhps[i] == ghp && ii < hatPoss.Length - 1)
                {
                    bhps[i] = hatPoss[ii + 1];
                    ii++;
                }
                ii++;
            }
        }
        //spawn good hat
        GameObject newGoodHat = Instantiate(correctHat);
        newGoodHat.transform.position = ghp.position;
        newGoodHat.transform.parent = this.gameObject.transform;
        ghhh = newGoodHat.GetComponent<hatHat>();
        ghhh.mgh = mgh;
        //spawn bad hats
        foreach (Transform bhp in bhps)
        {
            if (bhp != null)
            {
                GameObject newBadHat = Instantiate(wrongHat);
                newBadHat.transform.parent = this.gameObject.transform;
                newBadHat.GetComponent<hatHat>().mgh = mgh;
                newBadHat.transform.position = bhp.position;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!ghhh) return;
        {
            
        }
        if (!ghhh.inRange)
        {
            groggs[0].SetActive(true);
            groggs[1].SetActive(false);
        }
        else
        {
            groggs[0].SetActive(false);
            groggs[1].SetActive(true);
        }
    }
}